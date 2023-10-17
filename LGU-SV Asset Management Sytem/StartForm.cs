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

        private List<Panel> startFormPanels = new List<Panel>();
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

            startFormPanels.Add(LoginPanel);
            startFormPanels.Add(RegistrationStartPanel);
            startFormPanels.Add(RegistrationStartPanel2);

            ActivatePanel(LoginPanel);
        }

        private void ActivatePanel(Panel panelToActivate)
        {
            foreach (Panel panel in startFormPanels)
            {
                if (panel == panelToActivate)
                {
                    panel.Visible = true;
                }
                else
                {
                    panel.Visible = false;
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string inputEmail = textBoxEmail.Text;
            string inputPassword = textBoxPassword.Text;

            
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            ActivatePanel(RegistrationStartPanel);

        }

        private void buttonManagerRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Manager;
            labelID.Text = RegistrationType.Manager + " ID";

            ActivatePanel(RegistrationStartPanel2);
        }

        private void buttonOperatorRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Operator;
            labelID.Text = RegistrationType.Operator + " ID";

            ActivatePanel(RegistrationStartPanel2);
        }

        private void buttonViewerRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Viewer;
            labelID.Text = RegistrationType.Viewer + " ID";

            ActivatePanel(RegistrationStartPanel2);

        }

   
    }
}
