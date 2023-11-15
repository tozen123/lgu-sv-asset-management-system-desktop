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
        
        public AddAssetPanelConfirmation(List<Asset> assetToConfirmList)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            list = assetToConfirmList;
        }

        public DialogResult GetResult()
        {
            return this.DialogResult;
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

        }

        private void buttonForwardList_Click_1(object sender, EventArgs e)
        {

        }
    }
}
