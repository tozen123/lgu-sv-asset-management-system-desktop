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
    public partial class MainForm : Form
    {
        // Reference for SessionHandler
        private SessionHandler sessionHandler;
        private DatabaseConnection databaseConnection;


        //Profile Tab
        List<Control> profileTabControls = new List<Control>();

        public MainForm()
        {
            InitializeComponent();
            InitialiazeTabControl();

            databaseConnection = new DatabaseConnection();

            InitializeProfileTabControls();
        }

        // Start
        public void SetSessionHandler(string user_id)
        {
            sessionHandler = new SessionHandler(user_id);
            Console.WriteLine(sessionHandler.GetCurrentUserID());

            SetUser();
        }

        private void InitialiazeTabControl()
        {
            panelTabControl.Appearance = TabAppearance.FlatButtons;
            panelTabControl.ItemSize = new Size(0, 1);
            panelTabControl.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in panelTabControl.TabPages)
            {
                tab.Text = "";
            }
        }

        private void SetUser()
        {
          
            labelUserName.Text = sessionHandler.GetUserName(databaseConnection);
            labelUserType.Text = sessionHandler.GetTypeUser();
        }

        private void ProfileTabPanel()
        {
            

        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabDashboard;
        }

        private void buttonAssetRecords_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabAssetRecords;
        }

        private void buttonArchiveRecords_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabArchiveRecords;
        }

        private void buttonGenerateReports_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabGenReport;
        }

        private void buttonOthers_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabOthers;
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabProfile;
            ProfileTabPanel();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabAbout;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabAbout;
        }

        private void InitializeProfileTabControls()
        {
            profileTabControls.Add(buttonEditProfile);
            profileTabControls.Add(buttonProfileSave);
            profileTabControls.Add(buttonProfileCancel);

            profileTabControls.Add(textBoxProfileName);
            profileTabControls.Add(textBoxProfilePhoneNumber);
            profileTabControls.Add(textBoxProfileEmail);
            profileTabControls.Add(textBoxProfilePassword);
            profileTabControls.Add(textBoxProfileOffice);
            profileTabControls.Add(textBoxProfilePosition);
            profileTabControls.Add(textBoxProfileAddress);


            SetListControlStateTo(profileTabControls, false);

            buttonEditProfile.Enabled = true;
            buttonProfileSave.Visible = false;
            buttonProfileCancel.Visible = false;

            //Fetch Data
        }

        private void SetListControlStateTo(List<Control> controls, bool state)
        {
            foreach (Control control in controls)
            {
                control.Enabled = state;
            }
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            SetListControlStateTo(profileTabControls, true);
            buttonEditProfile.Visible = false;

            buttonProfileSave.Visible = true;
            buttonProfileCancel.Visible = true;



        }
    }
}
