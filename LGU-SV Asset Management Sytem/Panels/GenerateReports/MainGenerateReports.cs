using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LGU_SV_Asset_Management_Sytem.Panels.GenerateReports
{   
  
    public partial class MainGenerateReports : UserControl
    {
        private DatabaseConnection databaseConnection;

        List<string> FILTER_SETTINGS_SELECTED_LOCATIONS = new List<string>();
        List<string> FILTER_SETTINGS_SELECTED_YEAR = new List<string>();
        List<string> FILTER_SETTINGS_SELECTED_CONDITION = new List<string>();
        List<bool> FILTER_SETTINGS_SELECTED_MISSING = new List<bool>();
        List<string> FILTER_SETTINGS_SELECTED_CATEGORIES = new List<string>();


        List<CheckBox> FILTER_DYNAMIC_CATEGORIES = new List<CheckBox>();



        List<CheckBox> FILTER_OFFICES_CHECKBOXES = new List<CheckBox>();
        List<CheckBox> FILTER_YEAR_CHECKBOXES = new List<CheckBox>();
        List<CheckBox> FILTER_CONDITIONS_CHECKBOXES = new List<CheckBox>();
        List<CheckBox> FILTER_GHOSTMISSING_CHECKBOXES = new List<CheckBox>();



        public MainGenerateReports()
        {
            InitializeComponent();
            databaseConnection = new DatabaseConnection();
            PopulateCategoryComboBox();
           

            panelFilterHandler.Visible = false;



            
            FILTER_OFFICES_CHECKBOXES.AddRange(new[] { checkBoxGSO, checkBoxMHO, checkBoxMCR, checkBoxMEO, checkBoxMBO, checkBoxAO });
            FILTER_YEAR_CHECKBOXES.AddRange(new[] { checkBox2023, checkBox2022, checkBox2021, checkBox2020, checkBox2019, checkBox2018,
                                                    checkBox2017, checkBox2016, checkBox2015, checkBox2014 });

            FILTER_CONDITIONS_CHECKBOXES.AddRange(new[] { checkBoxNonServiceable, checkBoxServiceable });
            FILTER_GHOSTMISSING_CHECKBOXES.AddRange(new[] { checkBoxMissing, checkBoxNotMissing });

            HersheyTheDogOfCheckerMethod(FILTER_OFFICES_CHECKBOXES, true);
            HersheyTheDogOfCheckerMethod(FILTER_YEAR_CHECKBOXES, true);
            HersheyTheDogOfCheckerMethod(FILTER_CONDITIONS_CHECKBOXES, true);
            HersheyTheDogOfCheckerMethod(FILTER_GHOSTMISSING_CHECKBOXES, true);
            HersheyTheDogOfCheckerMethod(FILTER_DYNAMIC_CATEGORIES, true);

            GetTotalAsset();
            GetAssetCondition();
            GetTotalPurchaseAmount();
            GetAssetMissing();
            GetAssets();
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            HersheyTheDogOfCheckerMethod(FILTER_OFFICES_CHECKBOXES, false);
            HersheyTheDogOfCheckerMethod(FILTER_YEAR_CHECKBOXES, false);
            HersheyTheDogOfCheckerMethod(FILTER_CONDITIONS_CHECKBOXES, false);
            HersheyTheDogOfCheckerMethod(FILTER_GHOSTMISSING_CHECKBOXES, false);
            HersheyTheDogOfCheckerMethod(FILTER_DYNAMIC_CATEGORIES, false);


        }

        private void HersheyTheDogOfCheckerMethod(List<CheckBox> checkBoxes, bool state)
        {
            foreach (CheckBox checkBox in checkBoxes)
            {
                checkBox.Checked = state;
            }
        }

        private void JohnLloydPileTheSetToDefaultMethod(List<CheckBox> checkBoxes)
        {
            if (!AndrePaCheckNgaKungMayAlamPa(checkBoxes))
            {
                HersheyTheDogOfCheckerMethod(checkBoxes, true);
            }
        }

        private bool AndrePaCheckNgaKungMayAlamPa(List<CheckBox> checkBoxes)
        {
            return checkBoxes.Any(checkBox => checkBox.Checked);
        }

        public void PopulateCategoryComboBox()
        {
            FILTER_DYNAMIC_CATEGORIES.Clear();

            string query = "SELECT CONCAT(assetCategoryId, '-', assetCategoryName) AS cat FROM AssetCategory"; ;


            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            List<string> categories = new List<string>();

           
            foreach (DataRow row in resultTable.Rows)
            {
                string category = row["cat"].ToString();
                Console.WriteLine(category);
                categories.Add(category);
            }

            databaseConnection.CloseConnection();

            for (int i = 0; i < categories.Count; i++)
            {
                CheckBox checkBox = new CheckBox();

                checkBox.Name = categories[i].Split('-')[0].Trim();
               
                checkBox.Text = categories[i].Split('-')[1].Trim();
                checkBox.Font = new System.Drawing.Font("Poppins", 8, System.Drawing.FontStyle.Regular);

                Console.WriteLine($"Added CheckBox with Name: {checkBox.Text}");
                flowLayoutPanel1.Controls.Add(checkBox);

                FILTER_DYNAMIC_CATEGORIES.Add(checkBox);
            }

        }
        private bool isToggled = false;
        private void roundedButtonFilter_Click(object sender, EventArgs e)
        {
            
            isToggled = !isToggled;

            
            if (isToggled)
            {
                panelFilterHandler.Visible = true;
                panelFilterHandler.BringToFront();
            }
            else
            {
                panelFilterHandler.Visible = false;
                panelFilterHandler.SendToBack();
            }
        }

        private void roundedButtonSaveAsPanel_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(panelMainReport.Width, panelMainReport.Height);
            panelMainReport.DrawToBitmap(bitmap, new Rectangle(0, 0, panelMainReport.Width, panelMainReport.Height));


            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save As Image";
                saveFileDialog.ShowDialog();

            
                if (saveFileDialog.FileName != "")
                {
                    
                    string fileExtension = Path.GetExtension(saveFileDialog.FileName);

              
                    switch (fileExtension.ToLower())
                    {
                        case ".png":
                            bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                            break;
                        case ".jpg":
                            bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                            break;
                        case ".bmp":
                            bitmap.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                            break;
                        default:
                         
                            break;
                    }
                }
            }


            bitmap.Dispose();
        }

        private void roundedButtonPrintPanel_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(panelMainReport.Width, panelMainReport.Height);
            panelMainReport.DrawToBitmap(bitmap, new Rectangle(0, 0, panelMainReport.Width, panelMainReport.Height));
            e.Graphics.DrawImage(bitmap, e.PageBounds);
        }



        private void GetTotalAsset()
        {
            string query = "SELECT COUNT(*) AS count FROM Assets A ";
            bool hasWhereClause = false;

            if (FILTER_SETTINGS_SELECTED_LOCATIONS.Count > 0)
            {
                query += " WHERE A.assetLocation IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_LOCATIONS.Select(_ => "@" + (_.Contains('-') ? _.Split('-')[0] : _))) + ")";
                hasWhereClause = true;
            }

            if (FILTER_SETTINGS_SELECTED_YEAR.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " YEAR(A.assetAcknowledgeDate) IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_YEAR.Select(y => "@" + y)) + ")";
                hasWhereClause = true;
            }
            
            
            if(FILTER_SETTINGS_SELECTED_CONDITION.Count == 2)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " assetCondition IN ('NON-SERVICEABLE', 'SERVICEABLE')";
                hasWhereClause = true;

            }
            else if(FILTER_SETTINGS_SELECTED_CONDITION.Count == 1)
            {
                if(FILTER_SETTINGS_SELECTED_CONDITION[0].Equals("NON-SERVICEABLE"))
                {
                    query += hasWhereClause ? " AND " : " WHERE ";
                    query += " assetCondition IN ('NON-SERVICEABLE')";
                    hasWhereClause = true;
                }
                else
                {
                    query += hasWhereClause ? " AND " : " WHERE ";
                    query += " assetCondition IN ('SERVICEABLE')";
                    hasWhereClause = true;

                }
                
            }
            if (FILTER_SETTINGS_SELECTED_MISSING.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " assetIsMissing IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_MISSING.Select(m => "@" + m)) + ")";
            }
            if (FILTER_SETTINGS_SELECTED_CATEGORIES.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " A.assetCategoryID IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_CATEGORIES.Select(y => "@" + y)) + ")";
            }
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_LOCATIONS.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_LOCATIONS[i].Split('-')[0], FILTER_SETTINGS_SELECTED_LOCATIONS[i]);
            }

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_YEAR.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_YEAR[i], FILTER_SETTINGS_SELECTED_YEAR[i]);
            }

           
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_MISSING.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_MISSING[i], FILTER_SETTINGS_SELECTED_MISSING[i]);
            }
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_CATEGORIES.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_CATEGORIES[i], FILTER_SETTINGS_SELECTED_CATEGORIES[i]);
            }
            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);
            string count = "";
            foreach (DataRow row in resultTable.Rows)
            {
                count = row["count"].ToString();
            }

            labelTotalCountOfAssets.Text = count;
            databaseConnection.CloseConnection();
        }
        
        public void GetAssetCondition()
        {
            chartAssetByCondition.Series.Clear();
            Series assetCategoriesSeries = new Series("Assets");
            assetCategoriesSeries.ChartType = SeriesChartType.Column;
            chartAssetByCondition.Series.Add(assetCategoriesSeries);

            string query = "SELECT A.assetCondition, COUNT(A.assetId) AS Count " +
                "FROM Assets A ";

            bool hasWhereClause = false; 

            if (FILTER_SETTINGS_SELECTED_LOCATIONS.Count > 0)
            {
                query += "WHERE A.assetLocation IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_LOCATIONS.Select(_ => "@" + (_.Contains('-') ? _.Split('-')[0] : _))) + ")";
                hasWhereClause = true; 
            }

            if (FILTER_SETTINGS_SELECTED_YEAR.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE "; 
                query += " YEAR(A.assetAcknowledgeDate) IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_YEAR.Select(y => "@" + y)) + ")";
            }

            
            if (FILTER_SETTINGS_SELECTED_CONDITION.Count == 2)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " assetCondition IN ('NON-SERVICEABLE', 'SERVICEABLE')";
                hasWhereClause = true;

            }
            else if (FILTER_SETTINGS_SELECTED_CONDITION.Count == 1)
            {
                if (FILTER_SETTINGS_SELECTED_CONDITION[0].Equals("NON-SERVICEABLE"))
                {
                    query += hasWhereClause ? " AND " : " WHERE ";
                    query += " assetCondition IN ('NON-SERVICEABLE')";
                    hasWhereClause = true;
                }
                else
                {
                    query += hasWhereClause ? " AND " : " WHERE ";
                    query += " assetCondition IN ('SERVICEABLE')";
                    hasWhereClause = true;

                }

            }
            if (FILTER_SETTINGS_SELECTED_MISSING.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " assetIsMissing IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_MISSING.Select(m => "@" + m)) + ")";
            }
            if (FILTER_SETTINGS_SELECTED_CATEGORIES.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " A.assetCategoryID IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_CATEGORIES.Select(y => "@" + y)) + ")";
            }
            query += " GROUP BY A.assetCondition";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_LOCATIONS.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_LOCATIONS[i].Split('-')[0], FILTER_SETTINGS_SELECTED_LOCATIONS[i]);
            }

            
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_YEAR.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_YEAR[i], FILTER_SETTINGS_SELECTED_YEAR[i]);
            }

            
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_MISSING.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_MISSING[i], FILTER_SETTINGS_SELECTED_MISSING[i]);
            }
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_CATEGORIES.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_CATEGORIES[i], FILTER_SETTINGS_SELECTED_CATEGORIES[i]);
            }
            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            chartAssetByCondition.Series["Assets"].Points.Clear();

            if (resultTable.Rows.Count == 0)
            {
                chartEmptyRecordLabelCondition.Visible = true;
            }
            else
            {
                chartEmptyRecordLabelCondition.Visible = false;
            }
            foreach (DataRow row in resultTable.Rows)
            {
                string condition = row["assetCondition"].ToString();
                int count = Convert.ToInt32(row["Count"]);
                

                chartAssetByCondition.Series["Assets"].Points.AddXY(condition, count);
            }



        }

        public void GetTotalPurchaseAmount()
        {
            string query = "SELECT SUM(A.assetPurchaseAmount) AS TotalPurchaseAmount " +
               "FROM Assets A ";

            bool hasWhereClause = false; 

            if (FILTER_SETTINGS_SELECTED_LOCATIONS.Count > 0)
            {
                query += "WHERE A.assetLocation IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_LOCATIONS.Select(_ => "@" + (_.Contains('-') ? _.Split('-')[0] : _))) + ")";
                hasWhereClause = true; 
            }

            if (FILTER_SETTINGS_SELECTED_YEAR.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE "; 
                query += " YEAR(A.assetAcknowledgeDate) IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_YEAR.Select(y => "@" + y)) + ")";
            }

            if (FILTER_SETTINGS_SELECTED_CONDITION.Count == 2)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " assetCondition IN ('NON-SERVICEABLE', 'SERVICEABLE')";
                hasWhereClause = true;

            }
            else if (FILTER_SETTINGS_SELECTED_CONDITION.Count == 1)
            {
                if (FILTER_SETTINGS_SELECTED_CONDITION[0].Equals("NON-SERVICEABLE"))
                {
                    query += hasWhereClause ? " AND " : " WHERE ";
                    query += " assetCondition IN ('NON-SERVICEABLE')";
                    hasWhereClause = true;
                }
                else
                {
                    query += hasWhereClause ? " AND " : " WHERE ";
                    query += " assetCondition IN ('SERVICEABLE')";
                    hasWhereClause = true;

                }

            }
            if (FILTER_SETTINGS_SELECTED_MISSING.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " assetIsMissing IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_MISSING.Select(m => "@" + m)) + ")";
            }
            if (FILTER_SETTINGS_SELECTED_CATEGORIES.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " A.assetCategoryID IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_CATEGORIES.Select(y => "@" + y)) + ")";
            }
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_LOCATIONS.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_LOCATIONS[i].Split('-')[0], FILTER_SETTINGS_SELECTED_LOCATIONS[i]);
            }

           
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_YEAR.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_YEAR[i], FILTER_SETTINGS_SELECTED_YEAR[i]);
            }

            
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_MISSING.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_MISSING[i], FILTER_SETTINGS_SELECTED_MISSING[i]);
            }

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_CATEGORIES.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_CATEGORIES[i], FILTER_SETTINGS_SELECTED_CATEGORIES[i]);
            }
            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            if(resultTable.Rows.Count > 0)
            {
                string totalPurchaseAmount = resultTable.Rows[0]["TotalPurchaseAmount"].ToString();

               
                if (decimal.TryParse(totalPurchaseAmount, out decimal purchaseAmount))
                {
                   
                    string formattedPurchaseAmount = purchaseAmount.ToString("#,##0");

                    textBoxPurhcaseAmountTotal.Text = formattedPurchaseAmount;
                }
            }
            
        }
        public void GetAssetMissing()
        {
            chartAssetMissing.Series.Clear();
            Series assetMissingSeries = new Series("Assets");
            assetMissingSeries.ChartType = SeriesChartType.Column;
            chartAssetMissing.Series.Add(assetMissingSeries);

            string query = "SELECT A.assetIsMissing, COUNT(A.assetId) AS Count " +
                           "FROM Assets A ";

            bool hasWhereClause = false;

            if (FILTER_SETTINGS_SELECTED_LOCATIONS.Count > 0)
            {
                query += "WHERE A.assetLocation IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_LOCATIONS.Select(_ => "@" + (_.Contains('-') ? _.Split('-')[0] : _))) + ")";
                hasWhereClause = true;
            }

            if (FILTER_SETTINGS_SELECTED_YEAR.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " YEAR(A.assetAcknowledgeDate) IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_YEAR.Select(y => "@" + y)) + ")";
            }

            
            if (FILTER_SETTINGS_SELECTED_MISSING.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " assetIsMissing IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_MISSING.Select(m => "@" + m)) + ")";
            }

            if (FILTER_SETTINGS_SELECTED_CATEGORIES.Count > 0)
            {
                query += hasWhereClause ? " AND " : " WHERE ";
                query += " A.assetCategoryID IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_CATEGORIES.Select(y => "@" + y)) + ")";
            }

            query += " GROUP BY A.assetIsMissing";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_LOCATIONS.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_LOCATIONS[i].Split('-')[0], FILTER_SETTINGS_SELECTED_LOCATIONS[i]);
            }

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_YEAR.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_YEAR[i], FILTER_SETTINGS_SELECTED_YEAR[i]);
            }

           
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_MISSING.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_MISSING[i], FILTER_SETTINGS_SELECTED_MISSING[i]);
            }

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_CATEGORIES.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_CATEGORIES[i], FILTER_SETTINGS_SELECTED_CATEGORIES[i]);
            }

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            chartAssetMissing.Series["Assets"].Points.Clear();

            if(resultTable.Rows.Count == 0)
            {
                chartEmptyRecordLabelMissing.Visible = true;  
            }
            else
            {
                chartEmptyRecordLabelMissing.Visible = false;
            }
            foreach (DataRow row in resultTable.Rows)
            {
                bool isMissing = Convert.ToBoolean(row["assetIsMissing"]);
                int count = Convert.ToInt32(row["Count"]);
                Console.WriteLine("missing: "+count);
                string label = isMissing ? "Missing" : "Not Missing";
               
                chartAssetMissing.Series["Assets"].Points.AddXY(label, count);
            }

        }

        public void GetAssets()
        {
            dataGridViewAssetRecords.DataSource = null;

            DataTable dataTable = FetchDataFromDB();

            dataGridViewAssetRecords.AutoGenerateColumns = false;


            foreach (DataColumn column in dataTable.Columns)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = column.ColumnName;
                col.Name = column.ColumnName;
                //col.HeaderText = column.ColumnName;
                switch (column.ColumnName)
                {
                    case "assetId":
                        col.HeaderText = "Asset ID";
                        break;
                    case "assetName":
                        col.HeaderText = "Asset Name";
                        break;
                    case "AAdminFullName":
                        col.HeaderText = "Administrator Name";
                        col.Visible = false;
                        break;
                    case "currentCustodianCoordinatorFullName":
                        col.HeaderText = "Current Custodian Name";
                        col.Visible = false;
                        break;
                    case "Supplier":
                        col.HeaderText = "Supplier Name";
                        col.Visible = false;
                        break;
                    case "Asset Category":
                        col.HeaderText = "Asset Category";
                        col.Visible = false;
                        break;

                    case "assetCondition":
                        col.HeaderText = "Asset Condition";
                        break;
                  

                    case "assetQrCodeImage":
                        col.HeaderText = "QR Code Image";
                        col.Visible = false;
                        break;
                    case "assetQrStrDefinition":
                        col.HeaderText = "";
                        col.Visible = false;

                        break;
                    case "assetLocation":
                        col.HeaderText = "Asset Location";
                        col.Visible = false;
                        break;
                    case "assetAcknowledgeDate":
                        col.HeaderText = "Acknowledge Date";
                        break;
                    case "assetPurchaseAmount":
                        col.HeaderText = "Purchase Amount";
                        break;
                    case "assetQuantity":
                        col.HeaderText = "Asset Quantity";
                        break;
                    case "assetUnit":
                        col.HeaderText = "Asset Unit";
                        break;


                    case "assetImage":
                        col.HeaderText = "Asset Image";

                        col.Visible = false;
                        break;

                    case "assetIsArchive":
                        col.HeaderText = "";
                        col.Visible = false;

                        break;

                    case "assetIsMissing":
                        col.HeaderText = "";
                        col.Visible = false;
                        break;

                    case "assetIsMaintainable":
                        col.HeaderText = "Is Maintainable";
                        col.Visible = false;
                        break;
              
                    case "assetPurpose":
                        col.HeaderText = "Asset Purpose";
                        col.Visible = false;
                        break;
                    case "assetDescription":
                        col.HeaderText = "Asset Description";
                        col.Visible = false;
                        break;
                    case "assetPropertyNumber":
                        col.HeaderText = "Asset PropertyNumber";
                        break;
                    default:
                        col.HeaderText = column.ColumnName;
                        break;
                }

                col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewAssetRecords.Font).Width ;

                dataGridViewAssetRecords.Columns.Add(col);
            }
            dataGridViewAssetRecords.ScrollBars = ScrollBars.Both;
            dataGridViewAssetRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewAssetRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGridViewAssetRecords.DataSource = FetchDataFromDB();

            dataGridViewAssetRecords.ScrollBars = ScrollBars.Both;
            dataGridViewAssetRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewAssetRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        private DataTable FetchDataFromDB()
        {
            string query = "SELECT A.assetId, " +
                           "       A.assetPropertyNumber, A.assetName, " +
                           "       CONCAT(AAdmin.FName, ' ', AAdmin.MName, ' ', AAdmin.LName, '; ', AAdmin.Id) AS AAdminFullName, " +
                           "       CONCAT(ACoor.FName, ' ', ACoor.MName, ' ', ACoor.LName, '; ', ACoor.Id) AS currentCustodianCoordinatorFullName, " +
                           "       CONCAT(Supplier.supplierName, '; ',  Supplier.supplierID) AS Supplier, " +
                           "       CONCAT(ACategory.assetCategoryName, '; ', ACategory.assetCategoryID) AS AssetCategory, " +
                           "       A.assetQrCodeImage, A.assetQrStrDefinition, A.assetLocation, A.assetAcknowledgeDate, A.assetPurchaseAmount, " +
                           "       A.assetQuantity, A.assetUnit, A.assetImage, A.assetIsArchive, A.assetIsMaintainable," +
                           "       A.assetIsMissing, A.assetPurpose, A.assetDescription, A.assetCondition " +
                           "FROM Assets A " +
                           "LEFT JOIN AssetAdministrator AAdmin ON  A.assetAdminID = AAdmin.Id  " +
                           "LEFT JOIN AssetCoordinator ACoor ON A.currentCustodianAssetCoordID = ACoor.Id " +
                           "LEFT JOIN Supplier ON A.supplierID = Supplier.supplierID " +
                           "LEFT JOIN AssetCategory ACategory ON A.assetCategoryID = ACategory.assetCategoryID "+
                           "WHERE 1 = 1";
            if (FILTER_SETTINGS_SELECTED_LOCATIONS.Count > 0)
            {
                query += " AND A.assetLocation IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_LOCATIONS.Select(_ => "@" + (_.Contains('-') ? _.Split('-')[0] : _))) + ")";
            }

            if (FILTER_SETTINGS_SELECTED_YEAR.Count > 0)
            {
                query += " AND YEAR(A.assetAcknowledgeDate) IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_YEAR.Select(y => "@" + y)) + ")";
            }

            if (FILTER_SETTINGS_SELECTED_CONDITION.Count == 2)
            {
                query += " AND A.assetCondition IN ('NON-SERVICEABLE', 'SERVICEABLE')";
            }
            else if (FILTER_SETTINGS_SELECTED_CONDITION.Count == 1)
            {
                if (FILTER_SETTINGS_SELECTED_CONDITION[0].Equals("NON-SERVICEABLE"))
                {
                    query += " AND A.assetCondition IN ('NON-SERVICEABLE')";
                }
                else
                {
                    query += " AND A.assetCondition IN ('SERVICEABLE')";
                }
            }

            if (FILTER_SETTINGS_SELECTED_MISSING.Count > 0)
            {
                query += " AND A.assetIsMissing IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_MISSING.Select(m => "@" + m)) + ")";
            }

            if (FILTER_SETTINGS_SELECTED_CATEGORIES.Count > 0)
            {
                query += " AND A.assetCategoryID IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_CATEGORIES.Select(y => "@" + y)) + ")";
            }
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
               
            };
            for (int i = 0; i < FILTER_SETTINGS_SELECTED_LOCATIONS.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_LOCATIONS[i].Split('-')[0], FILTER_SETTINGS_SELECTED_LOCATIONS[i]);
            }

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_YEAR.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_YEAR[i], FILTER_SETTINGS_SELECTED_YEAR[i]);
            }


            for (int i = 0; i < FILTER_SETTINGS_SELECTED_MISSING.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_MISSING[i], FILTER_SETTINGS_SELECTED_MISSING[i]);
            }

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_CATEGORIES.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_CATEGORIES[i], FILTER_SETTINGS_SELECTED_CATEGORIES[i]);
            }
            

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);
            if(resultTable.Rows.Count == 0)
            {
                datagridviewEmptyLabel.Visible = true;
            }
            else
            {
                datagridviewEmptyLabel.Visible = false;
            }

            databaseConnection.CloseConnection();

            return resultTable;
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            FILTER_SETTINGS_SELECTED_LOCATIONS.Clear();
            FILTER_SETTINGS_SELECTED_YEAR.Clear();
            FILTER_SETTINGS_SELECTED_CONDITION.Clear();
            FILTER_SETTINGS_SELECTED_MISSING.Clear();
            FILTER_SETTINGS_SELECTED_CATEGORIES.Clear();
            textBoxPurhcaseAmountTotal.Text = "0";

            if (checkBoxGSO.Checked) 
            {
                FILTER_SETTINGS_SELECTED_LOCATIONS.Add(checkBoxGSO.Text);
            }
            if (checkBoxMHO.Checked)
            {
                FILTER_SETTINGS_SELECTED_LOCATIONS.Add(checkBoxMHO.Text);
            }
            if (checkBoxMCR.Checked)
            {
                FILTER_SETTINGS_SELECTED_LOCATIONS.Add(checkBoxMCR.Text);
            }
            if (checkBoxMEO.Checked)
            {
                FILTER_SETTINGS_SELECTED_LOCATIONS.Add(checkBoxMEO.Text);
            }
            if (checkBoxMBO.Checked)
            {
                FILTER_SETTINGS_SELECTED_LOCATIONS.Add(checkBoxMBO.Text);
            }
            if (checkBoxAO.Checked)
            {
                FILTER_SETTINGS_SELECTED_LOCATIONS.Add(checkBoxAO.Text);
            }

            if (checkBox2023.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2023.Text);
            }
            if (checkBox2022.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2022.Text);
            }
            if (checkBox2021.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2021.Text);
            }
            if (checkBox2020.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2020.Text);
            }
            if (checkBox2019.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2019.Text);
            }
            if (checkBox2018.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2018.Text);
            }
            if (checkBox2017.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2017.Text);
            }
            if (checkBox2016.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2016.Text);
            }
            if (checkBox2015.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2015.Text);
            }
            if (checkBox2014.Checked)
            {
                FILTER_SETTINGS_SELECTED_YEAR.Add(checkBox2014.Text);
            }

            if (checkBoxServiceable.Checked)
            {
                FILTER_SETTINGS_SELECTED_CONDITION.Add("SERVICEABLE");
            }
            if (checkBoxNonServiceable.Checked)
            {
                FILTER_SETTINGS_SELECTED_CONDITION.Add("NON-SERVICEABLE");
            }
            if (checkBoxNotMissing.Checked)
            {
                FILTER_SETTINGS_SELECTED_MISSING.Add(false);
            }
            if (checkBoxMissing.Checked)
            {
                FILTER_SETTINGS_SELECTED_MISSING.Add(true);
            }

            foreach (CheckBox checkBox in FILTER_DYNAMIC_CATEGORIES)
            {
                if (checkBox.Checked)
                {
                    FILTER_SETTINGS_SELECTED_CATEGORIES.Add(checkBox.Name);
                    Console.WriteLine("CHECKED: " + checkBox.Name);
                }
                
            }


            JohnLloydPileTheSetToDefaultMethod(FILTER_OFFICES_CHECKBOXES);
            JohnLloydPileTheSetToDefaultMethod(FILTER_YEAR_CHECKBOXES);
            JohnLloydPileTheSetToDefaultMethod(FILTER_CONDITIONS_CHECKBOXES);
            JohnLloydPileTheSetToDefaultMethod(FILTER_GHOSTMISSING_CHECKBOXES);
            JohnLloydPileTheSetToDefaultMethod(FILTER_DYNAMIC_CATEGORIES);

            GetTotalAsset();
            GetAssetCondition();
            GetTotalPurchaseAmount();
            GetAssetMissing();
            GetAssets();
        }

        private void panelMainReport_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
