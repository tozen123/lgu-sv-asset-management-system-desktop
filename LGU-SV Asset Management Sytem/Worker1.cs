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

namespace LGU_SV_Asset_Management_Sytem
{
    public class Worker1
    {

        private MainForm mainform;

        private DatabaseConnection databaseConnection;
        AssetRepositoryControl assetRepositoryControl;
        public Worker1(MainForm form)
        {
            this.mainform = form;
            databaseConnection = new DatabaseConnection();

            assetRepositoryControl = new AssetRepositoryControl();
        }

        public void LoadRentPanel()
        {
            //Controls
           
            //ComboBox
            ComboBoxRetriever(mainform.comboBoxTransactionRentCat, "SELECT assetCategoryId, assetCategoryName FROM AssetCategory");

            // ListBox
            //DataGridViewRetriever(mainform.dataGridViewTransactionRentAsset, "SELECT assetName, assetPropertyNumber, assetId FROM Assets WHERE assetIsArchive = 0");
            // ListBox
            if (mainform.currentSessionUserType.Equals("Asset Administrator"))
            {
                DataGridViewRetriever(mainform.dataGridViewTransactionRentAsset, "SELECT assetName, assetPropertyNumber, assetId FROM Assets WHERE assetIsArchive = 0 AND assetIsMissing = 0");
            }
            else if (mainform.currentSessionUserType.Equals("Asset Coordinator"))
            {
                DataGridViewRetriever(mainform.dataGridViewTransactionRentAsset, $"SELECT assetName, assetPropertyNumber, assetId FROM Assets WHERE assetIsArchive = 0 AND assetLocation = '{mainform.currentUserOffice}' AND assetIsMissing = 0");
            }
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

        public void CategoryListApplyFilter()
        {
            if(mainform.comboBoxTransactionRentCat.SelectedItem != null)
            {
                string selectedCategory = mainform.comboBoxTransactionRentCat.SelectedItem.ToString().Split('|')[1].Trim();

                DataGridViewRetriever(mainform.dataGridViewTransactionRentAsset, $"SELECT assetName, assetPropertyNumber, assetId FROM Assets WHERE assetCategoryID = {selectedCategory}");
            }
    
        }

        public void AssetSearchFilterClear()
        {

            DataGridViewRetriever(mainform.dataGridViewTransactionRentAsset, "SELECT assetName, assetPropertyNumber, assetId FROM Assets");

            if (mainform.comboBoxTransactionRentCat.SelectedItem != null)
            {
                mainform.comboBoxTransactionRentCat.SelectedItem = null;
            }

            mainform.textBoxTransactionRentAssetName.Text = string.Empty;
            mainform.textBoxTransactionRentCurrentCoordinator.Text = string.Empty;
            mainform.textBoxTransactionRentAssetDescription.Text = string.Empty;
            mainform.textBoxTransactionRentAssetPurpose.Text = string.Empty;

            mainform.PictureBoxTransactionRentAssetImage.Image = LGU_SV_Asset_Management_Sytem.Properties.Resources.empty_image;

            transactionSelectedAssetId = 0; 

        }

        int transactionSelectedAssetId; 
        public void DataGridViewCellMouseClick(int assetId)
        {
            transactionSelectedAssetId = assetId;
            var result = assetRepositoryControl.RetrieveAsset(assetId);
            if (result.Success)
            {
                Asset selectedAsset = result.retrievedAsset;

                mainform.textBoxTransactionRentAssetName.Text = selectedAsset.AssetName;
                mainform.textBoxTransactionRentCurrentCoordinator.Text = RetrieveCoordinatorName(selectedAsset.CurrentEmployeeId);
                mainform.textBoxTransactionRentAssetDescription.Text = selectedAsset.AssetDescription;
                mainform.textBoxTransactionRentAssetPurpose.Text = selectedAsset.AssetPurpose;

                mainform.PictureBoxTransactionRentAssetImage.Image = Utilities.ConvertByteArrayToImage(selectedAsset.AssetImage);
            }   
        }
        public Asset AssetInProcess()
        {
            if (transactionSelectedAssetId != 0)
            {
                var result = assetRepositoryControl.RetrieveAsset(transactionSelectedAssetId);
                return result.retrievedAsset;
            }
            else
            {
                return null;
            }
                
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
                        mainform.pictureBoxValidIDImage.Image = Utilities.ConvertByteArrayToImage(_imagedata);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
       
        public void InitiateAssetTransfer()
        {
            if(transactionSelectedAssetId != 0)
            {
                string fname = mainform.textBoxTransactionRenteeFName.Text;
                string mname = mainform.textBoxTransactionRenteeMName.Text;
                string lname = mainform.textBoxTransactionRenteeLName.Text;
                string addr = mainform.richTextBoxTransactionRenteeAddr.Text;

                DateTime bdate = mainform.dateTimeTransactionRenteeBDate.Value;
                string cnumber = mainform.textBoxTransactionRenteeContactNumber.Text;
                string lnumber = mainform.textBoxTransactionRenteeLicenseID.Text;
                Image validimage = mainform.pictureBoxValidIDImage.Image;


                if (string.IsNullOrEmpty(fname))
                {
                    return;
                }


                string query = "INSERT INTO RentLog (assetId, renteeFirstName, renteeMidName, renteeLastName, renteeAddress, " +
                    "renteeBirthdate, renteeContactNumber, renteeLicenseNumber, renteeValidIDImage, rentInitiatedDate, rentStatus ) VALUES " +
                    "(@selectedAssetId, @fname, @mname, @lname, @addr, @bdate, @cnumber, @lnumber, @validimage, @iniDate, @status )";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@selectedAssetId", transactionSelectedAssetId},
                    {"@fname", fname},
                    {"@mname", mname},
                    {"@lname", lname},
                    {"@addr", addr},
                    {"@bdate", bdate},
                    {"@cnumber", cnumber},
                    {"@lnumber", lnumber},
                    {"@validimage", Utilities.ConvertImageToBytes(validimage)},
                    {"@iniDate", mainform.dateTimePickerTransactionRentStart.Value},
                    {"@status", "Not Returned"}

                };

                int id = databaseConnection.UploadToDatabaseAndGetId(query, parameters);
                databaseConnection.CloseConnection();

             

            }

            mainform.pictureBoxValidIDImage.Image = LGU_SV_Asset_Management_Sytem.Properties.Resources.empty_image;
            mainform.dateTimeTransactionRenteeBDate.Value = DateTime.Now;

            Control[] c = { 
                mainform.textBoxTransactionRenteeFName, 
                mainform.textBoxTransactionRenteeMName, 
                mainform.textBoxTransactionRenteeLName,
                mainform.richTextBoxTransactionRenteeAddr,
                mainform.textBoxTransactionRenteeContactNumber,
                mainform.textBoxTransactionRenteeLicenseID
            };
            Utilities.ClearTextFieldsHandler(c);

            AssetSearchFilterClear();

            //Reset
            transactionSelectedAssetId = 0;
        }
    }
 
}
