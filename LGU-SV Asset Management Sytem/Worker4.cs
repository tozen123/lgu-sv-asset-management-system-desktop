using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace LGU_SV_Asset_Management_Sytem
{
    public class Worker4
    {
        private MainForm mainform;
        string setYear = "All";

        private DatabaseConnection databaseConnection;
        public Worker4(MainForm form)
        {
            this.mainform = form;

            mainform.Resize += OnResize;
            databaseConnection = new DatabaseConnection();
        }
        private void OnResize(object sender, EventArgs e)
        {
            Console.WriteLine("Worker4 - Mainform resized");
            ResizePanels(setYear);
        }
        public void ResizePanels(string year)
        {
            mainform.roundedPanelTotalAsset.Controls.Clear();
            mainform.roundedPanelCategoryCount.Controls.Clear();

            Panels.DashboardPanels.TotalAssetPanel totalAssetPanel = new Panels.DashboardPanels.TotalAssetPanel(mainform.currentUserOffice, year);
            totalAssetPanel.Size = mainform.roundedPanelTotalAsset.Size;
            mainform.roundedPanelTotalAsset.Controls.Add(totalAssetPanel);

            Panels.DashboardPanels.AssetByCategoryPanel assetByCategoryPanel = new Panels.DashboardPanels.AssetByCategoryPanel(mainform.currentUserOffice, year);
            assetByCategoryPanel.Size = mainform.roundedPanelCategoryCount.Size;
            mainform.roundedPanelCategoryCount.Controls.Add(assetByCategoryPanel);

        }

        public void DashboardLoad()
        {
            LoadChart(setYear);
            Console.WriteLine("Worker4");
            ResizePanels(setYear);

            mainform.menuButtonSortByYear.Menu = new ContextMenuStrip();
            mainform.menuButtonSortByYear.Text = $"Sort By Acknowledge Year: {setYear}";
            
            mainform.menuButtonSortByYear.Menu.Items.Add("All", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2023", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2022", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2021", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2020", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2019", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2018", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2017", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2016", null, MenuClickSortByYear_Click);
            mainform.menuButtonSortByYear.Menu.Items.Add("2015", null, MenuClickSortByYear_Click);

           
        }

        private void MenuClickSortByYear_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                string itemName = clickedItem.Text;
                {
                    switch (itemName)
                    {
                        case "All":
                            setYear = "All";
                            break;
                        case "2023":
                            setYear = "2023";
                            break;
                        case "2022":
                            setYear = "2022";
                            break;
                        case "2021":
                            setYear = "2021";
                            break;
                        case "2020":
                            setYear = "2020";
                            break;
                        case "2019":
                            setYear = "2019";
                            break;
                        case "2018":
                            setYear = "2018";
                            break;
                        case "2017":
                            setYear = "2017";
                            break;
                        case "2016":
                            setYear = "2016";
                            break;
                        case "2015":
                            setYear = "2015";
                            break;

                    }
                }
                ResizePanels(itemName);
                LoadChart(itemName);
                mainform.menuButtonSortByYear.Text = $"Sort By Acknowledge Year: {itemName}";
            }
        }


        private void LoadChart(string _year)
        {
            mainform.chartAssetByCategories.Series.Clear();
            Series assetCategoriesSeries = new Series("Assets");
            assetCategoriesSeries.ChartType = SeriesChartType.Column;
            mainform.chartAssetByCategories.Series.Add(assetCategoriesSeries);

      
            string query;

            if (_year == "All")
            {
                query = "SELECT A.assetCondition, COUNT(A.assetId) AS Count " +
                           "FROM Assets A " +
                           "GROUP BY A.assetCondition";
            }
            else
            {
                query = "SELECT A.assetCondition, COUNT(A.assetId) AS Count " +
                           "FROM Assets A " +
                           "WHERE YEAR(assetAcknowledgeDate) = @year " +
                           "GROUP BY A.assetCondition";
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {@"year", _year}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            mainform.chartAssetByCategories.Series["Assets"].Points.Clear(); // Clear existing points

            foreach (DataRow row in resultTable.Rows)
            {
                string condition = row["assetCondition"].ToString();
                int count = Convert.ToInt32(row["Count"]);

                mainform.chartAssetByCategories.Series["Assets"].Points.AddXY(condition, count);
            }

            databaseConnection.CloseConnection();

        }
    }
}
