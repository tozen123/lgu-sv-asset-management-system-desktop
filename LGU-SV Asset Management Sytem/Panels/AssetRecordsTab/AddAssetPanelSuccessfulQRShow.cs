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

namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{
    public partial class AddAssetPanelSuccessfulQRShow : Form
    {
        List<Asset> list = new List<Asset>();
        int currentIndex;
        public AddAssetPanelSuccessfulQRShow(List<Asset> assetSuccessfulList)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            list = assetSuccessfulList;

            if (list.Count == 1)
            {
                buttonBackwardList.Visible = false;
                buttonForwardList.Visible = false;
            }

            LoadData(0);
        }

        private void LoadData(int indexLoad)
        {
            labelAssetName.Text = list[indexLoad].AssetName;
            labelAssetID.Text = list[indexLoad].AssetId.ToString();
            //pictureBoxQR.Image = Utilities.ConvertByteArrayToImage(list[indexLoad].AssetQRCodeImage);

        }

        public DialogResult GetResult()
        {
            return this.DialogResult;
        }

        private void buttonSaveAsPng_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Image As";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //SavePictureBoxAsPNG(pictureBoxQR, saveFileDialog.FileName);
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

        private void buttonForwardList_Click(object sender, EventArgs e)
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

        private void buttonBackwardList_Click(object sender, EventArgs e)
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

        private PrintDocument printDocument = new PrintDocument();

        private void buttonPrint_Click(object sender, EventArgs e)
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
            
            //Image imageToPrint = pictureBoxQR.Image;

       
           // e.Graphics.DrawImage(imageToPrint, new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height));
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
