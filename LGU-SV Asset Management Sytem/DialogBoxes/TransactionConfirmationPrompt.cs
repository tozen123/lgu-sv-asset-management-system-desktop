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
    public partial class TransactionConfirmationPrompt : Form
    {
        public TransactionConfirmationPrompt()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public DialogResult GetResult()
        {
            return this.DialogResult;
        }
        public void SetConfirmationTitle(string title)
        {
            labelConfirmationTitle.Text = title;
        }
       
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }
    }
}
