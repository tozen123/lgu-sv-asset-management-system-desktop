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
            pictureBoxQR.Image = Utilities.ConvertByteArrayToImage(list[indexLoad].AssetQRCodeImage);

        }

        public DialogResult GetResult()
        {
            return this.DialogResult;
        }

        private void buttonSaveAsPng_Click(object sender, EventArgs e)
        {

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


        private void buttonPrint_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {

        }
    }
}
