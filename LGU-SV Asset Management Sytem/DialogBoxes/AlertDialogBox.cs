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
    public partial class AlertDialogBox : Form
    {
        
        public AlertDialogBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void SetDialog(string title, string message)
        {
            this.Text = title;
            labelMessage.Text = message;
        }
        public DialogResult GetResult()
        {
            return this.DialogResult;
        }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AlertDialogBox_Load(object sender, EventArgs e)
        {

        }
    }
}
