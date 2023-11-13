using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels
{
    public partial class SupplierSuppliedAssetPanel : UserControl
    {
        Control panelControl;
        string supplierId;
        Control[] controls;
        public SupplierSuppliedAssetPanel(Control _panelControl, string _supplierId, string name)
        {
            InitializeComponent();

            panelControl = _panelControl;
            supplierId = _supplierId;

            labelSupplierName.Text = name;
        }

        private void buttonExitPanel_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            panelControl.Visible = false;
        }
    }
}
