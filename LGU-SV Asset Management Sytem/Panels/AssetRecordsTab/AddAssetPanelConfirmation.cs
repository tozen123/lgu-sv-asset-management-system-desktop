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

    public partial class AddAssetPanelConfirmation : Form
    {

        List<Asset> list = new List<Asset>();
        int currentIndex;

        private DatabaseConnection databaseConnection;

        public AddAssetPanelConfirmation(List<Asset> assetToConfirmList)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            list = assetToConfirmList;

            databaseConnection = new DatabaseConnection();

            if(list.Count == 1)
            {
                buttonBackwardList.Visible = false;
                buttonForwardList.Visible = false;
            }

            LoadData(0);
        }

        public DialogResult GetResult()
        {
            return this.DialogResult;
        }
        private void LoadData(int indexLoad)
        {
            labelAssetName.Text = list[indexLoad].AssetName;
            labelAssetQuantity.Text = list[indexLoad].AssetQuantity.ToString();

            labelAssetUnit.Text = list[indexLoad].AssetUnit.ToString();

            // Fetch
            labelAssetCategory.Text = FetchAssetCategoryName(list[indexLoad].AssetCategoryId.ToString());


            labelAssetAvailability.Text = list[indexLoad].AssetAvailability.ToString();
            labelAssetCondition.Text = list[indexLoad].AssetCondition.ToString();
            labelAssetLocation.Text = list[indexLoad].AssetLocation.ToString();

            //Fetch
            labelAssetEmployee.Text = FetchAssetEmployeeName(list[indexLoad].CurrentEmployeeId.ToString());

            //Fetch
            labelAssetSupplier.Text = FetchAssetSupplierName(list[indexLoad].SupplierId.ToString());

            labelAssetPurchaseAmount.Text = list[indexLoad].AssetPurchaseAmount.ToString();
            labelAssetPurchaseDate.Text = list[indexLoad].AssetPurchaseDate.ToString();

            if (list[indexLoad].IsMaintainable)
            {
                labelMaintainable.Text = "YES";
            }
            else
            {
                labelMaintainable.Text = "NO";
            }
            

            labelLifeSpan.Text = list[indexLoad].AssetLifeSpan.ToString();
        }
        private string FetchAssetCategoryName(string _id)
        {
            string query = "SELECT assetCategoryName FROM AssetCategory WHERE assetCategoryId = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", _id}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string resultString = "";

            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {
                    resultString += row[col];
                }
            }

            return resultString;
        }

        private string FetchAssetEmployeeName(string _id)
        {
            string query = "SELECT assetEmployeeFName, assetEmployeeMName, assetEmployeeLName FROM AssetEmployee WHERE assetEmployeeId = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", _id}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string resultString = "";

            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {
                    resultString += row[col] + " ";
                }
            }

            return resultString;
        }

        private string FetchAssetSupplierName(string _id)
        {
            string query = "SELECT supplierName FROM Supplier WHERE supplierId = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", _id}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string resultString = "";

            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {
                    resultString += row[col];
                }
            }

            return resultString;
        }
        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonBackwardList_Click_1(object sender, EventArgs e)
        {
            currentIndex -= 1;
            if (currentIndex < 0)
            {
                currentIndex = 0;
                buttonBackwardList.Enabled = false;
                return;
            }
            buttonForwardList.Enabled = true;
            LoadData(currentIndex);
        }

        private void buttonForwardList_Click_1(object sender, EventArgs e)
        {
            currentIndex += 1;
            if (currentIndex >= list.Count)
            {
                currentIndex = list.Count - 1;
                buttonForwardList.Enabled = false;
                return;
            }
            buttonBackwardList.Enabled = true;
            LoadData(currentIndex);
        }

    }
}
