using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.MaintenancePanel
{
    public partial class AssetMaintenanceLogPanel : UserControl
    {
        Panel panelHandlerParent;
        Asset asset;
        User currentUser;

        private DatabaseConnection databaseConnection;

        public AssetMaintenanceLogPanel(Panel _panelHandler, Asset _asset, User _currentUser)
        {
            InitializeComponent();
            panelHandlerParent = _panelHandler;
            asset = _asset;
            currentUser = _currentUser;

            Console.WriteLine("AssetMaintenanceLogPanel: " + currentUser.GetStringAccessLevel());
            Console.WriteLine("AssetMaintenanceLogPanel: " + asset.AssetId);

            databaseConnection = new DatabaseConnection();

            
            SetData();

            SetAccessLevel();
            InitializeRecords();
        }

        // Only Employee can create new MaintenanceLogs

        private void SetAccessLevel()
        {

        }

        public void InitializeRecords()
        {
            
            dataGridViewMaintenanceLogs.DataSource = null;
            dataGridViewMaintenanceLogs.Columns.Clear();

            DataTable dataTable = FetchDataFromDB();
            dataGridViewMaintenanceLogs.AutoGenerateColumns = false;
            foreach (DataColumn column in dataTable.Columns)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = column.ColumnName;
                col.Name = column.ColumnName;

                switch (column.ColumnName)
                {
                    case "maintenanceLogId":
                        col.HeaderText = "Maintenance Log ID";
                        break;
                    case "assetId":
                        col.HeaderText = "Asset ID";
                        break;
                    case "assetEmployeeId":
                        col.HeaderText = "Current Employee ID";
                        break;
                    case "maintenanceDate":
                        col.HeaderText = "Maintenance Date";
                        break;
                    case "maintenanceDescription":
                        col.HeaderText = "Maintenance Description";
                        break;
                    case "maintenanceStatus":
                        col.HeaderText = "Maintenance Status";
                        break;
                    case "maintenanceCost":
                        col.HeaderText = "Maintenance Cost";
                        break;
                    case "maintenanceCategory":
                        col.HeaderText = "Maintenance Category";
                        break;
                    default:
                        col.HeaderText = column.ColumnName;
                        break;
                }

                //col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewMaintenanceLogs.Font).Width + 35;
                
                dataGridViewMaintenanceLogs.Columns.Add(col);
            }

            dataGridViewMaintenanceLogs.DataSource = FetchDataFromDB();
           

            //Utilities.AutoResizeColumnsBasedOnHeaders(dataGridViewMaintenanceLogs);
        }

        private DataTable FetchDataFromDB()
        {
            string query = "SELECT maintenanceLogId, assetId, assetEmployeeId, maintenanceDate, maintenanceDescription, " +
                "maintenanceStatus, maintenanceCost, maintenanceCategory FROM MaintenanceLog WHERE assetId = @selectedAssetId";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@selectedAssetId", asset.AssetId}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }

        private void SetData()
        {
            labelAssetIdWithName.Text = "Maintenance Logs: " + asset.AssetId + "-" + asset.AssetName;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ClearPanel(panelHandlerParent);
        }

        private void ClearPanel(Panel panelToClear)
        {
            panelToClear.Controls.Clear();
            panelToClear.SendToBack();
            panelToClear.Visible = false;
        }

        private void SwitchMiniPanelHandler(Control panelToSwitch)
        {
            if(panelLogMiniHandler.Controls.Count > 0)
            {
                ClearPanel(panelLogMiniHandler);
            }

            panelLogMiniHandler.Controls.Add(panelToSwitch);
            panelLogMiniHandler.BringToFront();
            panelLogMiniHandler.Visible = true;
        }

        private void buttonNewLog_Click(object sender, EventArgs e)
        {
            AddNewMaintenanceLogPanel addNewMaintenanceLogPanel = new AddNewMaintenanceLogPanel(panelLogMiniHandler, asset, currentUser, this);
            SwitchMiniPanelHandler(addNewMaintenanceLogPanel);
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            AddAssetSchedulePanel addAssetSchedulePanel = new AddAssetSchedulePanel(panelLogMiniHandler, asset);
            SwitchMiniPanelHandler(addAssetSchedulePanel);
        }

        private void AssetMaintenanceLogPanel_Load(object sender, EventArgs e)
        {

        }

      
    }
}
