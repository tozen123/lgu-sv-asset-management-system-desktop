using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using static LGU_SV_Asset_Management_Sytem.Asset;

namespace LGU_SV_Asset_Management_Sytem
{
    public partial class MainForm : Form
    {
        // Reference for SessionHandler
        private SessionHandler sessionHandler;
        private DatabaseConnection databaseConnection;


        //Profile Tab
        List<Control> profileTabControls = new List<Control>();

        //Session
        User currentUser = new User();
        public string currentSessionUserType;
        public string currentUserOffice;

        //Color
        Color clickColor = Color.FromArgb(48, 77, 46);

        //447145
        Color mainColor1 = Color.FromArgb(68, 113, 69);

        //savingprofile
        private byte[] imagedata;


        //Supplier
        Controllers.MainFormSupplierController supplierController;
        Controllers.MainFormAssetCategoriesController assetCategoriesController;

        AssetCoordinator.AssetCoordinatorRepositoryControl assetOperatorRepositoryControl = new AssetCoordinator.AssetCoordinatorRepositoryControl();

        //Objects Controllers
        AssetCategoryRepositoryControl assetCategoryRepositoryControl;

        //User-Role-Id
        public string RoleBasedID;

        //Worker
        Worker worker;
        Worker1 worker1;
        Worker2 worker2;
        Worker3 worker3;
        Worker4 worker4;
        Worker5 worker5;

        public MainForm()
        {
            
            InitializeComponent();
            
            this.StartPosition = FormStartPosition.CenterScreen;

            InitialiazeTabControl(panelTabControl);
            InitialiazeTabControl(otherTabControl);
            InitialiazeTabControl(tabControlTransaction);

            databaseConnection = new DatabaseConnection();

            InitializeProfileTabControls();

            SetData();

            //Other Panel DataGridView
            dataGridViewSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAssetCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOtherOperator.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

 

            //Controllers
            supplierController = new Controllers.MainFormSupplierController(databaseConnection);
            assetCategoriesController = new Controllers.MainFormAssetCategoriesController(databaseConnection);


            //Object Controllers
            assetCategoryRepositoryControl = new AssetCategoryRepositoryControl();

            //Side
            //Control[] sideLabels = { labelSideBarArchRec, labelSideBarAssetRe, labelSideBarGenRep, labelSideBarMisc, labelSideBarTransc, labelSideDashboard };
           // Utilities.SetControlsVisibilityState(sideLabels, false);

            //Worker
            worker = new Worker(this);
            worker1 = new Worker1(this);
            worker2 = new Worker2(this);
            worker3 = new Worker3(this);
            worker4 = new Worker4(this);
            worker5 = new Worker5(this);




        }

        // Initialize Controls

        private void InitializedAccessControl()
        {
            if(sessionHandler == null)
            {
                MessagePrompt($"{ErrorList.Error5()[0]} \n{ErrorList.Error5()[1]}");
                return;
            }

            switch (currentSessionUserType)
            {
                case "Asset Viewer":
                    buttonOthers.Visible = false;
                    buttonTransaction.Visible = false;

                    break;
                case "Asset Coordinator":
                    buttonOthers.Visible = false;
                    buttonAssetRecordsNewAsset.Visible = false;
                    break;
                case "Asset Administrator":
                    buttonAssetRecordsNewAsset.Visible = true;
                    break;
            }

        }

        private void SetData()
        {
            comboBoxProfileDept.Items.Add("GSO-General Services Office");
            comboBoxProfileDept.Items.Add("MHO-Municipal Health Office");
            comboBoxProfileDept.Items.Add("MCR-Municipal Civil Registrar");
            comboBoxProfileDept.Items.Add("MEO-Municipal Engineering Office");
            comboBoxProfileDept.Items.Add("MBO-Municipal Budget Office");
            comboBoxProfileDept.Items.Add("Accounting Office");

            
        }
        // Start
        public void SetSessionHandler(string user_id, string password)
        {
            sessionHandler = new SessionHandler(user_id, password);
            Console.WriteLine(sessionHandler.GetCurrentUserID());

            SetUser();

            InitializedAccessControl();
        }

        private void InitialiazeTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        
            foreach (TabPage tab in tabControl.TabPages)
            {
                tab.Text = "";
            }
            switch (currentSessionUserType)
            {
                case "Asset Viewer":
                    buttonAssetCategoryAdd.Enabled = false;
                    buttonAssetCategoryUpdate.Enabled = false;
                    buttonSupplierAdd.Enabled = false;
                    buttonSupplierUpdate.Enabled = false;
                    break;
                case "Asset Employee":
                    buttonAssetCategoryAdd.Enabled = false;
                    buttonAssetCategoryUpdate.Enabled = false;
                    buttonSupplierAdd.Enabled = false;
                    buttonSupplierUpdate.Enabled = false;
                    break;
                case "Asset Supervisor":
                    buttonAssetCategoryAdd.Enabled = true;
                    buttonAssetCategoryUpdate.Enabled = true;
                    buttonSupplierAdd.Enabled = true;
                    buttonSupplierUpdate.Enabled = true;
                    break;
            }
           
        }

