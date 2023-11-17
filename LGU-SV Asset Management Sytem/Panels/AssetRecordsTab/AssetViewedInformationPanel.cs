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
    public partial class AssetViewedInformationPanel : UserControl
    {
        Asset asset;
        Control _panelHandler;

        public AssetViewedInformationPanel(Asset _asset, Control panelHandler)
        {
            InitializeComponent();
            _panelHandler = panelHandler;
            asset = _asset;

            SetMenuButton();
        }

        private void SetMenuButton()
        {
            menuButton1.Text = "Logs";
            menuButton1.Menu = new ContextMenuStrip();
            menuButton1.Menu.Items.Add("Maintenances");
            menuButton1.Menu.Items.Add("Transfers");
            menuButton1.Menu.Items.Add("Borrowed And Returns");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            _panelHandler.Controls.Clear();
            _panelHandler.SendToBack();
        }



    }
}
