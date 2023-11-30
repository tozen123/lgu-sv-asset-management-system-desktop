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
    public partial class AddAssetSchedulePanel : UserControl
    {
        Asset asset;
        Panel parentPanel;
        public AddAssetSchedulePanel(Panel _parentPanel, Asset _asset)
        {
            InitializeComponent();
            asset = _asset;
            parentPanel = _parentPanel;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parentPanel.Controls.Clear();
            parentPanel.SendToBack();
            parentPanel.Visible = false;
        }
    }
}