        private void SetUser()
        {

            currentSessionUserType = sessionHandler.GetTypeUser();

            // Load Data RoleBasedID
            string query = "null";

            switch (currentSessionUserType)
            {
                case "Asset Viewer":
                    query = "SELECT assetViewerId, assetViewerOffice FROM AssetViewer WHERE userID = @UserId";
                    currentUser.SetAccessLevel(User.AccessLevel.Viewer);
                    break;
                case "Asset Coordinator":
                    query = "SELECT Id, Office FROM AssetCoordinator WHERE userID = @UserId";
                    currentUser.SetAccessLevel(User.AccessLevel.Coordinator);
                    break;
                case "Asset Administrator":
                    query = "SELECT Id, Office FROM AssetAdministrator WHERE userID = @UserId";
                    currentUser.SetAccessLevel(User.AccessLevel.Administrator);
                    break;
            }


            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@UserId", sessionHandler.GetCurrentUserID());

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);


            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {
                    switch (col.ColumnName)
                    {
                        case "assetViewerId":
                        case "Id":
                            RoleBasedID = row[col].ToString();
                            break;
                        case "assetViewerOffice":
                        case "Office":
                            currentUserOffice = row[col].ToString();
                            break;
                    }
                }
            }

            // Set User

            currentUser.UserRoleBasedID = RoleBasedID;

            //Set
            labelOffice.Text = currentUserOffice;
        

            // Check the session before updating the UI
            if (CheckSession())
            {
                buttonProfile.Visible = true;
                buttonProfile.Text = $"{sessionHandler.GetUserName(databaseConnection)}\n{currentSessionUserType}";
                hamburgerToggle = true;
            }

            worker4.DashboardLoad();
            
            //Control[] sideLabels = { labelSideBarArchRec, labelSideBarAssetRe, labelSideBarGenRep, labelSideBarMisc, labelSideBarTransc, labelSideDashboard };
            //Utilities.SetControlsVisibilityState(sideLabels, true);
        }

       

        private void ProfileTabPanel()
        {

            // Load Data
            string query = "null";

            switch (currentSessionUserType)
            {
                case "Asset Viewer":
                            query = "SELECT assetViewerFName, assetViewerMName, assetViewerLName, " +
                            "assetViewerPhoneNum, assetViewerEmail, " +
                            "assetViewerAddress, assetViewerOffice " +
                            "FROM AssetViewer WHERE userID = @UserId";
                    break;
                case "Asset Coordinator":
                            query = "SELECT FName, MName, LName, " +
                            "PhoneNumber, Email, " +
                            "Address, Office " +
                            "FROM AssetCoordinator WHERE userID = @UserId";
                    break;
                case "Asset Administrator":
                            query = "SELECT FName, MName, LName, " +
                            "PhoneNumber, Email, " +
                            "Address, Office " +
                            "FROM AssetAdministrator WHERE userID = @UserId";
                    break;
            }
           

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@UserId", sessionHandler.GetCurrentUserID());
        
            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string resultString = "";

            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {
                    resultString += row[col] + "/";
                }
            }

            // Add the fetch data to the textboxes
            Console.WriteLine(resultString);

            textBoxProfileName.Text = resultString.Split('/')[0] + " " + resultString.Split('/')[1] + " " + resultString.Split('/')[2];
            textBoxProfilePhoneNumber.Text = resultString.Split('/')[3];
            textBoxProfileEmail.Text = resultString.Split('/')[4];

            textBoxProfileAddress.Text = resultString.Split('/')[5];

            foreach (string item in comboBoxProfileDept.Items)
            {
                if (resultString.Split('/')[6].Equals(item))
                {
                    comboBoxProfileDept.SelectedItem = item;
                }
            }

            textBoxProfilePosition.Text = sessionHandler.GetTypeUser();
            textBoxProfilePassword.Text = sessionHandler.GetCurrentUserPassword();

            databaseConnection.CloseConnection();

            // Load Image

            string user_query = "SELECT userImage FROM Users WHERE userID = @n_user_id";
            Dictionary<string, object> user_parameters = new Dictionary<string, object>();
            user_parameters.Add("@n_user_id", sessionHandler.GetCurrentUserID());

            DataTable user_resultTable = databaseConnection.ReadFromDatabase(user_query, user_parameters);
            Console.WriteLine("DataTable content: ");

            if (user_resultTable.Rows.Count > 0 && user_resultTable.Rows[0][0] != DBNull.Value)
            {
                byte[] imageByte = user_resultTable.Rows[0].Field<byte[]>(0);
                pictureBoxProfileImage.Image = Utilities.ConvertByteArrayToImage(imageByte);
                pictureBoxProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            

            databaseConnection.CloseConnection();

        }

 
        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            worker4.DashboardLoad();
            panelTabControl.SelectedTab = tabDashboard;
            ResetAssetViewedPanel();
        }
        private void ResetAssetViewedPanel()
        {
            panelViewedAssetHandler.Controls.Clear();
            panelViewedAssetHandler.SendToBack();

            panelAssetRecordsHandler.Controls.Clear();
            panelAssetRecordsHandler.SendToBack();
            buttonSearch.Enabled = false;

        }
        private void buttonAssetRecords_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabAssetRecords;

           
            ResetAssetViewedPanel();

            LoadAssets();
        }
        public void LoadAssets()
        {

            Control panelControl = new Panels.AssetRecordsTab.RecordsHomePanel(currentUserOffice, panelViewedAssetHandler, currentUser);


            panelAssetRecordsHandler.Controls.Clear();
            panelControl.Size = panelAssetRecordsHandler.Size;

            Utilities.PanelChanger(panelAssetRecordsHandler, panelControl);
            buttonSearch.Enabled = true;
            textBoxSearchFilter.Enabled = true;
        }

        private void buttonArchiveRecords_Click(object sender, EventArgs e)
        {
            ResetAssetViewedPanel();
            panelTabControl.SelectedTab = tabArchiveRecords;


          

            worker.RunArchiveRecordsComponent(currentUserOffice, currentSessionUserType);

        }


        private void buttonGenerateReports_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabGenReport;
            ResetAssetViewedPanel();
        }


        private void buttonOthers_Click(object sender, EventArgs e)
        {
            ResetAssetViewedPanel();
            panelTabControl.SelectedTab = tabOthers;
            otherTabControl.SelectedTab = tabSupplier;
            labelTitleHandler.Text = "Supplier";

            //Load
            FetchSupplierDataSource();
            
        }
        private void FetchSupplierDataSource()
        {
            dataGridViewSupplier.DataSource = supplierController.GetAllSupplier();

            if (dataGridViewSupplier.Columns["DeleteButtonColumn"] == null)
            {
                if(currentSessionUserType != "Asset Administrator")
                {
                    return;
                }
                // Create a new DataGridViewButtonColumn
                var deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.HeaderText = "Actions";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Name = "DeleteButtonColumn";
                deleteButtonColumn.UseColumnTextForButtonValue = true;

                // Add the button column to the DataGridView
                dataGridViewSupplier.Columns.Add(deleteButtonColumn);

                // Adjust the button column's display index to make it the last column
                deleteButtonColumn.DisplayIndex = dataGridViewSupplier.Columns.Count - 1;
            }
        }
        private void SetActiveTab()
        {

        }
        
        private void buttonProfile_Click(object sender, EventArgs e)
        {
            if (CheckSession())
            {
                panelTabControl.SelectedTab = tabProfile;
                ProfileTabPanel();

                buttonProfile.BackColor = clickColor;
            }

           
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ResetAssetViewedPanel();
            panelTabControl.SelectedTab = tabAbout;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ResetAssetViewedPanel();
            panelTabControl.SelectedTab = tabAbout;
        }

        private void InitializeProfileTabControls()
        {
            checkBoxButtonProfileShowPassword.Appearance = System.Windows.Forms.Appearance.Button;

            

            profileTabControls.Add(buttonEditProfile);
            profileTabControls.Add(buttonProfileSave);
            profileTabControls.Add(buttonProfileCancel);
            
            
            profileTabControls.Add(textBoxProfilePhoneNumber);
            profileTabControls.Add(textBoxProfileEmail);
            profileTabControls.Add(textBoxProfilePassword);
            profileTabControls.Add(comboBoxProfileDept);
            profileTabControls.Add(textBoxProfileAddress);
            profileTabControls.Add(buttonProfileUploadImage);

            profileTabControls.Add(checkBoxButtonProfileShowPassword);


            SetListControlStateTo(profileTabControls, false);

            buttonEditProfile.Enabled = true;
            buttonProfileSave.Visible = false;
            buttonProfileCancel.Visible = false;
            buttonProfileUploadImage.Visible = false;
            //Fetch Data
        }
        private void buttonTransaction_Click(object sender, EventArgs e)
        {
            ResetAssetViewedPanel();
            panelTabControl.SelectedTab = tabTransaction;

            LoadTranscationPanel();
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
            buttonProfileUploadImage.Visible = true;


        }

        private void checkBoxButtonProfileShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxProfilePassword.UseSystemPasswordChar = !checkBoxButtonProfileShowPassword.Checked;

            if (checkBoxButtonProfileShowPassword.Checked)
            {
                checkBoxButtonProfileShowPassword.Text = "SHOW";
            }
            else
            {
                checkBoxButtonProfileShowPassword.Text = "HIDE";
            }
        }

        private void buttonProfileCancel_Click(object sender, EventArgs e)
        {
            SetListControlStateTo(profileTabControls, false);

            DialogBoxes.AlertDialogBox alertDialogBox = new DialogBoxes.AlertDialogBox();
            alertDialogBox.SetDialog("CONFIRM CANCEL", "ANY CHANGES DONE IN THE PROFILE WILL BE DISCARDED.");
            alertDialogBox.ShowDialog();
            buttonEditProfile.Enabled = true;
            buttonEditProfile.Visible = true;
            buttonProfileSave.Visible = false;
            buttonProfileCancel.Visible = false;
            buttonProfileUploadImage.Visible = false;
            ProfileTabPanel();
        }
        
        private void buttonProfileSave_Click(object sender, EventArgs e)
        {
            if (CheckSession())
            {
                // Save Data
                string query = "null";

                switch (currentSessionUserType)
                {
                    case "Asset Viewer":
                        query =
                            "UPDATE AssetViewer" +
                            " SET " +
                            "assetViewerFName = @firstName, " +
                            "assetViewerMName = @middleName, " +
                            "assetViewerLName = @lastName, " +
                            "assetViewerPhoneNum = @phoneNumber, " +
                            "assetViewerEmail = @email, " +
                            "assetViewerAddress = @address, " +
                            "assetViewerOffice = @office " +
                            "WHERE userId = @UserId";

                        break;
                    case "Asset Coordinator":
                        query =
                            "UPDATE AssetCoordinator" +
                            " SET " +
                            "FName = @firstName, " +
                            "MName = @middleName, " +
                            "LName = @lastName, " +
                            "PhoneNumber = @phoneNumber, " +
                            "Email = @email, " +
                            "Address = @address, " +
                            "Office = @office " +
                            "WHERE userId = @UserId";
                        break;
                    case "Asset Administrator":
                        query =
                             "UPDATE AssetAdministrator" +
                             " SET " +
                             "FName = @firstName, " +
                             "MName = @middleName, " +
                             "LName = @lastName, " +
                             "PhoneNumber = @phoneNumber, " +
                             "Email = @email, " +
                             "Address = @address, " +
                             "Office = @office " +
                             "WHERE userId = @UserId";
                        break;

                }

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@UserId", sessionHandler.GetCurrentUserID() },
                    { "@firstName", textBoxProfileName.Text.Split(' ')[0] },
                    { "@middleName", textBoxProfileName.Text.Split(' ')[1] },
                    { "@lastName", textBoxProfileName.Text.Split(' ')[2] },
                    { "@phoneNumber", textBoxProfilePhoneNumber.Text },
                    { "@email", textBoxProfileEmail.Text },
                    { "@address", textBoxProfileAddress.Text },
                    { "@office", comboBoxProfileDept.SelectedItem.ToString() }
                };

                databaseConnection.UploadToDatabase(query, parameters);
                databaseConnection.CloseConnection();

                //image upload
                if (imagedata != null)
                {
                    string _query = "UPDATE Users SET userImage = @img WHERE userID = @userId";
                    Dictionary<string, object> _parameters = new Dictionary<string, object>

                        {
                            { "@userId", sessionHandler.GetCurrentUserID() },
                            { "@img", imagedata }

                        };

                    databaseConnection.UploadToDatabase(_query, _parameters);
                    databaseConnection.CloseConnection();

                    imagedata = null;
                }

                string user_query = "UPDATE Users SET userPassword = @new_pass WHERE userID = @n_pass";

                Dictionary<string, object> user_parameters = new Dictionary<string, object>
                {
                    { "@n_pass", sessionHandler.GetCurrentUserID() },
                    { "@new_pass ",  textBoxProfilePassword.Text}
                };

                if (!string.IsNullOrEmpty(textBoxProfilePassword.Text))
                {
                    databaseConnection.UploadToDatabase(user_query, user_parameters);

                    MessagePrompt("Account Profile Edited Successfully!");

                    databaseConnection.CloseConnection();

                    // Load Data for User
                    string p_user_query = "SELECT userPassword FROM Users WHERE userID = @UserId";
                    Dictionary<string, object> p_user_parameters = new Dictionary<string, object>();
                    p_user_parameters.Add("@UserId", sessionHandler.GetCurrentUserID());

                    DataTable p_resultTable = databaseConnection.ReadFromDatabase(p_user_query, p_user_parameters);
                    sessionHandler.OnCurrentSessionSafeChangePassword(p_resultTable.Rows[0][0].ToString());

                    SetListControlStateTo(profileTabControls, false);

                    buttonEditProfile.Enabled = true;
                    buttonEditProfile.Visible = true;
                    buttonProfileSave.Visible = false;
                    buttonProfileCancel.Visible = false;
                    buttonProfileUploadImage.Visible = false;

                    ProfileTabPanel();
                }
                else
                {
                    using (DialogBoxes.AlertDialogBox alertDialogBox = new DialogBoxes.AlertDialogBox())
                    {
                        alertDialogBox.SetDialog(ErrorList.Error3()[0], ErrorList.Error3()[1]);
                        if (alertDialogBox.ShowDialog() == DialogResult.OK)
                        {
                            
                        }
                    }
                }

                
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            using(DialogBoxes.LogOutConfirmationDialog logOut = new DialogBoxes.LogOutConfirmationDialog())
            {
                logOut.ShowDialog();

                if(logOut.GetResult() == DialogResult.OK)
                {
                    sessionHandler.OnCurrentSessionEnd();
                    currentSessionUserType = "";


                    StartForm startForm = new StartForm();
                    startForm.FormClosed += (s, args) => this.Close();
                    startForm.Show();

                    this.Hide();
                }
            }
           
        }


        bool hamburgerToggle;
        private void buttonHamburger_Click(object sender, EventArgs e)
        {
            ResetAssetViewedPanel();
            
            /*
            if (CheckSession())
            {
                if (hamburgerToggle != true)
                {
                    groupBoxSide.Size = new Size(200, 820);
                    buttonHamburger.BackColor = Color.FromArgb(68, 113, 68);
                    Utilities.SetControlsVisibilityState(sideLabels, true);

                    
                }
                else
                {
                    buttonProfile.Visible = false;
                    groupBoxSide.Size = new Size(70, 820);

                    hamburgerToggle = false;

                    buttonHamburger.BackColor = Color.FromArgb(225, 232, 225);

                    buttonProfile.BackColor = Color.FromArgb(128, 200, 128);

                    Utilities.SetControlsVisibilityState(sideLabels, false);
                }
            }
            */

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            worker4.ResizePanels("All");
            Console.WriteLine("roundedPanelTotalAsset: " + roundedPanelTotalAsset.Size);
            Console.WriteLine("roundedPanelCategoryCount: " + roundedPanelCategoryCount.Size);
        }

   

        private void MasterExit()
        {
            StartForm form = (StartForm)Application.OpenForms["StartForm"];
            form.Close();
        }

        private bool CheckSession()
        {
            if (sessionHandler.isCurrentSessionActive() == false)
            {
                using (DialogBoxes.AlertDialogBox alertDialogBox = new DialogBoxes.AlertDialogBox())
                {
                    alertDialogBox.SetDialog(ErrorList.Error1()[0], ErrorList.Error1()[1]);
                    if (alertDialogBox.ShowDialog() == DialogResult.OK)
                    {
                        MasterExit();
                    }
                }

                return false; // Return false when the session is not active
            }

            return true; // Return true when the session is active
        }

        private void buttonProfileUploadImage_Click(object sender, EventArgs e)
        {
            using (DialogBoxes.UploadImageDialogBox uploadImageDialogBox = new DialogBoxes.UploadImageDialogBox())
            {
                if (uploadImageDialogBox.ShowDialog() == DialogResult.OK)
                {
                    byte[] _imagedata = uploadImageDialogBox.imageByte;
                    if (_imagedata != null)
                    {
                        imagedata = _imagedata;
                        pictureBoxProfileImage.Image = Utilities.ConvertByteArrayToImage(imagedata);
                    } 
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void buttonMasterExit_Click_1(object sender, EventArgs e)
        {
            MasterExit();
        }

        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            labelTitleHandler.Text = "Supplier";
            otherTabControl.SelectedTab = tabSupplier;

            SupplierReset();
        }

        private void FetchOperatorDataSource()
        {
            dataGridViewOtherOperator.DataSource = null;

            DataTable dataTable = assetOperatorRepositoryControl.GetAllOperators().resultTable;
            foreach (DataColumn column in dataTable.Columns)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = column.ColumnName;
                col.Name = column.ColumnName;
                //col.HeaderText = column.ColumnName;
                switch (column.ColumnName)
                {
                   
                    case "FName":
                        col.HeaderText = "Coordinator First Name";
                        break;
                    case "MName":
                        col.HeaderText = "Coordinator Middle Name";
                        break;
                    case "LName":
                        col.HeaderText = "Coordinator Last Name Name";
                        break;
                    case "PhoneNumber":
                        col.HeaderText = "Coordinator Phone Number";
                        break;
                    case "Email":
                        col.HeaderText = "Coordinator Email";
                        break;
                    case "Address":
                        col.HeaderText = "Coordinator Address";
                        break;
                    case "Office":
                        col.HeaderText = "Coordinator Office";
                        break;
               
                    default:
                        col.HeaderText = column.ColumnName;
                        break;
                }

                col.Width = TextRenderer.MeasureText(column.ColumnName, dataGridViewOtherOperator.Font).Width + 90;

                dataGridViewOtherOperator.Columns.Add(col);
            }

            if (dataGridViewOtherOperator.Columns["ViewButtonColumn"] == null)
            {
                // Create a new DataGridViewButtonColumn
                var viewButtonColumn = new DataGridViewButtonColumn();
                viewButtonColumn.HeaderText = "Actions";
                viewButtonColumn.Text = "View Handled Assets";
                viewButtonColumn.Name = "ViewButtonColumn";
                viewButtonColumn.UseColumnTextForButtonValue = true;

                // Add the button column to the DataGridView
                dataGridViewOtherOperator.Columns.Add(viewButtonColumn);

                // Adjust the button column's display index to make it the last column
                viewButtonColumn.DisplayIndex = dataGridViewOtherOperator.Columns.Count - 1;
            }

            dataGridViewOtherOperator.DataSource = assetOperatorRepositoryControl.GetAllOperators().resultTable;
        }
        private void buttonOperators_Click(object sender, EventArgs e)
        {
            
            labelTitleHandler.Text = "Employees";
            otherTabControl.SelectedTab = tabOperator;

            OtherOperatorReset();

            FetchOperatorDataSource();
        }

        private void FetchAssetCategories()
        {
            dataGridViewAssetCategories.DataSource = assetCategoriesController.GetAllAssetCategories();
            if (dataGridViewAssetCategories.Columns["DeleteButtonColumn"] == null)
            {
                if (currentSessionUserType != "Asset Administrator")
                {
                    return;
                }
                // Create a new DataGridViewButtonColumn
                var deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.HeaderText = "Actions";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Name = "DeleteButtonColumn";
                deleteButtonColumn.UseColumnTextForButtonValue = true;

                // Add the button column to the DataGridView
                dataGridViewAssetCategories.Columns.Add(deleteButtonColumn);

                // Adjust the button column's display index to make it the last column
                deleteButtonColumn.DisplayIndex = dataGridViewAssetCategories.Columns.Count - 1;
            }
        }
        private void buttonAssetCategories_Click(object sender, EventArgs e)
        {
            labelTitleHandler.Text = "Asset Categories";
            otherTabControl.SelectedTab = tabAssetCategories;

            SupplierReset();

            //load
            FetchAssetCategories();
        }

        /*
         * 
         * Progress Here
         * 
         */
        private void buttonSupplierAdd_Click(object sender, EventArgs e)
        {
            string supplierName = textBoxSupplierName.Text;
            string supplierPhoneNumber = textBoxSupplierPhoneNumber.Text;
            string supplierAddress = textBoxSupplierAddress.Text;

            if (string.IsNullOrEmpty(supplierName))
            {
                MessagePrompt("Please Input Name");
            }
            else if (string.IsNullOrEmpty(supplierPhoneNumber))
            {
                MessagePrompt("Please Input Phone Number");
            }
            else if (string.IsNullOrEmpty(supplierAddress))
            {
                MessagePrompt("Please Input Address");
            }
            else
            {
                var result = supplierController.AddNewSupplier(supplierName, supplierPhoneNumber, supplierAddress);

                if (result.Success)
                {
                    MessagePrompt($"Supplier has been successfully added! \nName: {supplierName}\nPhoneNumber: {supplierPhoneNumber}\nAddress: {supplierAddress} ");
                    textBoxSupplierName.Text = "";
                    textBoxSupplierPhoneNumber.Text = "";
                    textBoxSupplierAddress.Text = "";

                    SupplierReset();

                    dataGridViewSupplier.DataSource = supplierController.GetAllSupplier();
                }
                else
                {
                    MessagePrompt($"Supplier addition failed: {result.ErrorMessage}");
                }
            }
        }

        private void MessagePrompt(string message)
        {
            DialogBoxes.MessagePromptDialogBox prompt = new DialogBoxes.MessagePromptDialogBox();
            prompt.SetMessage(message);
            prompt.Show();
        }

        string currentSelectedSupplier;
        private void dataGridViewSupplier_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridViewSupplier.Rows[e.RowIndex];
                currentSelectedSupplier = currentSelectedSupplier = row.Cells["supplierId"].Value.ToString();

                textBoxSupplierName.Text = row.Cells[1].Value.ToString();
                textBoxSupplierPhoneNumber.Text = row.Cells[2].Value.ToString();
                textBoxSupplierAddress.Text = row.Cells[3].Value.ToString();

                Control[] buttoncontrols = { buttonSupplierViewSuppliedAssets, buttonSupplierUpdate };
                Utilities.SetButtonsState(buttoncontrols, true);

                currentlySelectedSupplierId = currentSelectedSupplier;
                currentlySelectedSupplierName = textBoxSupplierName.Text;

                if (e.ColumnIndex == dataGridViewSupplier.Columns["DeleteButtonColumn"].Index)
                {
                    currentSelectedSupplier = currentSelectedSupplier = row.Cells["supplierId"].Value.ToString();
                    Console.WriteLine($"hey {currentSelectedSupplier}");
                    if (!string.IsNullOrEmpty(currentSelectedSupplier))
                    {
                        var result = supplierController.DeleteSupplierEntry(currentSelectedSupplier);

                        if (result.Success)
                        {

                            MessagePrompt($"Supplier has been successfully deleted");
                           
                        }
                        else
                        {
                            MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
                        }

                        SupplierReset();
                        FetchSupplierDataSource();
                    }
                }
            }

        }

        string currentlySelectedSupplierId, currentlySelectedSupplierName;
        private void buttonSupplierViewSuppliedAssets_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentlySelectedSupplierId))
            {
                if (!string.IsNullOrEmpty(currentlySelectedSupplierName))
                {
                    Control panelControl = new Panels.SupplierSuppliedAssetPanel(panelViewSuppliedAssetHolder, currentlySelectedSupplierId, currentlySelectedSupplierName);
                    panelViewSuppliedAssetHolder.Controls.Add(panelControl);
                    panelViewSuppliedAssetHolder.BringToFront();
                    panelViewSuppliedAssetHolder.Visible = true;
                }
            }
            
        }

        private void buttonSupplierClearFields_Click(object sender, EventArgs e)
        {
            SupplierReset();

        }


        private void buttonSupplierUpdate_Click(object sender, EventArgs e)
        {
            string supplierName = textBoxSupplierName.Text;
            string supplierPhoneNumber = textBoxSupplierPhoneNumber.Text;
            string supplierAddress = textBoxSupplierAddress.Text;

            if (string.IsNullOrEmpty(supplierName))
            {
                MessagePrompt("Please Input Name");
            }
            else if (string.IsNullOrEmpty(supplierPhoneNumber))
            {
                MessagePrompt("Please Input Phone Number");
            }
            else if (string.IsNullOrEmpty(supplierAddress))
            {
                MessagePrompt("Please Input Address");
            }
            else
            {
                var result = supplierController.UpdateSupplierEntry(currentSelectedSupplier, supplierName, supplierPhoneNumber, supplierAddress);

                if (result.Success)
                {
                    MessagePrompt($"Supplier has been successfully updated");
                }
                else
                {
                    MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
                }

                SupplierReset();

                FetchSupplierDataSource();
            }

        }

        private void SupplierReset()
        {
            Control[] buttoncontrols = { buttonSupplierViewSuppliedAssets, buttonSupplierUpdate };
            Utilities.SetButtonsState(buttoncontrols, false);

            Control[] fieldcontrols = { textBoxSupplierName, textBoxSupplierPhoneNumber, textBoxSupplierAddress };
            Utilities.ClearTextFieldsHandler(fieldcontrols);

            dataGridViewSupplier.ClearSelection();

            currentSelectedSupplier = "";
        }

        private void AssetCategoryReset()
        {
            Control[] buttoncontrols = {  buttonAssetCategoryUpdate };
            Utilities.SetButtonsState(buttoncontrols, false);

            Control[] fieldcontrols = { textBoxAssetCategoryName, richTextBoxAssetCategoryDesc };
            Utilities.ClearTextFieldsHandler(fieldcontrols);

            dataGridViewAssetCategories.ClearSelection();

            currentSelectedAssetCategoryId = "";
        }

        private void buttonAssetCategoryAdd_Click(object sender, EventArgs e)
        {
            AssetCategory assetCategory = new AssetCategory();
            
            string assetCategoryName = textBoxAssetCategoryName.Text;
            string assetCategoryDescription = richTextBoxAssetCategoryDesc.Text;


            if (string.IsNullOrEmpty(assetCategoryName))
            {
                MessagePrompt("Please Input Name");
            }
            else if (string.IsNullOrEmpty(assetCategoryDescription))
            {
                MessagePrompt("Please Input Description");
            }
            else
            {
                assetCategory.AssetCategoryDescription = assetCategoryDescription;
                assetCategory.AssetCategoryName = assetCategoryName;

                var result = assetCategoryRepositoryControl.AddToDatabase(assetCategory);
                if (result.Success)
                {
                    MessagePrompt($"Asset Category: {assetCategory.AssetCategoryName} has been successfully updated");

                    dataGridViewAssetCategories.DataSource = assetCategoriesController.GetAllAssetCategories();
                    AssetCategoryReset();
                }
                else
                {
                    MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
                }
            }

        }

        private void buttonAssetCategoryUpdate_Click(object sender, EventArgs e)
        {

        }


        private void buttonAssetCategoryClearFields_Click(object sender, EventArgs e)
        {
            AssetCategoryReset();
        }

        string currentSelectedAssetCategoryId;
        private void dataGridViewAssetCategories_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAssetCategories.Rows[e.RowIndex];
                currentSelectedAssetCategoryId = row.Cells[0].Value.ToString();

                textBoxAssetCategoryName.Text = row.Cells[1].Value.ToString();
                richTextBoxAssetCategoryDesc.Text = row.Cells[2].Value.ToString();

                
                if (e.ColumnIndex == dataGridViewAssetCategories.Columns["DeleteButtonColumn"].Index)
                {
                    currentSelectedAssetCategoryId = row.Cells["assetCategoryId"].Value.ToString();

                    AssetCategory assetCategory = new AssetCategory();
                    assetCategory.AssetCategoryId = currentSelectedAssetCategoryId;
                    assetCategory.AssetCategoryDescription = richTextBoxAssetCategoryDesc.Text;
                    assetCategory.AssetCategoryName = textBoxAssetCategoryName.Text;

                    if (!string.IsNullOrEmpty(currentSelectedAssetCategoryId))
                    {
                        var result = assetCategoryRepositoryControl.DeleteToDatabase(assetCategory);

                        if (result.Success)
                        {

                            MessagePrompt($"Supplier has been successfully deleted");

                        }
                        else
                        {
                            MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
                        }

                        AssetCategoryReset();
                        FetchAssetCategories();
                    }
                }

            }
        }

        private void dataGridViewOtherOperator_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewOtherOperator.Rows[e.RowIndex];
                string operator_id = row.Cells["Id"].Value.ToString();
                string name = row.Cells["FName"].Value.ToString()  + row.Cells["LName"].Value.ToString();
                
                Console.WriteLine("Heyyyyy: " + operator_id);

                Control[] fieldcontrols = { textBoxOperatorFirstName, textBoxOperatorMiddleName,
                    textBoxOperatorLastName, textBoxOperatorPhoneNumber, richTextBoxOperatorAdress, textBoxOperatorOffice };

                if (e.ColumnIndex == dataGridViewOtherOperator.Columns["ViewButtonColumn"].Index)
                {
                    Control panelControl = new Panels.OperatorHandledAssetPanel(panelOperatorHandler, operator_id, name, fieldcontrols);
                    panelOperatorHandler.Controls.Add(panelControl);
                    panelOperatorHandler.BringToFront();
                    panelOperatorHandler.Visible = true;

                    
                    Utilities.SetControlsVisibilityState(fieldcontrols, false);
                }

                textBoxOperatorFirstName.Text = row.Cells["FName"].Value.ToString();
                textBoxOperatorLastName.Text = row.Cells["LName"].Value.ToString();
                textBoxOperatorMiddleName.Text = row.Cells["MName"].Value.ToString();
                textBoxOperatorPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
                richTextBoxOperatorAdress.Text = row.Cells["Address"].Value.ToString();
                textBoxOperatorOffice.Text = row.Cells["Office"].Value.ToString();
            }
        }
        private void OtherOperatorReset()
        {
            Control[] fieldcontrols = { textBoxOperatorFirstName, textBoxOperatorMiddleName,
                textBoxOperatorLastName, textBoxOperatorPhoneNumber, richTextBoxOperatorAdress, textBoxOperatorOffice };
            Utilities.ClearTextFieldsHandler(fieldcontrols);

            dataGridViewOtherOperator.ClearSelection();
        }

        private void buttonAssetRecordsNewAsset_Click(object sender, EventArgs e)
        {
            DialogBoxes.OptionDialogBox optionDialogBox = new DialogBoxes.OptionDialogBox(panelAssetRecordsHandler, RoleBasedID, currentUserOffice, this);
            Console.WriteLine(RoleBasedID);
            optionDialogBox.ShowDialog();
            
        }

        private void buttonAssetRecordsViewRecords_Click(object sender, EventArgs e)
        {
            LoadAssets();
        }

        
        private void buttonOperatorClearFields_Click_1(object sender, EventArgs e)
        {
            OtherOperatorReset();
        }

        private void ButtonMouseHover(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(68, 113, 68);
                
            }
        }
        private void ButtonMouseEnd(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(225, 232, 225);

            }
        }

        private void Set(object sender, EventArgs e)
        {

        }

        private void panelAssetRecordsHandler_Resize(object sender, EventArgs e)
        {
            //LoadAssets();
        }

        private void panelTabControl_Resize(object sender, EventArgs e)
        {

        }

        private void tabAssetRecords_Resize(object sender, EventArgs e)
        {
           
            if(panelViewedAssetHandler.Controls.Count == 1)
            {
                return;
            }

            if (this.WindowState == FormWindowState.Maximized)
            {
                LoadAssets();


             
            }
            else if (this.WindowState == FormWindowState.Normal)
            {

                LoadAssets();
             
            }
        }

        private void panelViewedAssetHandler_Resize(object sender, EventArgs e)
        {
           

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (panelAssetRecordsHandler.Controls.Count > 0)
            {
                Panels.AssetRecordsTab.RecordsHomePanel recordsHomePanel = (Panels.AssetRecordsTab.RecordsHomePanel)panelAssetRecordsHandler.Controls[0];
                DataGridView dgv1 = recordsHomePanel.DataGridViewAssetRecords;

                string searchKeyword = textBoxSearchFilter.Text.Trim();

                DataTable dataTable = (DataTable)dgv1.DataSource;


                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        string filterExpression = $"assetName LIKE '%{searchKeyword}%' OR assetPropertyNumber LIKE '%{searchKeyword}%'";


                        dataTable.DefaultView.RowFilter = filterExpression;
                    }
                    else
                    {

                        dataTable.DefaultView.RowFilter = string.Empty;
                    }
                }
            }
        }



        private void textBoxSearchFilter_TextChanged(object sender, EventArgs e)
        {
            buttonSearch.PerformClick();
        }

        private void textBoxSearchFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dataGridViewArchiveRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewArchiveRecords.Rows[e.RowIndex];

                if (e.ColumnIndex == dataGridViewArchiveRecords.Columns["UnArchiveAssetColumn"].Index)
                {
                    Asset selectedAsset = new Asset();

                    selectedAsset.AssetId = Convert.ToInt32(selectedRow.Cells["assetId"].Value);

                    selectedAsset.AssetSupervisorId = Convert.ToInt32(selectedRow.Cells["AAdminFullName"].Value.ToString().Split(';')[1].Trim());
                    selectedAsset.CurrentEmployeeId = Convert.ToInt32(selectedRow.Cells["currentCustodianCoordinatorFullName"].Value.ToString().Split(';')[1].Trim());

                    selectedAsset.SupplierId = Convert.ToInt32(selectedRow.Cells["Supplier"].Value.ToString().Split(';')[1].Trim());
                    selectedAsset.AssetCategoryId = Convert.ToInt32(selectedRow.Cells["AssetCategory"].Value.ToString().Split(';')[1].Trim());

                    selectedAsset.SupplierName = selectedRow.Cells["Supplier"].Value.ToString().Split(';')[0].Trim();
                    selectedAsset.EmployeeName = selectedRow.Cells["currentCustodianCoordinatorFullName"].Value.ToString().Split(';')[0].Trim();
                    selectedAsset.AssetCategoryName = selectedRow.Cells["AssetCategory"].Value.ToString().Split(';')[0].Trim();

                    /*
                 string assetLastMaintenanceValue = selectedRow.Cells["assetLastMaintenance"].Value.ToString();
                 if (assetLastMaintenanceValue != "")
                 {
                     selectedAsset.AssetLastMaintenanceID = Convert.ToInt32(assetLastMaintenanceValue);
                 }

                 selectedAsset.AssetAvailability = selectedRow.Cells["assetAvailability"].Value.ToString();

                 */
                    selectedAsset.AssetName = selectedRow.Cells["assetName"].Value.ToString();
                    selectedAsset.AssetLocation = selectedRow.Cells["assetLocation"].Value.ToString();

                    selectedAsset.QRCode = selectedRow.Cells["assetQrStrDefinition"].Value.ToString();

                    selectedAsset.AssetQRCodeImage = (byte[])selectedRow.Cells["assetQrCodeImage"].Value;
                    selectedAsset.AssetImage = (byte[])selectedRow.Cells["assetImage"].Value;

                    selectedAsset.AssetCondition = selectedRow.Cells["assetCondition"].Value.ToString();

                    selectedAsset.IsArchive = Convert.ToBoolean(selectedRow.Cells["assetIsArchive"].Value);
                    selectedAsset.IsMissing = Convert.ToBoolean(selectedRow.Cells["assetIsMissing"].Value);
                    selectedAsset.IsMaintainable = Convert.ToBoolean(selectedRow.Cells["assetIsMaintainable"].Value);

                    selectedAsset.AssetPurchaseAmount = Convert.ToDecimal(selectedRow.Cells["assetPurchaseAmount"].Value);
                    selectedAsset.AssetPurchaseDate = Convert.ToDateTime(selectedRow.Cells["assetAcknowledgeDate"].Value);
                    //selectedAsset.AssetMaintenanceLogsID = selectedRow.Cells["assetMaintenanceLogsID"].Value.ToString();
                    selectedAsset.AssetQuantity = Convert.ToInt32(selectedRow.Cells["assetQuantity"].Value);
                    selectedAsset.AssetUnit = selectedRow.Cells["assetUnit"].Value.ToString();
                    /*
                    selectedAsset.AssetLifeSpan = Convert.ToInt32(selectedRow.Cells["assetLifeSpan"].Value);
                    */
                    //added
                    selectedAsset.AssetPurpose = selectedRow.Cells["assetPurpose"].Value.ToString();
                    selectedAsset.AssetDescription = selectedRow.Cells["assetDescription"].Value.ToString();
                    selectedAsset.AssetPropertyNumber = Convert.ToInt32(selectedRow.Cells["assetPropertyNumber"].Value);

                    AssetRepositoryControl assetRepositoryControl = new AssetRepositoryControl();
                    Asset archivedAsset = new Asset();
                    archivedAsset = selectedAsset;
                    archivedAsset.IsArchive = false;

                    var result = assetRepositoryControl.SetArchiveState(archivedAsset);

                    if (result.Success)
                    {

                        worker.RunArchiveRecordsComponent(currentUserOffice, currentSessionUserType);

                        MessagePrompt($"Asset has been successfully unarchived");
                    }
                    else
                    {
                        MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
                    }
                }
            }
        }

        private void textBoxArchiveRecordsSearch_TextChanged(object sender, EventArgs e)
        {
            worker.PerformArchiveRecordSearch();
        }
        
        private void roundedButtonSearchArchiveRecords_Click(object sender, EventArgs e)
        {
            worker.PerformArchiveRecordSearch();


        }

        private void roundedButtonRent_Click(object sender, EventArgs e)
        {
            tabControlTransaction.SelectedTab = tabPageRent;
        }

        private void roundedButtonTrasnfer_Click(object sender, EventArgs e)
        {
            tabControlTransaction.SelectedTab = tabPageTransfer;

            worker2.LoadTransactionPanel();
        }

        private void roundedButtonReqBorrow_Click(object sender, EventArgs e)
        {
            tabControlTransaction.SelectedTab = tabPageRequestAndBorrow;
        }




        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // If the form is closed by the user, exit the application
                Application.Exit();
            }
        }

        
        private void LoadTranscationPanel()
        {
            worker1.LoadRentPanel();
           
        }

        private void roundedButtonTransactionRentAssetFilterCLear_Click(object sender, EventArgs e)
        {
            worker1.AssetSearchFilterClear();
        }

       
        private void dataGridViewTransactionRentAsset_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewTransactionRentAsset.Rows[e.RowIndex];
                
                worker1.DataGridViewCellMouseClick(Convert.ToInt32(selectedRow.Cells[2].Value.ToString()));
                Console.WriteLine(selectedRow.Cells[2].Value.ToString());
            }
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (DialogBoxes.TransactionConfirmationPrompt prompt = new DialogBoxes.TransactionConfirmationPrompt())
            {
                Asset confirmedAsset = worker1.AssetInProcess();

                if (confirmedAsset == null)
                {
                    return;
                }

                prompt.listBox1.Items.Add("");
                prompt.SetConfirmationTitle("\t Asset Rent Confirmation");

                prompt.listBox1.Items.Add("\t Asset Information");
                prompt.listBox1.Items.Add("");
                prompt.listBox1.Items.Add($"\t Asset Name: {confirmedAsset.AssetName}");
                prompt.listBox1.Items.Add($"\t Asset Property Number: {confirmedAsset.AssetPropertyNumber}");
                var result = assetOperatorRepositoryControl.GetCoordinatorName(confirmedAsset.CurrentEmployeeId);
                prompt.listBox1.Items.Add($"\t Asset Current Custodian/Coordinator: {result.name}");
                prompt.listBox1.Items.Add($"\t Asset Purpose: {confirmedAsset.AssetPurpose}");
                prompt.listBox1.Items.Add($"\t Asset Description: {confirmedAsset.AssetDescription}");

                prompt.listBox1.Items.Add("");
                prompt.listBox1.Items.Add("\t Rentee Information");
                prompt.listBox1.Items.Add("");
                prompt.listBox1.Items.Add($"\t Rentee Name: {textBoxTransactionRenteeFName.Text} {textBoxTransactionRenteeMName.Text} {textBoxTransactionRenteeLName.Text}");
                prompt.listBox1.Items.Add($"\t Rentee Birthdate: {dateTimeTransactionRenteeBDate.Text}");
                prompt.listBox1.Items.Add($"\t Rentee Contact Number: {textBoxTransactionRenteeContactNumber.Text}");
                prompt.listBox1.Items.Add($"\t Rentee Address: {richTextBoxTransactionRenteeAddr.Text}");
                prompt.listBox1.Items.Add($"\t Rentee License ID: {textBoxTransactionRenteeLicenseID.Text}");

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    worker1.InitiateAssetTransfer();
                    MessagePrompt("Transaction completed.");
                }

            }

            
        }

        private void roundedButtonTransactionRenteeDocUpload_Click(object sender, EventArgs e)
        {
            worker1.InitiateImageUploader();
        }

        private void roundedButtonTransactionTransferAssetCatApply_Click(object sender, EventArgs e)
        {
            worker2.CategoryListApplyFilter();
        }

        private void roundedButtonTransactionTransferAssetCatClear_Click(object sender, EventArgs e)
        {
            worker2.AssetSearchFilterClear();
        }

        

        private void dataGridViewTransactionTransferAssetList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewTransactionTransferAssetList.Rows[e.RowIndex];

                worker2.DataGridViewCellMouseClick(Convert.ToInt32(selectedRow.Cells[2].Value.ToString()));
                Console.WriteLine(selectedRow.Cells[2].Value.ToString());
            }
        }

        private void roundedButtonTransactionTransferUploadDocument_Click(object sender, EventArgs e)
        {
            worker2.InitiateImageUploader();
        }

        private void roundedButtonTransactionTransferSearchName_Click(object sender, EventArgs e)
        {
            worker2.FilterListCoordinators();
        }

        private void roundedButtonTransactinTransfer_Click(object sender, EventArgs e)
        {
            using (DialogBoxes.TransactionConfirmationPrompt prompt = new DialogBoxes.TransactionConfirmationPrompt())
            {
                
                if(prompt.ShowDialog() == DialogResult.OK)
                {
                    worker2.InitiateTransferAsset();
                    MessagePrompt("Transaction completed.");
                }

            }
        }

        private void textBoxTransactionTransferName_TextChanged(object sender, EventArgs e)
        {
            worker2.FilterListCoordinators();
        }

        private void dataGridViewTransactionTransferReceiver_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewTransactionTransferReceiver.Rows[e.RowIndex];

                worker2.DataGridViewReceiverCellMouseClick(Convert.ToInt32(selectedRow.Cells[0].Value.ToString()));
                
            }
        }

        private void roundedButtonReportAnIssue_Click(object sender, EventArgs e)
        {
            DialogBoxes.ReportIssueDialogBox rpt = new DialogBoxes.ReportIssueDialogBox(sessionHandler.GetUserName(databaseConnection));
            rpt.ShowDialog();
        }

        private void roundedButtonUserManual_Click(object sender, EventArgs e)
        {
            string projectFolderPath = GetProjectFolderPath();
            string resourcesFolderPath = Path.Combine(projectFolderPath, "Documents");
                
            
            string pdfFilePath = Path.Combine(resourcesFolderPath, "User Manual.pdf");
            Console.WriteLine("fpath: " + pdfFilePath);
            OpenPdfWithDefaultViewer(pdfFilePath);
        }

        static void OpenPdfWithDefaultViewer(string filePath)
        {
            try
            {
                // Use the default PDF viewer associated with the system
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening PDF: {ex.Message}");
            }
        }

        static string GetProjectFolderPath()
        {
            // Get the base directory of the current application domain
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        private void roundedButtonAboutPolicy_Click(object sender, EventArgs e)
        {
            DialogBoxes.InformationForm rpt = new DialogBoxes.InformationForm();
            rpt.ShowPolicy();
        }

        private void roundedButtonAboutTOS_Click(object sender, EventArgs e)
        {
            DialogBoxes.InformationForm rpt = new DialogBoxes.InformationForm();
            rpt.ShowTOS();
        }

        private void roundedButtonMissingRecords_Click(object sender, EventArgs e)
        {
            ResetAssetViewedPanel();
            worker5.LoadMissingRecords();

            panelTabControl.SelectedTab = tabMissing;
            
        }

        private void roundedButtonMissingRecordsSearch_Click(object sender, EventArgs e)
        {
            worker5.Search();
        }

        private void textBoxMissingRecords_TextChanged(object sender, EventArgs e)
        {
            worker5.Search();
        }

        private void roundedButtonTransactionRentCatApply_Click(object sender, EventArgs e)
        {
            worker1.CategoryListApplyFilter();
        }
    }
}
