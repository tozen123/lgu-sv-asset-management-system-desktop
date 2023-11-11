using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
    public partial class OptionDialogBox : Form
    {
        Control panelHandler;
        public OptionDialogBox(Control _panelHandler)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            pictureBox1.BackColor = Color.FromArgb(45, 77, 46);

            panelHandler = _panelHandler;
        }

        private void buttonAddExistingAsset_Click(object sender, EventArgs e)
        {
            this.Close();

            Control panelControl = new Panels.AssetRecordsTab.AddAssetPanel(Panels.AssetRecordsTab.AddAssetPanel.AssetType.Existing);
            Utilities.PanelChanger(panelHandler, panelControl);
        }

        private void buttonNewAsset_Click(object sender, EventArgs e)
        {
            this.Close();

            Control panelControl = new Panels.AssetRecordsTab.AddAssetPanel(Panels.AssetRecordsTab.AddAssetPanel.AssetType.New);
            Utilities.PanelChanger(panelHandler, panelControl);
        }
    }
}
