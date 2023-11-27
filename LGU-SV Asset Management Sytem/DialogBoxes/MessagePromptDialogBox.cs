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
    public partial class MessagePromptDialogBox : Form
    {
        public MessagePromptDialogBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            pictureBoxBorderTop.BackColor = Color.FromArgb(45, 77, 46);
            labelMessage.SelectionAlignment = HorizontalAlignment.Center;
        }
        public void SetMessage(string message)
        {
            labelMessage.ReadOnly = false;
            labelMessage.Clear();
            labelMessage.SelectionAlignment = HorizontalAlignment.Center;
            labelMessage.AppendText(message);
            labelMessage.ReadOnly = true;

        }
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
