using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LGU_SV_Asset_Management_Sytem.Asset;

namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
   
    public partial class AddAssetBasedOnExistingDialog : Form
    {
        Control panelHandler;
        string supervisor_id;
        string supervisor_location;
        MainForm mainForm;

        AssetRepositoryControl assetRepositoryControl;

        private DatabaseConnection databaseConnection;
        public AddAssetBasedOnExistingDialog(Control _panelHandler, string _supervisor_id, string loc, MainForm _mainForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            mainForm = _mainForm;
            supervisor_id = _supervisor_id;
            supervisor_location = loc;
            panelHandler = _panelHandler;
            databaseConnection = new DatabaseConnection();

            assetRepositoryControl = new AssetRepositoryControl();

            InitializeRecords();
        }

        private DataTable FetchDataFromDB(int bit)
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
                           "WHERE A.assetLocation = @uLocation AND A.assetIsArchive = " + bit;
           
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@uLocation", mainForm.currentUserOffice}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }
        public void InitializeRecords()
        {
            dataGridViewAssetRecords.DataSource = null;

            DataTable dataTable = FetchDataFromDB(0);

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
                        col.Visible = false;
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

                col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewAssetRecords.Font).Width + 90;

                dataGridViewAssetRecords.Columns.Add(col);
            }


            dataGridViewAssetRecords.DataSource = FetchDataFromDB(0);
            if (dataGridViewAssetRecords.Columns["SelectAsset"] == null)
            {
                var selectAssetColumn = new DataGridViewButtonColumn();
                selectAssetColumn.HeaderText = "Actions";
                selectAssetColumn.Text = "Select";
                selectAssetColumn.Name = "SelectAsset";
                selectAssetColumn.UseColumnTextForButtonValue = true;
                selectAssetColumn.Width = 85;

                dataGridViewAssetRecords.Columns.Insert(0, selectAssetColumn);


                selectAssetColumn.DisplayIndex = 0;
            }
            Utilities.AutoResizeColumnsBasedOnHeaders(dataGridViewAssetRecords);


        }

        private void textBoxSearchAsset_TextChanged(object sender, EventArgs e)
        {
           

            string searchKeyword = textBoxSearchAsset.Text.Trim();

            DataTable dataTable = (DataTable)dataGridViewAssetRecords.DataSource;


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

        private void OpenAdder(Asset asset)
        {

            Control panelControl = new Panels.AssetRecordsTab.AddExistingAssetPanel(Panels.AssetRecordsTab.AddExistingAssetPanel.AssetType.Existing, supervisor_id, supervisor_location, panelHandler, mainForm, asset);
            panelControl.Size = panelHandler.Size;

            Utilities.PanelChanger(panelHandler, panelControl);

            mainForm.buttonSearch.Enabled = false;
            mainForm.textBoxSearchFilter.Enabled = false;
        }

        private void dataGridViewAssetRecords_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewAssetRecords.Rows[e.RowIndex];

                if (e.ColumnIndex == dataGridViewAssetRecords.Columns["SelectAsset"].Index)
                {
                    Asset selectedAsset = assetRepositoryControl.RetrieveAsset(Convert.ToInt32(selectedRow.Cells["assetId"].Value)).retrievedAsset;
                    OpenAdder(selectedAsset);
                    this.Close();
                }
            }
        }
    }
}
