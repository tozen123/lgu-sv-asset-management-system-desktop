using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{
    public partial class RecordsHomePanel : UserControl
    {
        private DatabaseConnection databaseConnection;
        string userLocation;
        Control viewedAssetPanelHandler;
        public RecordsHomePanel(string _userLocation, Control _viewedAssetPanelHandler)
        {
            databaseConnection = new DatabaseConnection();
            viewedAssetPanelHandler = _viewedAssetPanelHandler;

            InitializeComponent();
            userLocation = _userLocation;
            InitializeRecords();
           
        }


        private DataTable FetchDataFromDB()
        {
            string query = "SELECT A.assetId, " +
                   "       CONCAT(ASupervisor.assetSupervisorFName, ' ', ASupervisor.assetSupervisorMName, ' ', ASupervisor.assetSupervisorLName, '; ', ASupervisor.assetSupervisorID) AS assetSupervisorFullName, " +
                   "       CONCAT(AEmployee.AssetEmployeeFName, ' ', AEmployee.AssetEmployeeMName, ' ', AEmployee.AssetEmployeeLName, '; ', AEmployee.assetEmployeeID) AS currentAssetEmployeeFullName, " +
                   "       CONCAT(Supplier.supplierName, '; ',  Supplier.supplierID) AS Supplier, " +
                   "       CONCAT(ACategory.assetCategoryName, '; ', ACategory.assetCategoryID) AS AssetCategory, " +
                   "       A.assetName, A.assetCondition, A.assetAvailability, " +
                   "       A.assetQrCodeImage, A.assetQrStrDefinition, A.assetLocation, A.assetPurchaseDate, A.assetPurchaseAmount, " +
                   "       A.assetQuantity, A.assetUnit, A.assetImage, A.assetIsArchive, A.assetLastMaintenance, A.assetIsMaintainable," +
                   "       A.assetIsMissing, A.assetLifeSpan " +
                   "FROM Assets A " +
                   "LEFT JOIN AssetSupervisor ASupervisor ON A.assetSupervisorID = ASupervisor.assetSupervisorID " +
                   "LEFT JOIN AssetEmployee AEmployee ON A.currentAssetEmployeeID = AEmployee.assetEmployeeID " +
                   "LEFT JOIN Supplier ON A.supplierID = Supplier.supplierID " +
                   "LEFT JOIN AssetCategory ACategory ON A.assetCategoryID = ACategory.assetCategoryID " +
                   "WHERE A.assetLocation = @uLocation";


            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@uLocation", userLocation}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }

        private void InitializeRecords()
        {
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
                    case "assetSupervisorFullName":
                        col.HeaderText = "Supervisor Name";
                        break;
                    case "currentAssetEmployeeFullName":
                        col.HeaderText = "Current Employee Name";
                        break;
                    case "Supplier":
                        col.HeaderText = "Supplier Name";
                        break;
                    case "Asset Category":
                        col.HeaderText = "Asset Category";
                        break;
                    case "assetName":
                        col.HeaderText = "Asset Name";
                        break;
                    case "assetCondition":
                        col.HeaderText = "Asset Condition";
                        break; 
                    case "assetLastMaintenance":
                        col.HeaderText = "Asset Last Maintenance";
                        col.DefaultCellStyle.NullValue = "N/A";
                        break;
                    case "assetAvailability":
                        col.HeaderText = "Asset Availability";
                        break;
                    case "assetQrCodeImage":
                        col.HeaderText = "QR Code Image";
                        break;
                    case "assetQrStrDefinition":
                        col.HeaderText = "";
                        col.Visible = false;

                        break;
                    case "assetLocation":
                        col.HeaderText = "Asset Location";
                        break;
                    case "assetPurchaseDate":
                        col.HeaderText = "Purchase Date";
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
                    case "assetLifeSpan":
                        col.HeaderText = "Asset Life Span (Years)";
                        break;
                    default:
                        col.HeaderText = column.ColumnName;
                        break;
                }

                col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewAssetRecords.Font).Width + 24;

                dataGridViewAssetRecords.Columns.Add(col);
            }


            dataGridViewAssetRecords.DataSource = FetchDataFromDB();

            if (dataGridViewAssetRecords.Columns["ViewAsset"] == null)
            {
                var viewButtonColumn = new DataGridViewButtonColumn();
                viewButtonColumn.HeaderText = "Actions";
                viewButtonColumn.Text = "View";
                viewButtonColumn.Name = "ViewAsset";
                viewButtonColumn.UseColumnTextForButtonValue = true;
                viewButtonColumn.Width = 50;
                dataGridViewAssetRecords.Columns.Insert(0, viewButtonColumn);


                viewButtonColumn.DisplayIndex = 0;
            }


            AutoResizeColumnsBasedOnHeaders(dataGridViewAssetRecords);


        }
        private void AutoResizeColumnsBasedOnHeaders(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }

        private void dataGridViewAssetRecords_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewAssetRecords.Rows[e.RowIndex];

                if (e.ColumnIndex == dataGridViewAssetRecords.Columns["ViewAsset"].Index)
                {
                    Asset selectedAsset = new Asset();

                    foreach (var item in dataGridViewAssetRecords.Columns)
                    {
                        Console.WriteLine(item.ToString());
                    }


                    selectedAsset.AssetId = Convert.ToInt32(selectedRow.Cells["assetId"].Value);

                    selectedAsset.AssetSupervisorId = Convert.ToInt32(selectedRow.Cells["assetSupervisorFullName"].Value.ToString().Split(';')[1].Trim());
                    selectedAsset.CurrentEmployeeId = Convert.ToInt32(selectedRow.Cells["currentAssetEmployeeFullName"].Value.ToString().Split(';')[1].Trim());
                    selectedAsset.SupplierId = Convert.ToInt32(selectedRow.Cells["Supplier"].Value.ToString().Split(';')[1].Trim());
                    selectedAsset.AssetCategoryId = Convert.ToInt32(selectedRow.Cells["AssetCategory"].Value.ToString().Split(';')[1].Trim());

                    string assetLastMaintenanceValue = selectedRow.Cells["assetLastMaintenance"].Value.ToString();
                    if (assetLastMaintenanceValue != "")
                    {
                        selectedAsset.AssetLastMaintenanceID = Convert.ToInt32(assetLastMaintenanceValue);
                    }
                    
                    selectedAsset.AssetAvailability = selectedRow.Cells["assetAvailability"].Value.ToString();
                    selectedAsset.AssetName = selectedRow.Cells["assetName"].Value.ToString();
                    selectedAsset.AssetLocation = selectedRow.Cells["assetLocation"].Value.ToString();

                    selectedAsset.QRCode = selectedRow.Cells["assetQrStrDefinition"].Value.ToString();

                    selectedAsset.AssetQRCodeImage = (byte[])selectedRow.Cells["assetQrCodeImage"].Value;
                    selectedAsset.AssetImage = (byte[])selectedRow.Cells["assetImage"].Value;

                    selectedAsset.AssetCondition = selectedRow.Cells["assetCondition"].Value.ToString();

                    selectedAsset.IsArchive = Convert.ToBoolean(selectedRow.Cells["assetIsArchive"].Value);
                    selectedAsset.IsMissing = Convert.ToBoolean(selectedRow.Cells["assetIsMissing"].Value);
                    selectedAsset.IsMaintainable = Convert.ToBoolean(selectedRow.Cells["assetIsMaintainable"].Value);

                    selectedAsset.AssetPurchaseAmount = Convert.ToDecimal(selectedRow.Cells["assetPurchaseAmount"].Value);
                    selectedAsset.AssetPurchaseDate = Convert.ToDateTime(selectedRow.Cells["assetPurchaseDate"].Value);
                    //selectedAsset.AssetMaintenanceLogsID = selectedRow.Cells["assetMaintenanceLogsID"].Value.ToString();
                    selectedAsset.AssetQuantity = Convert.ToInt32(selectedRow.Cells["assetQuantity"].Value);
                    selectedAsset.AssetUnit = selectedRow.Cells["assetUnit"].Value.ToString();
                    selectedAsset.AssetLifeSpan = Convert.ToInt32(selectedRow.Cells["assetLifeSpan"].Value);

                    AssetViewedInformationPanel assetViewerInformationPanel = new AssetViewedInformationPanel(selectedAsset, viewedAssetPanelHandler);
                    viewedAssetPanelHandler.Controls.Add(assetViewerInformationPanel);
                    viewedAssetPanelHandler.BringToFront();
                    viewedAssetPanelHandler.Visible = true;
                }
            }

        }
    }
}
