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
        Panel panelHandlerParent;
        User currentUser;
        public AssetBorrowedAndReturnsLogPanel(Panel _panelHandler, Asset _asset, User _currentUser)
        {
            InitializeComponent();
            asset = _asset;
            panelHandlerParent = _panelHandler;
            currentUser = _currentUser;

            Console.WriteLine("AssetBorrowedAndReturnsLogPanel: " + currentUser.GetStringAccessLevel());

            SetData();
        }
        private void SetData()
        {
            labelAssetIdWithName.Text = "Borrowed And Return Logs: " + asset.AssetId + "-" + asset.AssetName;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

            panelHandlerParent.Controls.Clear();
            panelHandlerParent.SendToBack();
            panelHandlerParent.Visible = false;
        }
    }
}
