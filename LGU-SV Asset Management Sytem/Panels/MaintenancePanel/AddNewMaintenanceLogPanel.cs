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
    public partial class AddNewMaintenanceLogPanel : UserControl
    {
        Asset asset;
        Panel parentPanel;

     
        public AddNewMaintenanceLogPanel(Panel _parentPanel, Asset _asset)
        {
            InitializeComponent();

            asset = _asset;
            parentPanel = _parentPanel;

        }


        private void AddNewMaintenanceLogPanel_Load(object sender, EventArgs e)
        {

        }



        private void buttonClose_Click(object sender, EventArgs e)
        {
            parentPanel.Controls.Clear();
            parentPanel.SendToBack();
            parentPanel.Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
