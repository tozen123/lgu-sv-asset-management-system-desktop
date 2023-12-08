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

namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{
    public partial class AssetInfoUpdater : Form
    {
        private DatabaseConnection databaseConnection;
        AssetRepositoryControl assetRepositoryControl;

        Asset asset;
        public AssetInfoUpdater(Asset _asset)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            asset = _asset;
            databaseConnection = new DatabaseConnection();
            assetRepositoryControl = new AssetRepositoryControl();

            ComboBoxRetriever(comboBoxSupplier, "SELECT supplierId, supplierName FROM Supplier");
        }
        public DialogResult GetResult()
        {
            return this.DialogResult;
        }
        private void AssetInfoUpdater_Load(object sender, EventArgs e)
        {
            string target = asset.AssetName + " - " + asset.AssetId.ToString();
            labelAssetID_Name.Text = target;
            this.Text = "AssetInfoUpdateModule | " + target;

            textBoxName.Text = asset.AssetName;
            textBoxPNumber.Text = asset.AssetPropertyNumber.ToString();
            textBoxPurchaseAmount.Text = asset.AssetPurchaseAmount.ToString();
            textBoxQuantity.Text = asset.AssetQuantity.ToString();
            richTextBoxDesc.Text = asset.AssetDescription;
            richTextBoxPurpose.Text = asset.AssetPurpose;
            comboBoxCondition.SelectedItem = asset.AssetCondition;
            pictureBox1.Image = Utilities.ConvertByteArrayToImage(asset.AssetImage);

            //Fix
            if (comboBoxSupplier.Items.Count > 0)
            {
                if (comboBoxSupplier.Items.Count > 0)
                {
                    int selectedSupplierId = asset.SupplierId; 

                    for (int i = 0; i < comboBoxSupplier.Items.Count; i++)
                    {
                        string currentItem = comboBoxSupplier.Items[i].ToString();
                        string supplierId = currentItem.Split('|')[1].Trim();

                        if (supplierId.Equals(selectedSupplierId.ToString()))
                        {
                            comboBoxSupplier.SelectedIndex = i;
                            break;
                        }
                    }
                }

            }

        }

        private void roundedButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void roundedButtonConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            Asset updatedAsset = new Asset();
            updatedAsset = asset;

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(textBoxPNumber.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(textBoxPurchaseAmount.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(textBoxQuantity.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(richTextBoxDesc.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(richTextBoxPurpose.Text))
            {
                return;
            }
            if(comboBoxCondition.SelectedItem == null)
            {
                return;
            }
            if (comboBoxSupplier.SelectedItem == null)
            {
                return;
            }

            updatedAsset.AssetName = textBoxName.Text;
            updatedAsset.AssetPropertyNumber = Convert.ToInt32(textBoxPNumber.Text);
            updatedAsset.AssetPurchaseAmount = Convert.ToDecimal(textBoxPurchaseAmount.Text);
            updatedAsset.AssetQuantity = Convert.ToInt32(textBoxQuantity.Text);
            updatedAsset.AssetDescription = richTextBoxDesc.Text;
            updatedAsset.AssetPurpose = richTextBoxPurpose.Text;

            updatedAsset.AssetCondition = comboBoxCondition.SelectedItem.ToString();

            if(pictureBox1.Image != LGU_SV_Asset_Management_Sytem.Properties.Resources.empty_image)
            {
                updatedAsset.AssetImage = Utilities.ConvertImageToBytes(pictureBox1.Image);
            }
            

            if (int.TryParse(comboBoxSupplier.SelectedItem.ToString().Split(' ')[2], out int supId))
            {
                asset.SupplierId = supId;
            }


            var result = assetRepositoryControl.UpdateToDatabase(updatedAsset);

            if (result.Success)
            {

                MessagePrompt($"Asset has been successfully updated");

            }
            else
            {
                MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
            }
        }
        public void ComboBoxRetriever(ComboBox combobox, string query)
        {
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
        private void MessagePrompt(string message)
        {
            DialogBoxes.MessagePromptDialogBox prompt = new DialogBoxes.MessagePromptDialogBox();
            prompt.SetMessage(message);
            prompt.ShowDialog();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            UploadImage(pictureBox1);
        }

        private void UploadImage(PictureBox pictureBox)
        {
            using (DialogBoxes.AssetUploadImageDialogBox uploadImageDialogBox = new DialogBoxes.AssetUploadImageDialogBox())
            {
                if (uploadImageDialogBox.ShowDialog() == DialogResult.OK)
                {
                    byte[] _imagedata = uploadImageDialogBox.imageByte;
                    if (_imagedata != null)
                    {
                        pictureBox.Image = Utilities.ConvertByteArrayToImage(_imagedata);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
