using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LGU_SV_Asset_Management_Sytem.AssetMaintenanceLog;

namespace LGU_SV_Asset_Management_Sytem.Panels.MaintenancePanel
{
    public partial class AssetMaintenanceLogPanel : UserControl
    {
        Panel panelHandlerParent;
        Asset asset;
        User currentUser;

        AssetMaintenanceLogRepositoryControl assetMaintenanceLogRepositoryControl = new AssetMaintenanceLogRepositoryControl();
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

            if (dataGridViewMaintenanceLogs.Columns["DeleteButtonColumn"] == null)
            {
            
                // Create a new DataGridViewButtonColumn
                var deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.HeaderText = "Actions";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Name = "DeleteButtonColumn";
                deleteButtonColumn.UseColumnTextForButtonValue = true;

                // Add the button column to the DataGridView
                dataGridViewMaintenanceLogs.Columns.Add(deleteButtonColumn);

                // Adjust the button column's display index to make it the last column
                deleteButtonColumn.DisplayIndex = dataGridViewMaintenanceLogs.Columns.Count - 1;
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

        string assetId;
        private void dataGridViewMaintenanceLogs_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMaintenanceLogs.Rows[e.RowIndex];
                AssetMaintenanceLog selectedLog = new AssetMaintenanceLog();

                selectedLog.MaintenanceLogId = row.Cells[0].Value.ToString();
                selectedLog.AssetId = Convert.ToInt32(row.Cells[1].Value.ToString());
                selectedLog.AssetEmployeeId = row.Cells[2].Value.ToString();


                if (row.Cells[3].Value != null && DateTime.TryParse(row.Cells[3].Value.ToString(), out DateTime maintenanceDate))
                {
                    selectedLog.MaintenanceDate = maintenanceDate;
                }
                else
                {
                    selectedLog.MaintenanceDate = DateTime.MinValue; 
                }

                selectedLog.MaintenanceDescription = row.Cells[4].Value.ToString();
                selectedLog.MaintenanceStatus = row.Cells[5].Value.ToString();
                selectedLog.MaintenanceCost = Convert.ToDecimal(row.Cells[6].Value.ToString());
                selectedLog.MaintenanceCategory = row.Cells[7].Value.ToString();
           

                if (e.ColumnIndex == dataGridViewMaintenanceLogs.Columns["DeleteButtonColumn"].Index)
                {
                    assetId = row.Cells["maintenanceLogId"].Value.ToString();
                    Console.WriteLine("Action Delete for " + assetId);

                    if (!string.IsNullOrEmpty(assetId))
                    {
                        var result = assetMaintenanceLogRepositoryControl.DeleteToDatabase(selectedLog);

                        if (result.Success)
                        {

                            MessagePrompt($"Log has been successfully deleted");
                            InitializeRecords();
                        }
                        else
                        {
                            MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
                        }

                    }
                }
            }
        }

        private void MessagePrompt(string message)
        {
            DialogBoxes.MessagePromptDialogBox prompt = new DialogBoxes.MessagePromptDialogBox();
            prompt.SetMessage(message);
            prompt.Show();
        }

        private void textBoxMLogSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void buttonMLogPerfSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            string searchKeyword = textBoxMLogSearch.Text.Trim();

            DataTable dataTable = (DataTable)dataGridViewMaintenanceLogs.DataSource;

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                  
                    if (int.TryParse(searchKeyword, out _))
                    {
                     
                        string filterExpression = $"assetId = {searchKeyword}";
                        dataTable.DefaultView.RowFilter = filterExpression;
                    }
                    else
                    {

                        MessagePrompt("Please enter a valid number for the search.");
                    }
                }
                else
                {
                    
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
            }
        }

    }
}
