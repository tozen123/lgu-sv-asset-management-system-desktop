using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.TransferPanel
{
    public partial class AssetTransferLogPanel : UserControl
    {
        Panel panelHandlerParent;
        Asset asset;
        User currentUser;

        private DatabaseConnection databaseConnection;
        public AssetTransferLogPanel(Panel _panelHandler, Asset _asset, User _currentUser)
        {
            InitializeComponent();
            asset = _asset;
            panelHandlerParent = _panelHandler;
            currentUser = _currentUser;
            Console.WriteLine("AssetTransferLogPanel: " + currentUser.GetStringAccessLevel());

            databaseConnection = new DatabaseConnection();

            SetData();

        }

        private void SetData()
        {
            labelAssetIdWithName.Text = "Transfer Logs: " + asset.AssetId + "-" + asset.AssetName;

            dataGridViewTransferLogs.DataSource = null;
            dataGridViewTransferLogs.Columns.Clear();

            DataTable dataTable = FetchDataFromDB();
            dataGridViewTransferLogs.AutoGenerateColumns = false;
            foreach (DataColumn column in dataTable.Columns)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = column.ColumnName;
                col.Name = column.ColumnName;

                switch (column.ColumnName)
                {
                    case "Id":
                        col.HeaderText = "Transfer Log ID";
                        break;
                    case "assetName":
                        col.HeaderText = "Asset Name";
                        break;
                    case "assetPropertyNumber":
                        col.HeaderText = "Asset Property Number";
                        break;
                    case "assetAdminTransferer":
                        col.HeaderText = "Name of the Administrator";
                        break;
                    case "assetCoordReceiver":
                        col.HeaderText = "Received By Custodian/Coordinator Name:";
                        break;
                    case "date":
                        col.HeaderText = "Transfer Date";
                        break;
                    case "supportingDocumentImage":
                        col.HeaderText = "Document Image";
                        col.Visible = false;
                        break;
                    case "previousOffice":
                        col.HeaderText = "Previous Office";
                        break;
                    default:
                        col.HeaderText = column.ColumnName;
                        break;
                }

                //col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewMaintenanceLogs.Font).Width + 35;

                dataGridViewTransferLogs.Columns.Add(col);
            }

            if (dataGridViewTransferLogs.Columns["View Document"] == null)
            {

               
                var viewButtonColumn = new DataGridViewButtonColumn();
                viewButtonColumn.HeaderText = "Actions";
                viewButtonColumn.Text = "View Document";
                viewButtonColumn.Name = "ViewDocumentColumn";
                viewButtonColumn.UseColumnTextForButtonValue = true;

               
                dataGridViewTransferLogs.Columns.Add(viewButtonColumn);

            
                viewButtonColumn.DisplayIndex = dataGridViewTransferLogs.Columns.Count - 1;
            }


            dataGridViewTransferLogs.DataSource = FetchDataFromDB();


        }
        private DataTable FetchDataFromDB()
        {
            /*string query = "SELECT Id, assetId, assetAdminTransfererId, assetCoordReceiverId, date, previousOffice," +
            "supportingDocumentImage FROM TransferLog WHERE assetId = @selectedAssetId";*/

            string query = @"
                            SELECT
                                tl.Id,
                                a.assetName,
                                a.assetPropertyNumber,
                                aaTransferer.FName + ' ' + aaTransferer.MName + ' ' + aaTransferer.LName AS assetAdminTransferer,
                                acReceiver.FName + ' ' + acReceiver.MName + ' ' + acReceiver.LName AS assetCoordReceiver,
                                tl.date,
                                tl.previousOffice,
                                tl.supportingDocumentImage
                            FROM
                                TransferLog tl
                            JOIN
                                Assets a ON tl.assetId = a.assetId
                            JOIN
                                AssetAdministrator aaTransferer ON tl.assetAdminTransfererId = aaTransferer.Id
                            JOIN
                                AssetCoordinator acReceiver ON tl.assetCoordReceiverId = acReceiver.Id
                            WHERE
                                tl.assetId = @selectedAssetId";



            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@selectedAssetId", asset.AssetId}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {

            panelHandlerParent.Controls.Clear();
            panelHandlerParent.SendToBack();
            panelHandlerParent.Visible = false;
        }
    }
}
