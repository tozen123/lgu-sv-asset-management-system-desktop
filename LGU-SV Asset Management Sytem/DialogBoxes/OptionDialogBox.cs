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
        string supervisor_id;
        string supervisor_location;
        MainForm mainForm;
        public OptionDialogBox(Control _panelHandler, string _supervisor_id, string loc, MainForm _mainForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            mainForm = _mainForm;
            supervisor_id = _supervisor_id;
            supervisor_location = loc;
            panelHandler = _panelHandler;
         }

        private void buttonAddExistingAsset_Click(object sender, EventArgs e)
        {
            this.Close();
            using(AddAssetBasedOnExistingDialog existingDialog = new AddAssetBasedOnExistingDialog(panelHandler, supervisor_id, supervisor_location, mainForm))
            {
                existingDialog.ShowDialog();
            }
        }

        private void buttonNewAsset_Click(object sender, EventArgs e)
        {
            this.Close();

            Control panelControl = new Panels.AssetRecordsTab.AddAssetPanel(Panels.AssetRecordsTab.AddAssetPanel.AssetType.New, supervisor_id, supervisor_location, panelHandler, mainForm);
            panelControl.Size = panelHandler.Size;

            Utilities.PanelChanger(panelHandler, panelControl);

            mainForm.buttonSearch.Enabled = false;
            mainForm.textBoxSearchFilter.Enabled = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.LoadAssets();
        }
    }
}
