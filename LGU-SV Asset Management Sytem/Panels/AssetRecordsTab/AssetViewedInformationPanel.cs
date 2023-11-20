using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LGU_SV_Asset_Management_Sytem.Asset;

namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{
    public partial class AssetViewedInformationPanel : UserControl
    {
        Asset asset;
        Control _panelHandler;
        RecordsHomePanel rcpanel;

        AssetRepositoryControl assetRepositoryControl;

        User currentUser;

        public AssetViewedInformationPanel(Asset _asset, RecordsHomePanel _rcpanel, Control panelHandler, User _currentUser)
        {
            InitializeComponent();
            _panelHandler = panelHandler;
            asset = _asset;
            rcpanel = _rcpanel;

            currentUser = _currentUser;

            InitializeAssetInformation();
            SetMenuButton();

            assetRepositoryControl = new AssetRepositoryControl();
            SetAccessLevel();
        }

        // Only Employee can create new MaintenanceLogs

        private void SetAccessLevel()
        {
            switch (currentUser.GetStringAccessLevel())
            {
                case "Asset Viewer":
                    buttonDelete.Enabled = false;
                    buttonArchive.Enabled = false;
                    buttonUpdateInfo.Enabled = false;
                    break;
                case "Asset Employee":
                    buttonDelete.Enabled = false;
                    buttonArchive.Enabled = false;
                    buttonUpdateInfo.Enabled = false;
                    break;
                case "Asset Supervisor":
                    
                    break;
            }
        }

        private void InitializeAssetInformation()
        {
            labelAssetIdWithName.Text = "Asset Records: " + asset.AssetId + "-" + asset.AssetName;

            //Images
            SetImage(pictureBoxAssetImage, asset.AssetImage);
            SetImage(pictureBoxAssetQrImage, asset.AssetQRCodeImage);

            textBoxId.Text = asset.AssetId.ToString();
            textBoxName.Text = asset.AssetName;
            textBoxQuantity.Text = asset.AssetQuantity.ToString();
            textBoxLocation.Text = asset.AssetLocation;
            textBoxPAmount.Text = asset.AssetPurchaseAmount.ToString();
            textBoxPDate.Text = asset.AssetPurchaseDate.ToString();

            if (asset.AssetLastMaintenanceID.ToString() == "0")
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

            //New

            richTextBoxDescription.Text = asset.AssetDescription;
            richTextBoxPurpose.Text = asset.AssetPurpose;

            textBoxPropertyName.Text = asset.AssetPropertyNumber.ToString();

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
            menuButton1.Menu.Items.Add("Maintenances", null, MenuItem_Click);
            menuButton1.Menu.Items.Add("Transfers", null, MenuItem_Click);
            menuButton1.Menu.Items.Add("Borrowed And Returns", null, MenuItem_Click);
        
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            _panelHandler.Controls.Clear();
            _panelHandler.SendToBack();
        }

        private void buttonSavePng_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Image As";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SavePictureBoxAsPNG(pictureBoxAssetQrImage, saveFileDialog.FileName);
            }
        }
        private void SavePictureBoxAsPNG(PictureBox pictureBox, string filePath)
        {
            if (pictureBox.Image != null)
            {

                Bitmap bitmap = new Bitmap(pictureBox.Image);


                bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);


                bitmap.Dispose();

                MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("PictureBox has no image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private PrintDocument printDocument = new PrintDocument();
        private void buttonPrintAction_Click(object sender, EventArgs e)
        {
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {

                printDocument.PrinterSettings = printDialog.PrinterSettings;


                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            Image imageToPrint = pictureBoxAssetQrImage.Image;


            e.Graphics.DrawImage(imageToPrint, new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height));
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {

        }

        private void buttonArchive_Click(object sender, EventArgs e)
        {
            using (DialogBoxes.ConfirmationPrompt confirmationPrompt = new DialogBoxes.ConfirmationPrompt())
            {
                confirmationPrompt.SetConfirmationMessage($"Do you want to move the asset {labelAssetIdWithName.Text} to the Archive Records?");
                confirmationPrompt.SetConfirmationTitle("Archive Asset Confirmation");
                confirmationPrompt.SetData(asset);

                if (confirmationPrompt.ShowDialog() == DialogResult.OK)
                {
                    MessagePrompt("Part not fully implemented. :(");
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (DialogBoxes.ConfirmationPrompt confirmationPrompt = new DialogBoxes.ConfirmationPrompt())
            {
                confirmationPrompt.SetConfirmationMessage($"Do you want to delete asset {labelAssetIdWithName.Text}? This action cannot be undone.");
                confirmationPrompt.SetConfirmationTitle("Delete Asset Confirmation");
                confirmationPrompt.SetData(asset);

                if (confirmationPrompt.ShowDialog() == DialogResult.OK)
                {
                    var result = assetRepositoryControl.DeleteToDatabase(asset);

                    if (result.Success)
                    {

                       
                        _panelHandler.Controls.Clear();
                        rcpanel.InitializeRecords();
                        _panelHandler.SendToBack();

                        MessagePrompt($"Asset has been successfully deleted");
                    }
                    else
                    {
                        MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
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

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;

            if (clickedItem != null)
            {       
                string itemName = clickedItem.Text;

                switch (itemName)
                {
                    case "Maintenances":
                        MaintenancePanel.AssetMaintenanceLogPanel maintenanceLogPanel = new MaintenancePanel.AssetMaintenanceLogPanel(panelLogsHandler, asset, currentUser);
                        SwitchLogPanel(maintenanceLogPanel);

                        break;
                    case "Transfers":
                        TransferPanel.AssetTransferLogPanel transferLogPanel = new TransferPanel.AssetTransferLogPanel(panelLogsHandler, asset, currentUser);
                        SwitchLogPanel(transferLogPanel);

                        break;
                    case "Borrowed And Returns":
                        BorrowedAndReturns.AssetBorrowedAndReturnsLogPanel borrowedAndReturnsLogPanel = new BorrowedAndReturns.AssetBorrowedAndReturnsLogPanel(panelLogsHandler, asset, currentUser);
                        SwitchLogPanel(borrowedAndReturnsLogPanel);
                        break;
                }
            }
        }

        private void SwitchLogPanel(Control panelToSwitch)
        {
            panelLogsHandler.Controls.Add(panelToSwitch);
            panelLogsHandler.BringToFront();
            panelLogsHandler.Visible = true;
        }

    
    }
}
