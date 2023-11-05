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

        //Session
        string currentSessionUserType;

        //Color
        Color clickColor = Color.FromArgb(76, 245, 154);

        //447145
        Color mainColor1 = Color.FromArgb(68, 113, 69);

        //savingprofile
        private byte[] imagedata;


        //Supplier
        Controllers.MainFormSupplierController supplierController;
        public MainForm()
        {
 
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            InitialiazeTabControl(panelTabControl);
            InitialiazeTabControl(otherTabControl);

            databaseConnection = new DatabaseConnection();

            InitializeProfileTabControls();

            SetData();

            dataGridViewSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            panelTotalAsset.BackColor = mainColor1;

            //Controller
            supplierController = new Controllers.MainFormSupplierController(databaseConnection);
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
        }

        private void SetUser()
        {

            currentSessionUserType = sessionHandler.GetTypeUser();
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
                case "Asset Operator":
                            query = "SELECT assetOperatorFName, assetOperatorMName, assetOperatorLName, " +
                            "assetOperatorPhoneNum, assetOperatorEmail, " +
                            "assetOperatorAddress, assetOperatorOffice " +
                            "FROM AssetOperator WHERE userID = @UserId";
                    break;
                case "Asset Manager":
                            query = "SELECT assetManagerFName, assetManagerMName, assetManagerLName, " +
                            "assetManagerPhoneNumber, assetManagerEmail, " +
                            "assetManagerAddress, assetManagerOffice " +
                            "FROM AssetManager WHERE userID = @UserId";
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
            otherTabControl.SelectedTab = tabSupplier;
            labelTitleHandler.Text = "Supplier";

            //Load
            //supplierBindingSource1.Add()
            dataGridViewSupplier.DataSource = supplierController.GetAllSupplier();
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
            panelTabControl.SelectedTab = tabAbout;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panelTabControl.SelectedTab = tabAbout;
        }

        private void InitializeProfileTabControls()
        {
            checkBoxButtonProfileShowPassword.Appearance = System.Windows.Forms.Appearance.Button;

            

            profileTabControls.Add(buttonEditProfile);
            profileTabControls.Add(buttonProfileSave);
            profileTabControls.Add(buttonProfileCancel);
            
            profileTabControls.Add(textBoxProfileName);
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
                    case "Asset Operator":
                        query =
                            "UPDATE AssetOperator" +
                            " SET " +
                            "assetOperatorFName = @firstName, " +
                            "assetOperatorMName = @middleName, " +
                            "assetOperatorLName = @lastName, " +
                            "assetOperatorPhoneNum = @phoneNumber, " +
                            "assetOperatorEmail = @email, " +
                            "assetOperatorAddress = @address, " +
                            "assetOperatorOffice = @office " +
                            "WHERE userId = @UserId";
                        break;
                    case "Asset Manager":
                        query =
                             "UPDATE AssetManager" +
                             " SET " +
                             "assetManagerFName = @firstName, " +
                             "assetManagerMName = @middleName, " +
                             "assetManagerLName = @lastName, " +
                             "assetManagerPhoneNum = @phoneNumber, " +
                             "assetManagerEmail = @email, " +
                             "assetManagerAddress = @address, " +
                             "assetManagerOffice = @office " +
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
            sessionHandler.OnCurrentSessionEnd();
        }


        bool hamburgerToggle;
        private void buttonHamburger_Click(object sender, EventArgs e)
        {
            if (CheckSession())
            {
                if (hamburgerToggle != true)
                {
                    groupBoxSide.Size = new Size(140, 737);
                    buttonHamburger.BackColor = Color.Silver;

                    // Check the session before updating the UI
                    if (CheckSession())
                    {
                        buttonProfile.Visible = true;
                        buttonProfile.Text = $"{sessionHandler.GetUserName(databaseConnection)}\n{currentSessionUserType}";
                        hamburgerToggle = true;
                    }
                }
                else
                {
                    buttonProfile.Visible = false;
                    groupBoxSide.Size = new Size(80, 737);

                    hamburgerToggle = false;

                    buttonHamburger.BackColor = clickColor;

                    buttonProfile.BackColor = Color.Silver;
                }
            }

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panelBoxTop.BackColor = Color.FromArgb(45, 77, 46);
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

        private void buttonOperators_Click(object sender, EventArgs e)
        {
            labelTitleHandler.Text = "Operators";
            otherTabControl.SelectedTab = tabOperator;

            SupplierReset();
        }

        private void buttonAssetCategories_Click(object sender, EventArgs e)
        {
            labelTitleHandler.Text = "Asset Categories";
            otherTabControl.SelectedTab = tabAssetCategories;

            SupplierReset();
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
                currentSelectedSupplier = row.Cells[0].Value.ToString();

                textBoxSupplierName.Text = row.Cells[1].Value.ToString();
                textBoxSupplierPhoneNumber.Text = row.Cells[2].Value.ToString();
                textBoxSupplierAddress.Text = row.Cells[3].Value.ToString();

                Control[] buttoncontrols = { buttonSupplierViewSuppliedAssets, buttonSupplierUpdate, buttonSupplierDelete };
                Utilities.SetButtonsState(buttoncontrols, true);
            }

        }

        private void buttonSupplierViewSuppliedAssets_Click(object sender, EventArgs e)
        {

        }

        private void buttonSupplierClearFields_Click(object sender, EventArgs e)
        {
            SupplierReset();

        }

        private void buttonSupplierDelete_Click(object sender, EventArgs e)
        {
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

                dataGridViewSupplier.DataSource = supplierController.GetAllSupplier();

            }

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

                dataGridViewSupplier.DataSource = supplierController.GetAllSupplier();
            }

        }

        private void SupplierReset()
        {
            Control[] buttoncontrols = { buttonSupplierViewSuppliedAssets, buttonSupplierUpdate, buttonSupplierDelete };
            Utilities.SetButtonsState(buttoncontrols, false);

            Control[] fieldcontrols = { textBoxSupplierName, textBoxSupplierPhoneNumber, textBoxSupplierAddress };
            Utilities.ClearTextFieldsHandler(fieldcontrols);

            dataGridViewSupplier.ClearSelection();

            currentSelectedSupplier = "";
        }
    }
}
