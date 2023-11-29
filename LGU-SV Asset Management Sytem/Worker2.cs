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
using static LGU_SV_Asset_Management_Sytem.AssetCoordinator;

namespace LGU_SV_Asset_Management_Sytem
{
    public class Worker2
    {
        private MainForm mainform;
        private DatabaseConnection databaseConnection;
        AssetRepositoryControl assetRepositoryControl;
        AssetCoordinatorRepositoryControl assetCoordinatorRepositoryControl;

        public Worker2(MainForm form)
        {
            this.mainform = form;
            databaseConnection = new DatabaseConnection();

            assetRepositoryControl = new AssetRepositoryControl();
            assetCoordinatorRepositoryControl = new AssetCoordinatorRepositoryControl();
        }

        public void LoadTransactionPanel()
        {
            //Controls

            //ComboBox
            ComboBoxRetriever(mainform.comboBoxTransactionTransferAssetCategory, "SELECT assetCategoryId, assetCategoryName FROM AssetCategory");

            // ListBox
            if(mainform.currentSessionUserType.Equals("Asset Administrator"))
            {
                DataGridViewRetriever(mainform.dataGridViewTransactionTransferAssetList, "SELECT assetName, assetPropertyNumber, assetId FROM Assets WHERE assetIsArchive = 0");
            }
            else if(mainform.currentSessionUserType.Equals("Asset Coordinator"))
            {
                DataGridViewRetriever(mainform.dataGridViewTransactionTransferAssetList, $"SELECT assetName, assetPropertyNumber, assetId FROM Assets WHERE assetIsArchive = 0 AND assetLocation = {mainform.currentUserOffice}");
            }



            //
            DataGridViewRetrieverCustodians(mainform.dataGridViewTransactionTransferReceiver, "SELECT Id, FName, MName, LName, Office FROM AssetCoordinator");
        }
        public void DataGridViewRetriever(DataGridView dataGridView, string query)
        {
            dataGridView.DataSource = null;

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);


            foreach (DataColumn column in resultTable.Columns)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = column.ColumnName;
                col.Name = column.ColumnName;

                switch (column.ColumnName)
                {
                    case "Id":
                        col.HeaderText = "Id";
                        break;
                    case "FName":
                        col.HeaderText = "First Name";
                        break;
                    case "MName":
                        col.HeaderText = "Middle Name";
                        break;
                    case "LName":
                        col.HeaderText = "Last Name";
                        break;
                    case "Office":
                        col.HeaderText = "Office";
                        break;
                }

                dataGridView.Columns.Add(col);
            }


            dataGridView.DataSource = resultTable;

