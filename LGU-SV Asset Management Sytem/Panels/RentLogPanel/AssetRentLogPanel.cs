using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.RentLogPanel
{
    public partial class AssetRentLogPanel : UserControl
    {
        Panel panelHandlerParent;
        Asset asset;
        User currentUser;
        public AssetRentLogPanel(Panel _panelHandler, Asset _asset, User _currentUser)
        {
            InitializeComponent();
            asset = _asset;
            panelHandlerParent = _panelHandler;
            currentUser = _currentUser;
            Console.WriteLine("AssetTransferLogPanel: " + currentUser.GetStringAccessLevel());

            SetData();
        }

        private void SetData()
        {
            labelAssetIdWithName.Text = "Rent Logs: " + asset.AssetId + "-" + asset.AssetName;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

            panelHandlerParent.Controls.Clear();
            panelHandlerParent.SendToBack();
            panelHandlerParent.Visible = false;
        }
    }
}
