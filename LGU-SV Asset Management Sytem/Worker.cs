using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem
{
  

    // Worker class for Main Form
    
    public class Worker
    {

        private MainForm mainform;

        private DatabaseConnection databaseConnection;

        public Worker(MainForm form)
        {
            this.mainform = form;
            databaseConnection = new DatabaseConnection();


        }

        public void RunArchiveRecordsComponent(string user_location, string user_type)
        {
            mainform.dataGridViewArchiveRecords.Columns.Clear();

            DataTable dataTable = FetchDataFromDB(1, user_location);

            mainform.dataGridViewArchiveRecords.AutoGenerateColumns = false;
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
                        col.Visible = false;
                        break;
                    case "assetName":
                        col.HeaderText = "Asset Name";
                        break;
                    case "AAdminFullName":
                        col.HeaderText = "Administrator Name";
                        break;
                    case "currentCustodianCoordinatorFullName":
                        col.HeaderText = "Current Custodian Name";
                        break;
                    case "Supplier":
                        col.HeaderText = "Supplier Name";

                        break;
                    case "Asset Category":
                        col.HeaderText = "Asset Category";
                        break;

                    case "assetCondition":
                        col.HeaderText = "Asset Condition";
                        break;
                    /*
                    case "assetLastMaintenance":
                        col.HeaderText = "Asset Last Maintenance";
                        col.DefaultCellStyle.NullValue = "N/A";
                        break;
                    */

                    /*
                    case "assetAvailability":
                        col.HeaderText = "Asset Availability";
                        break;
                    */

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

                    case "ssetIsMissing":
                        col.HeaderText = "";
                        col.Visible = false;
                        break;

                    case "assetIsMaintainable":
                        col.HeaderText = "Is Maintainable";
                        break;
                    /*
                case "assetLifeSpan":
                    col.HeaderText = "Asset Life Span (Years)";
                    break;
                    */
                    case "assetPurpose":
                        col.HeaderText = "Asset Purpose";
                        break;
                    case "assetDescription":
                        col.HeaderText = "Asset Description";
                        break;
                    case "assetPropertyNumber":
                        col.HeaderText = "Asset PropertyNumber";
                        break;
                    default:
                        col.HeaderText = column.ColumnName;
                        break;
                }

                col.Width = TextRenderer.MeasureText(column.ColumnName, mainform.dataGridViewArchiveRecords.Font).Width + 90;

                mainform.dataGridViewArchiveRecords.Columns.Add(col);
            }

            mainform.dataGridViewArchiveRecords.DataSource = null; 
            mainform.dataGridViewArchiveRecords.Rows.Clear();

            mainform.dataGridViewArchiveRecords.DataSource = FetchDataFromDB(1, user_location);

            if (mainform.dataGridViewArchiveRecords.Columns["UnArchiveAsset"] == null)
            {
                if (user_type != "Asset Administrator")
                {
                    return;
                }

                // Create a new DataGridViewButtonColumn
                var unArchiveAssetColumn = new DataGridViewButtonColumn();
                unArchiveAssetColumn.HeaderText = "Actions";
                unArchiveAssetColumn.Text = "UNARCHIVE";
                unArchiveAssetColumn.Name = "UnArchiveAssetColumn";
                unArchiveAssetColumn.UseColumnTextForButtonValue = true;




                mainform.dataGridViewArchiveRecords.Columns.Insert(0, unArchiveAssetColumn);


                unArchiveAssetColumn.DisplayIndex = 0;


            }

            Utilities.AutoResizeColumnsBasedOnHeaders(mainform.dataGridViewArchiveRecords);

        }

        private DataTable FetchDataFromDB(int bit, string userLocation)
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
                           "LEFT JOIN AssetCategory ACategory ON A.assetCategoryID = ACategory.assetCategoryID " +
                           "WHERE A.assetLocation = @uLocation AND A.assetIsArchive = " + bit ;
 
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@uLocation", userLocation}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }

        public void ProcessUnarchiveAsset()
        {

        }
        public void PerformArchiveRecordSearch()
        {
            string searchKeyword = mainform.textBoxArchiveRecordsSearch.Text.Trim();

            DataTable dataTable = (DataTable)mainform.dataGridViewArchiveRecords.DataSource;

            if (!mainform.IsValidInput(searchKeyword))
            {
                return;
            }
            else
            {
                dataTable.DefaultView.RowFilter = string.Empty;
            }

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    string filterExpression = $"assetName LIKE '%{searchKeyword}%' OR assetPropertyNumber LIKE '%{searchKeyword}%'";


                    dataTable.DefaultView.RowFilter = filterExpression;
                }
                else
                {

                    dataTable.DefaultView.RowFilter = string.Empty;
                }
            }
        }
    }
}