            databaseConnection.CloseConnection();
        }
        public void DataGridViewRetrieverCustodians(DataGridView dataGridView, string query)
        {
            dataGridView.DataSource = null;

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);


            foreach (DataColumn column in resultTable.Columns)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = column.ColumnName;
                col.Name = column.ColumnName;

                switch (column.ColumnName)
                {
                    case "assetName":
                        col.HeaderText = "Name";
                        break;
                    case "assetPropertyNumber":
                        col.HeaderText = "Property Number";
                        break;
                    case "assetId":
                        col.HeaderText = "ID";
                        break;
                }

                dataGridView.Columns.Add(col);
            }


            dataGridView.DataSource = resultTable;

            databaseConnection.CloseConnection();
        }
        public void CategoryListApplyFilter()
        {
            if (mainform.comboBoxTransactionTransferAssetCategory.SelectedItem != null)
            {
                string selectedCategory = mainform.comboBoxTransactionTransferAssetCategory.SelectedItem.ToString().Split('|')[1].Trim();

                DataGridViewRetriever(mainform.dataGridViewTransactionTransferAssetList, $"SELECT assetName, assetPropertyNumber, assetId FROM Assets WHERE assetCategoryID = {selectedCategory}");
            }

        }
        int transactionSelectedAssetId;

        public void AssetSearchFilterClear()
        {

            DataGridViewRetriever(mainform.dataGridViewTransactionRentAsset, "SELECT assetName, assetPropertyNumber, assetId FROM Assets");

            if (mainform.comboBoxTransactionTransferAssetCategory.SelectedItem != null)
            {
                mainform.comboBoxTransactionTransferAssetCategory.SelectedItem = null;
            }

            mainform.textBoxTransactionTransferAssetName.Text = string.Empty;
            mainform.textBoxTransactionTransferAssetCustodian.Text = string.Empty;
            mainform.richTextBoxTransactionTransferAssetDescription.Text = string.Empty;
            mainform.richTextBoxrichTextBoxTransactionTransferAssetDescription.Text = string.Empty;

            mainform.pictureBoxTransactionTransferAssetImage.Image = LGU_SV_Asset_Management_Sytem.Properties.Resources.empty_image;

            transactionSelectedAssetId = 0;

        }

        public void ComboBoxRetriever(ComboBox combobox, string query)
        {
            combobox.Items.Clear();

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string result = "";
            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {

                    result += " | " + row[col].ToString();
                }
                combobox.Items.Add(result);
                result = "";
            }

            databaseConnection.CloseConnection();
        }

        public void DataGridViewCellMouseClick(int assetId)
        {
            transactionSelectedAssetId = assetId;
            var result = assetRepositoryControl.RetrieveAsset(assetId);
            if (result.Success)
            {
                Asset selectedAsset = result.retrievedAsset;

                mainform.textBoxTransactionTransferAssetName.Text = selectedAsset.AssetName;
                mainform.textBoxTransactionTransferAssetCustodian.Text = RetrieveCoordinatorName(selectedAsset.CurrentEmployeeId);
                mainform.richTextBoxTransactionTransferAssetDescription.Text = selectedAsset.AssetDescription;
                mainform.richTextBoxrichTextBoxTransactionTransferAssetDescription.Text = selectedAsset.AssetPurpose;

                mainform.pictureBoxTransactionTransferAssetImage.Image = Utilities.ConvertByteArrayToImage(selectedAsset.AssetImage);
            }
        }

        int coordinatorId;
        public void DataGridViewReceiverCellMouseClick(int id)
        {
            coordinatorId = id;
        }


        private string RetrieveCoordinatorName(int id)
        {

            string query = $"SELECT FName, MName, LName FROM AssetCoordinator WHERE Id = {id}";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string result = "";
            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {
                    result += " " + row[col].ToString();
                }
            }

            databaseConnection.CloseConnection();

            return result;
        }
        public void InitiateImageUploader()
        {
            using (DialogBoxes.UploadImageDialogBox uploadImageDialogBox = new DialogBoxes.UploadImageDialogBox())
            {
                if (uploadImageDialogBox.ShowDialog() == DialogResult.OK)
                {
                    byte[] _imagedata = uploadImageDialogBox.imageByte;
                    if (_imagedata != null)
                    {
                        mainform.pictureBoxTransactionTransferDocumentImage.Image = Utilities.ConvertByteArrayToImage(_imagedata);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public void FilterListCoordinators()
        {
           
            string searchKeyword = mainform.textBoxTransactionTransferName.Text.Trim();

            DataTable dataTable = (DataTable)mainform.dataGridViewTransactionTransferReceiver.DataSource;


            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    string filterExpression = $"FName LIKE '%{searchKeyword}%'";


                    dataTable.DefaultView.RowFilter = filterExpression;
                }
                else
                {

                    dataTable.DefaultView.RowFilter = string.Empty;
                }
            }
        }

        public async void InitiateTransferAsset()
        {
            if(transactionSelectedAssetId != 0)
            {
                //Asset Change
                Asset assetToModify = assetRepositoryControl.RetrieveAsset(transactionSelectedAssetId).retrievedAsset;

                // Log Creation
                string query = "INSERT INTO TransferLog (assetId, assetAdminTransfererId, assetCoordReceiverId, date, previousOffice, supportingDocumentImage) " +
                    "VALUES (@selectedAssetId, @adminId, @coordRId, @date, @prev, @docImage)";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@selectedAssetId",  transactionSelectedAssetId},
                    {"@adminId",  mainform.RoleBasedID},
                    {"@coordRId",  coordinatorId},
                    {"@date",  mainform.dateTimePickerTransactionTransferDate.Value},
                    {"@prev", assetToModify.AssetLocation},
                    {"@docImage",  Utilities.ConvertImageToBytes(mainform.pictureBoxTransactionTransferDocumentImage.Image)}
                };

                databaseConnection.ReadFromDatabase(query, parameters);

                databaseConnection.CloseConnection();


                await Task.Delay(2000); 



                assetToModify.AssetLocation = $"{assetCoordinatorRepositoryControl.GetCoordinatorOffice(coordinatorId).office}";
                assetToModify.CurrentEmployeeId = coordinatorId;

                assetRepositoryControl.UpdateOfficeAndLocationToDatabase(assetToModify);

                Console.WriteLine($"\ntransactionSelectedAssetId: {transactionSelectedAssetId}" +
                                   $"\nadminId : {mainform.RoleBasedID}  " +
                                   $"\ncoordRId: {coordinatorId}" +
                                   $"\ndate: {mainform.dateTimePickerTransactionTransferDate.Value}" +
                                   $"\ndocImage: {Utilities.ConvertImageToBytes(mainform.pictureBoxTransactionTransferDocumentImage.Image)}" +
                                   $"\nassetCoordinatorRepositoryControl.GetCoordinatorOffice(coordinatorId).office: {assetCoordinatorRepositoryControl.GetCoordinatorOffice(coordinatorId).office}" +
                                   $"");

                databaseConnection.CloseConnection();

                ClearAll();

            }
        }

        public void ClearAll()
        {
            mainform.pictureBoxTransactionTransferDocumentImage.Image = LGU_SV_Asset_Management_Sytem.Properties.Resources.empty_image;
            mainform.dateTimePickerTransactionTransferDate.Value = DateTime.Now;


            mainform.dataGridViewTransactionTransferReceiver.ClearSelection();

            AssetSearchFilterClear();

            //Reset
            transactionSelectedAssetId = 0;
            coordinatorId = 0;
        }
    }
}
