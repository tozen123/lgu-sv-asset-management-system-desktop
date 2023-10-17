using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string inputEmail = textBoxEmail.Text;
            string inputPassword = textBoxPassword.Text;

            if(inputEmail == null)
            {
                MessageBox.Show("Auto-login successful!");
            }
        }
    }
}
