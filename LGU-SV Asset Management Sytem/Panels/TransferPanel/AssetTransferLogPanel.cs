using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.TransferPanel
{
    public partial class AssetTransferLogPanel : UserControl
    {
        Asset asset;
        public AssetTransferLogPanel(Panel _panelHandler, Asset _asset)
        {
            InitializeComponent();
            asset = _asset;

            SetData();
        }

        private void SetData()
        {
            labelAssetIdWithName.Text = "Transfer Logs: " + asset.AssetId + "-" + asset.AssetName;
        }
    }
}
