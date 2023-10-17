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
        private DatabaseConnection databaseConnection;


        //Registration Variable
        private enum RegistrationType
        {
            Operator,
            Manager,
            Viewer
        }

        private RegistrationType registrationType;

        public StartForm()
        {
            InitializeComponent();

            databaseConnection = new DatabaseConnection();

            HideAllPanel();
            LoginPanel.Visible = true;
        }
 

        private void HideAllPanel()
        {
            LoginPanel.Visible = false;
            RegistrationStartPanel.Visible = false;
            RegistrationStartPanel2.Visible = false;

        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string inputEmail = textBoxEmail.Text;
            string inputPassword = textBoxPassword.Text;

            
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            HideAllPanel();
            RegistrationStartPanel.Visible = true;
        }

        private void buttonManagerRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Manager;
            labelID.Text = RegistrationType.Manager + " ID";
        }

        private void buttonOperatorRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Operator;
            labelID.Text = RegistrationType.Operator + " ID";
        }

        private void buttonViewerRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Viewer;
            labelID.Text = RegistrationType.Viewer + " ID";
        }

   
    }
}
