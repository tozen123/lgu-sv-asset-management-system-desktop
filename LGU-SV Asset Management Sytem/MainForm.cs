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
        public MainForm()
        {
            InitializeComponent();
            InitialiazeTabControl();
            databaseConnection = new DatabaseConnection();
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
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabAbout;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabAbout;
        }
    }
}
