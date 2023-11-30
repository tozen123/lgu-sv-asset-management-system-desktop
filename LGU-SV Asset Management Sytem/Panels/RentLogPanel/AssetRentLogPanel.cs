using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.RentLogPanel
{
    public partial class AssetRentLogPanel : UserControl
    {
        Panel panelHandlerParent;
        Asset asset;
        User currentUser;
        private DatabaseConnection databaseConnection;
        public AssetRentLogPanel(Panel _panelHandler, Asset _asset, User _currentUser)
        {
            InitializeComponent();
            asset = _asset;
            panelHandlerParent = _panelHandler;
            currentUser = _currentUser;
            Console.WriteLine("AssetTransferLogPanel: " + currentUser.GetStringAccessLevel());
            databaseConnection = new DatabaseConnection();

            SetData();
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewRentLogPanel.DataSource = null;
            dataGridViewRentLogPanel.Columns.Clear();


            DataTable dataTable = FetchDataFromDB();
            dataGridViewRentLogPanel.AutoGenerateColumns = false;
            foreach (DataColumn column in dataTable.Columns)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = column.ColumnName;
                col.Name = column.ColumnName;

                switch (column.ColumnName)
                {
                    case "rentId":
                        col.HeaderText = "Rent Log ID";
                        break;
                    case "assetName":
                        col.HeaderText = "Asset Name";
                        break;
                    case "assetPropertyNumber":
                        col.HeaderText = "Asset Property Number";
                        break;
                    case "renteeFullName":
                        col.HeaderText = "Rentee Full Name";
                        break;
                    case "renteeAddress":
                        col.HeaderText = "Rentee Address";
                        break;
                    case "renteeContactNumber":
                        col.HeaderText = "Rentee Contact Number";
                        break;
                    case "assetId":
                        col.Visible = false;
                        break;
                    case "rentInitiatedDate":
                        col.HeaderText = "Rent Start Date";
                        break;
                    case "rentReturnDate":
                        col.HeaderText = "Rent Returned Date";
                        col.DefaultCellStyle.NullValue = "Not Returned";
                        break;
                    default:
                        col.HeaderText = column.ColumnName;
                        break;
                }

                //col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewMaintenanceLogs.Font).Width + 35;

                dataGridViewRentLogPanel.Columns.Add(col);
            }

            if (dataGridViewRentLogPanel.Columns["Track Rent"] == null)
            {

                // Create a new DataGridViewButtonColumn
                var trackRentColumn = new DataGridViewButtonColumn();
                trackRentColumn.HeaderText = "Actions";
                trackRentColumn.Text = "Track Rent";
                trackRentColumn.Name = "TrackRentColumn";
                trackRentColumn.UseColumnTextForButtonValue = true;

                // Add the button column to the DataGridView
                dataGridViewRentLogPanel.Columns.Add(trackRentColumn);

                // Adjust the button column's display index to make it the last column
                trackRentColumn.DisplayIndex = dataGridViewRentLogPanel.Columns.Count - 1;
            }


            dataGridViewRentLogPanel.DataSource = FetchDataFromDB();
        }
        private DataTable FetchDataFromDB()
        {
            /*string query = "SELECT Id, assetId, assetAdminTransfererId, assetCoordReceiverId, date, previousOffice," +
            "supportingDocumentImage FROM TransferLog WHERE assetId = @selectedAssetId";*/

            string query = @"
                            SELECT
                                rl.rentId,
                                a.assetName,
                                a.assetPropertyNumber,
                                rl.assetId,
                                CONCAT(rl.renteeFirstName, ' ', rl.renteeMidName, ' ', rl.renteeLastName) AS renteeFullName,
                                rl.renteeAddress,
                                rl.renteeContactNumber, 
                                rl.rentInitiatedDate, 
                                rl.rentReturnDate
                            FROM
                                RentLog rl
                            JOIN
                                Assets a ON rl.assetId = a.assetId
                            WHERE
                                rl.assetId = @selectedAssetId
                        ";

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
            labelAssetIdWithName.Text = "Rent Logs: " + asset.AssetId + "-" + asset.AssetName;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

            panelHandlerParent.Controls.Clear();
            panelHandlerParent.SendToBack();
            panelHandlerParent.Visible = false;
        }

        private void dataGridViewRentLogPanel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewRentLogPanel.Rows[e.RowIndex];

                if (e.ColumnIndex == dataGridViewRentLogPanel.Columns["TrackRentColumn"].Index)
                {
                    RentTrackerForm form = new RentTrackerForm();
                    form.SetRentID(Convert.ToInt32(selectedRow.Cells["rentId"].Value));
                    form.SetAssetID(Convert.ToInt32(selectedRow.Cells["assetId"].Value));
                    form.Initialize();
                    form.ShowDialog();

                }
            }

        }
    }
}
