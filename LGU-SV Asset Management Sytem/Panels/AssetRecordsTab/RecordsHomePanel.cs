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
                   "       CONCAT(ASupervisor.assetSupervisorFName, ' ', ASupervisor.assetSupervisorMName, ' ', ASupervisor.assetSupervisorLName) AS assetSupervisorFullName, " +
                   "       CONCAT(AEmployee.AssetEmployeeFName, ' ', AEmployee.AssetEmployeeMName, ' ', AEmployee.AssetEmployeeLName) AS currentAssetEmployeeFullName, " +
                   "       Supplier.supplierName, " +
                   "       ACategory.assetCategoryName, " +
                   "       A.assetName, A.assetCondition, A.assetAvailability, " +
                   "       A.assetQrCodeImage, A.assetLocation, A.assetPurchaseDate, A.assetPurchaseAmount, " +
                   "       A.assetQuantity, A.assetUnit, A.assetIsMaintainable, A.assetLifeSpan " +
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
                col.HeaderText = column.ColumnName;

               
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
                if (e.ColumnIndex == dataGridViewAssetRecords.Columns["ViewAsset"].Index)
                {
                   
                    DataGridViewRow selectedRow = dataGridViewAssetRecords.Rows[e.RowIndex];
                    Asset selectedAsset = new Asset();

                  
                    AssetViewedInformationPanel assetViewerInformationPanel = new AssetViewedInformationPanel(selectedAsset, viewedAssetPanelHandler);
                    viewedAssetPanelHandler.Controls.Add(assetViewerInformationPanel);
                    viewedAssetPanelHandler.BringToFront();
                    viewedAssetPanelHandler.Visible = true;
                }
            }

        }
    }
}
