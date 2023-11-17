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
    public partial class AssetViewedInformationPanel : UserControl
    {
        Asset asset;
        Control _panelHandler;

        public AssetViewedInformationPanel(Asset _asset, Control panelHandler)
        {
            InitializeComponent();
            _panelHandler = panelHandler;
            asset = _asset;

            InitializeAssetInformation();
            SetMenuButton();
        }
        private void InitializeAssetInformation()
        {
            labelAssetIdWithName.Text = "Asset ID: " + asset.AssetId + "-" + asset.AssetName;

            //Images
            SetImage(pictureBoxAssetImage, asset.AssetImage);
            SetImage(pictureBoxAssetQrImage, asset.AssetQRCodeImage);

            textBoxId.Text = asset.AssetId.ToString();
            textBoxName.Text = asset.AssetName;
            textBoxQuantity.Text = asset.AssetQuantity.ToString();
            textBoxLocation.Text = asset.AssetLocation;
            textBoxPAmount.Text = asset.AssetPurchaseAmount.ToString();
            textBoxPDate.Text = asset.AssetPurchaseDate.ToString();

            if (asset.AssetLastMaintenanceID.ToString() == "")
            {
                textBoxLMaintenance.Text = "N/A";
            }
            else
            {
                textBoxLMaintenance.Text = asset.AssetLastMaintenanceID.ToString();
            }

            textBoxUnit.Text = asset.AssetUnit;
            textBoxCondition.Text = asset.AssetCondition;
            textBoxAvailability.Text = asset.AssetAvailability;
            textBoxLifeSpan.Text = asset.AssetLifeSpan.ToString();
            



            //TextBoxes 2
            textBoxEmployee.Text = asset.EmployeeName;
            textBoxAssetCategory.Text = asset.AssetCategoryName;
            textBoxSupplier.Text = asset.SupplierName;


        }

        private void SetImage(PictureBox pictureBox, byte[] array)
        {
            pictureBox.Image = Utilities.ConvertByteArrayToImage(array);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetMenuButton()
        {
            menuButton1.Text = "Logs";
            menuButton1.Menu = new ContextMenuStrip();
            menuButton1.Menu.Items.Add("Maintenances");
            menuButton1.Menu.Items.Add("Transfers");
            menuButton1.Menu.Items.Add("Borrowed And Returns");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            _panelHandler.Controls.Clear();
            _panelHandler.SendToBack();
        }

    }
}
