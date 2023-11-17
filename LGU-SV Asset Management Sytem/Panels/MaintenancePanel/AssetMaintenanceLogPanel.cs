using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.MaintenancePanel
{
    public partial class AssetMaintenanceLogPanel : UserControl
    {
        Panel panelHandlerParent;
        Asset asset;

        public AssetMaintenanceLogPanel(Panel _panelHandler, Asset _asset)
        {
            InitializeComponent();
            panelHandlerParent = _panelHandler;
            asset = _asset;

            InitializeRecords();
            SetData();
        }

        public void InitializeRecords()
        {

        }

        private void SetData()
        {
            labelAssetIdWithName.Text = "Maintenance Logs: " + asset.AssetId + "-" + asset.AssetName;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelHandlerParent.Controls.Clear();
            panelHandlerParent.SendToBack();
            panelHandlerParent.Visible = false;
        }

    }
}
