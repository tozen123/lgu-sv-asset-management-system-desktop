using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.DashboardPanels
{
    public partial class AssetByCategoryPanel : UserControl
    {
        private DatabaseConnection databaseConnection;
        string office;
        string targetYear;
        public AssetByCategoryPanel(string _office, string _year)
        {
            InitializeComponent();
            databaseConnection = new DatabaseConnection();
            targetYear = _year;
            office = _office;
            CategoryAssetCount();
        }

        private void AssetByCategoryPanel_Load(object sender, EventArgs e)
        {

        }

        private void CategoryAssetCount()
        {
            string query;

            if (targetYear == "All")
            {
                query = "SELECT AC.assetCategoryName, COUNT(A.assetId) AS AssetCount " +
                       "FROM [LGU_AMS_DB].[dbo].[AssetCategory] AC " +
                       "LEFT JOIN [LGU_AMS_DB].[dbo].[Assets] A ON AC.assetCategoryId = A.assetCategoryID " +
                       "WHERE A.assetLocation = @loc " +
                       "GROUP BY AC.assetCategoryId, AC.assetCategoryName " +
                       "ORDER BY AC.assetCategoryId";
            }
            else
            {
                query = "SELECT AC.assetCategoryName, COUNT(A.assetId) AS AssetCount " +
                       "FROM [LGU_AMS_DB].[dbo].[AssetCategory] AC " +
                       "LEFT JOIN [LGU_AMS_DB].[dbo].[Assets] A ON AC.assetCategoryId = A.assetCategoryID " +
                       "WHERE A.assetLocation = @loc AND YEAR(assetAcknowledgeDate) = @year " +
                       "GROUP BY AC.assetCategoryId, AC.assetCategoryName " +
                       "ORDER BY AC.assetCategoryId";
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@loc", office},
                {"@year", targetYear}
            };


            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

           

            foreach (DataColumn column in resultTable.Columns)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = column.ColumnName;
                col.Name = column.ColumnName;
                switch (column.ColumnName)
                {
                    case "assetCategoryName":
                        col.HeaderText = "Category Name";
                        break;
                    case "AssetCount":
                        col.HeaderText = "Count";
                        break;

                    default:
                        col.HeaderText = column.ColumnName;
                        break;
                }

                dataGridViewCat.Columns.Add(col);
            }
            dataGridViewCat.DataSource = resultTable;
            dataGridViewCat.RowHeadersVisible = false;
            
       

        }
    }
}
