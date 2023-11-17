using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.BorrowedAndReturns
{
    public partial class AssetBorrowedAndReturnsLogPanel : UserControl
    {
        Asset asset;
        public AssetBorrowedAndReturnsLogPanel(Panel _panelHandler, Asset _asset)
        {
            InitializeComponent();
            asset = _asset;
            SetData();
        }
        private void SetData()
        {
            labelAssetIdWithName.Text = "Borrowed And Return Logs: " + asset.AssetId + "-" + asset.AssetName;
        }
    }
}
