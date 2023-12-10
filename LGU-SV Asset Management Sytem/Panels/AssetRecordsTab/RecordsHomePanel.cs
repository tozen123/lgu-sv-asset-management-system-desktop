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

        User currentUser;
        public RecordsHomePanel(string _userLocation, Control _viewedAssetPanelHandler, User _currentUser)
        {
            databaseConnection = new DatabaseConnection();
            viewedAssetPanelHandler = _viewedAssetPanelHandler;
            currentUser = _currentUser;

            InitializeComponent();
            userLocation = _userLocation;
            InitializeRecords();

         

        }
        public DataGridView DataGridViewAssetRecords
        {
            get { return dataGridViewAssetRecords; }
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
                           "WHERE A.assetLocation = @uLocation ";
            /*
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
                           "WHERE A.assetLocation = @uLocation ";
            */
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@uLocation", userLocation}
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

                col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewAssetRecords.Font).Width + 90;

                dataGridViewAssetRecords.Columns.Add(col);
            }


            dataGridViewAssetRecords.DataSource = FetchDataFromDB(0);

            if (dataGridViewAssetRecords.Columns["ViewAsset"] == null)
            {
                var viewButtonColumn = new DataGridViewButtonColumn();
                viewButtonColumn.HeaderText = "Actions";
                viewButtonColumn.Text = "View";
                viewButtonColumn.Name = "ViewAsset";
                viewButtonColumn.UseColumnTextForButtonValue = true;
                viewButtonColumn.Width = 85;

                dataGridViewAssetRecords.Columns.Insert(0, viewButtonColumn);


                viewButtonColumn.DisplayIndex = 0;
            }

           

            Utilities.AutoResizeColumnsBasedOnHeaders(dataGridViewAssetRecords);


        }

        private void Records_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
            if (e.ColumnIndex == dataGridViewAssetRecords.Columns["ViewAsset"].Index)
            {
                
                e.CellStyle.BackColor = Color.FromArgb(48, 77, 46);
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

                    selectedAsset.AssetId = Convert.ToInt32(selectedRow.Cells["assetId"].Value);

                    selectedAsset.AssetSupervisorId = Convert.ToInt32(selectedRow.Cells["AAdminFullName"].Value.ToString().Split(';')[1].Trim());
                    selectedAsset.CurrentEmployeeId = Convert.ToInt32(selectedRow.Cells["currentCustodianCoordinatorFullName"].Value.ToString().Split(';')[1].Trim());

                    selectedAsset.SupplierId = Convert.ToInt32(selectedRow.Cells["Supplier"].Value.ToString().Split(';')[1].Trim());
                    selectedAsset.AssetCategoryId = Convert.ToInt32(selectedRow.Cells["AssetCategory"].Value.ToString().Split(';')[1].Trim());

                    selectedAsset.SupplierName = selectedRow.Cells["Supplier"].Value.ToString().Split(';')[0].Trim();
                    selectedAsset.EmployeeName = selectedRow.Cells["currentCustodianCoordinatorFullName"].Value.ToString().Split(';')[0].Trim();
                    selectedAsset.AssetCategoryName =selectedRow.Cells["AssetCategory"].Value.ToString().Split(';')[0].Trim();

                    /*
                 string assetLastMaintenanceValue = selectedRow.Cells["assetLastMaintenance"].Value.ToString();
                 if (assetLastMaintenanceValue != "")
                 {
                     selectedAsset.AssetLastMaintenanceID = Convert.ToInt32(assetLastMaintenanceValue);
                 }

                 selectedAsset.AssetAvailability = selectedRow.Cells["assetAvailability"].Value.ToString();

                 */
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
                    selectedAsset.AssetPurchaseDate = Convert.ToDateTime(selectedRow.Cells["assetAcknowledgeDate"].Value);
                    //selectedAsset.AssetMaintenanceLogsID = selectedRow.Cells["assetMaintenanceLogsID"].Value.ToString();
                    selectedAsset.AssetQuantity = Convert.ToInt32(selectedRow.Cells["assetQuantity"].Value);
                    selectedAsset.AssetUnit = selectedRow.Cells["assetUnit"].Value.ToString();
                    /*
                    selectedAsset.AssetLifeSpan = Convert.ToInt32(selectedRow.Cells["assetLifeSpan"].Value);
                    */
                    //added
                    selectedAsset.AssetPurpose = selectedRow.Cells["assetPurpose"].Value.ToString();
                    selectedAsset.AssetDescription = selectedRow.Cells["assetDescription"].Value.ToString();
                    selectedAsset.AssetPropertyNumber = Convert.ToInt32(selectedRow.Cells["assetPropertyNumber"].Value);

                    AssetViewedInformationPanel assetViewerInformationPanel = new AssetViewedInformationPanel(selectedAsset, this, viewedAssetPanelHandler, currentUser);

                    assetViewerInformationPanel.Size = viewedAssetPanelHandler.Size;

                    viewedAssetPanelHandler.Controls.Add(assetViewerInformationPanel);
                    viewedAssetPanelHandler.BringToFront();
                    viewedAssetPanelHandler.Visible = true;
                }
            }

        }

        private void RecordsHomePanel_Load(object sender, EventArgs e)
        {

        }
        private bool isToggled = false;
        List<string> FILTER_SETTINGS_SELECTED_YEAR = new List<string>();
        List<string> FILTER_SETTINGS_SELECTED_CONDITION = new List<string>();
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            isToggled = !isToggled;
            if (isToggled)
            {
                panelFilterSet.Visible = true;
            }
            else
            {
                panelFilterSet.Visible = false;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            FILTER_SETTINGS_SELECTED_YEAR.Clear();
            FILTER_SETTINGS_SELECTED_CONDITION.Clear();
            if (checkBoxServiceable.Checked)
            {
                FILTER_SETTINGS_SELECTED_CONDITION.Add("SERVICEABLE");
            }
            if (checkBoxNonServiceable.Checked)
            {
                FILTER_SETTINGS_SELECTED_CONDITION.Add("NON-SERVICEABLE");
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


            InitializeRecordsWithFilter();
        }
        private DataTable FetchDataFromDBWithFilter(int bit)
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
                           "WHERE A.assetLocation = @uLocation AND A.assetIsArchive = " + bit + " AND A.assetIsMissing = 0 AND assetCondition = 'SERVICEABLE'";
           

            if (FILTER_SETTINGS_SELECTED_YEAR.Count > 0)
            {
           
                query += " AND YEAR(A.assetAcknowledgeDate) IN (" + string.Join(",", FILTER_SETTINGS_SELECTED_YEAR.Select(y => "@" + y)) + ")";
               
            }


            if (FILTER_SETTINGS_SELECTED_CONDITION.Count == 2)
            {
               
                query += " AND assetCondition IN ('NON-SERVICEABLE', 'SERVICEABLE')";
          

            }
            else if (FILTER_SETTINGS_SELECTED_CONDITION.Count == 1)
            {
                if (FILTER_SETTINGS_SELECTED_CONDITION[0].Equals("NON-SERVICEABLE"))
                {
                    
                    query += " AND assetCondition IN ('NON-SERVICEABLE')";
                  
                }
                else
                {
               
                    query += " AND assetCondition IN ('SERVICEABLE')";
                    

                }

            }

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@uLocation", userLocation}
            };

            for (int i = 0; i < FILTER_SETTINGS_SELECTED_YEAR.Count; i++)
            {
                parameters.Add("@" + FILTER_SETTINGS_SELECTED_YEAR[i], FILTER_SETTINGS_SELECTED_YEAR[i]);
            }

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }
        public void InitializeRecordsWithFilter ()
        {
            dataGridViewAssetRecords.DataSource = null;
           
            DataTable dataTable = FetchDataFromDBWithFilter(0);

           


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

                col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewAssetRecords.Font).Width + 90;
                
                dataGridViewAssetRecords.Columns.Add(col);
            }


            dataGridViewAssetRecords.DataSource = FetchDataFromDBWithFilter(0);
            
            if (dataGridViewAssetRecords.Columns["ViewAsset"] == null)
            {
                var viewButtonColumn = new DataGridViewButtonColumn();
                viewButtonColumn.HeaderText = "Actions";
                viewButtonColumn.Text = "View";
                viewButtonColumn.Name = "ViewAsset";
                viewButtonColumn.UseColumnTextForButtonValue = true;
                viewButtonColumn.Width = 85;

                dataGridViewAssetRecords.Columns.Insert(0, viewButtonColumn);


                viewButtonColumn.DisplayIndex = 0;
            }

           

            Utilities.AutoResizeColumnsBasedOnHeaders(dataGridViewAssetRecords);


        }
    }
}
