using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels
{
    public partial class OperatorHandledAssetPanel : UserControl
    {
        Control panelControl;
        string operatorId;
        Control[] controls;
        private DatabaseConnection databaseConnection;
        public OperatorHandledAssetPanel(Control _panelControl, string _operatorId, string name, Control[] _controls)
        {
            InitializeComponent();
            panelControl = _panelControl;
            operatorId = _operatorId;
            databaseConnection = new DatabaseConnection();
            labelOperatorName.Text = name;
            controls = _controls;

            Populate();
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
                           "WHERE ACoor.Id = @id AND A.assetIsArchive = " + bit + " AND A.assetIsMissing = 0 ";
         
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", operatorId}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }

        private void Populate()
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


         

        }

        private void buttonExitPanel_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            panelControl.Visible = false;

            Utilities.SetControlsVisibilityState(controls, true);
        }
    }
}
