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
        }
        public void SetMessage(string message)
        {
            labelMessage.Text = message;
        }
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
