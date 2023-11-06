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
    public partial class OperatorHandledAssetPanel : UserControl
    {
        Control panelControl;
        string operatorId;
        public OperatorHandledAssetPanel(Control _panelControl, string _operatorId, string name)
        {
            InitializeComponent();
            panelControl = _panelControl;
            operatorId = _operatorId;

            labelOperatorName.Text = name;
        }

        private void buttonExitPanel_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            panelControl.Visible = false;
        }
    }
}
