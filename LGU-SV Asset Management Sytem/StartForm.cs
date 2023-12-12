using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace LGU_SV_Asset_Management_Sytem
{
    public partial class StartForm : Form
    {
        private DatabaseConnection databaseConnection;

        private List<Panel> startFormPanels = new List<Panel>();
        //Registration Variable
        private enum RegistrationType
        {
            None,
            Coordinator,
            Administrator,
            Viewer
        }

        private RegistrationType registrationType;

        public StartForm()
        {
            InitializeComponent();


            this.StartPosition = FormStartPosition.CenterScreen;
            databaseConnection = new DatabaseConnection();

            startFormPanels.Add(LoginPanel);
            startFormPanels.Add(RegistrationStartPanel);
            startFormPanels.Add(RegistrationStartPanel2);
            startFormPanels.Add(RegistrationAccountSetup1);
            startFormPanels.Add(RegistrationAccountSetup2);
           

            registrationType = RegistrationType.None;
            labelErrorHandler.Visible = false;

            ActivatePanel(LoginPanel);

            comboBoxAccSetupDepartment.Items.Add("GSO-General Services Office");
            comboBoxAccSetupDepartment.Items.Add("MHO-Municipal Health Office");
            comboBoxAccSetupDepartment.Items.Add("MCR-Municipal Civil Registrar");
            comboBoxAccSetupDepartment.Items.Add("MEO-Municipal Engineering Office");
            comboBoxAccSetupDepartment.Items.Add("MBO-Municipal Budget Office");
            comboBoxAccSetupDepartment.Items.Add("AO-Accounting Office");

           
        }

        private void ActivatePanel(Panel panelToActivate)
        {
            if (panelToActivate != LoginPanel)
            {
                buttonBackToLoginForm.Visible = true;
            }
            else if (panelToActivate == RegistrationAccountSetup2)
            {
                buttonBackToLoginForm.Visible = true;
            }
            else
            {
                buttonBackToLoginForm.Visible = false;
            }

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
        private void MessagePrompt(string message)
        {
            DialogBoxes.MessagePromptDialogBox prompt = new DialogBoxes.MessagePromptDialogBox();
            prompt.SetMessage(message);
            prompt.Show();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string inputEmail = textBoxEmail.Text;
            string inputPassword = textBoxPassword.Text;

            if(inputEmail.Equals("OR 1=1"))
            {
                MessagePrompt("An attempt for SQL Injection detected. Please don't. This system is protected by those attacks");
            }
            if (inputEmail.Equals("OR 1=1"))
            {
                MessagePrompt("An attempt for SQL Injection detected. Please don't. This system is protected by those attacks");
            }

            string query = "SELECT COUNT(*) FROM Users WHERE userID = @UserId AND userPassword = @Password " +
                "AND (EXISTS (SELECT 1 FROM AssetAdministrator WHERE userID = @UserId) " +
                "OR EXISTS (SELECT 1 FROM AssetCoordinator WHERE userID = @UserId) " +
                "OR EXISTS (SELECT 1 FROM AssetViewer WHERE userID = @UserId))";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@UserId", inputEmail);
            parameters.Add("@Password", inputPassword);


            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            if (resultTable.Rows.Count == 1 && Convert.ToInt32(resultTable.Rows[0][0]) == 1)
            {
                Label_ErrorHandler_Login.Visible = false;
                MainForm mainForm = new MainForm();
                mainForm.SetSessionHandler(inputEmail, inputPassword);
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();

                databaseConnection.CloseConnection();

                this.Hide();
            } 
            else
            {
                Label_ErrorHandler_Login.Visible = true;
                Label_ErrorHandler_Login.Text = "Wrong Password or ID";
                return;
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            ActivatePanel(RegistrationStartPanel);

        }

        private void buttonManagerRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Administrator;
            labelID.Text = RegistrationType.Administrator + " ID: ";

            comboBoxAccSetupDepartment.SelectedItem = comboBoxAccSetupDepartment.Items[0];
            comboBoxAccSetupDepartment.Enabled = false;

            ActivatePanel(RegistrationStartPanel2);
        }

        private void buttonOperatorRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Coordinator;
            labelID.Text = RegistrationType.Coordinator + " ID: ";

            ActivatePanel(RegistrationStartPanel2);
        }

        private void buttonViewerRole_Click(object sender, EventArgs e)
        {
            registrationType = RegistrationType.Viewer;
            labelID.Text = RegistrationType.Viewer + " ID: ";

            ActivatePanel(RegistrationStartPanel2);

        }

        private void buttonBackToLoginForm_Click(object sender, EventArgs e)
        {
            textBoxAccSetupAddress1.Text = "";
            textBoxAccSetupEmail.Text = "";
            textBoxAccSetupFirstName.Text = "";
            textBoxAccSetupLastName.Text = "";
            textBoxAccSetupMiddleName.Text = "";
            textBoxAccSetupPhoneNum.Text = "";
            textBoxEmail.Text = "";

            textBoxPassword.Text = "";

            textBoxRegistrationID.Text = "";
            textBoxRegistrationPassword.Text = "";
           

            registrationType = RegistrationType.None;
            ActivatePanel(LoginPanel);
        }

        private void buttonNextAccountSetup_Click(object sender, EventArgs e)
        {

            string id = textBoxRegistrationID.Text;
            string pass = textBoxRegistrationPassword.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pass))
            {
                labelErrorHandler.Visible = true;
                labelErrorHandler.Text = "Please enter both ID and Password.";
            }
            else
            {

                labelErrorHandler.Visible = false;

                string query = "SELECT COUNT(*) FROM Users WHERE userID = @UserId AND userPassword = @Password " +
                "AND (EXISTS (SELECT 1 FROM AssetAdministrator WHERE userID = @UserId) " +
                "OR EXISTS (SELECT 1 FROM AssetCoordinator WHERE userID = @UserId) " +
                "OR EXISTS (SELECT 1 FROM AssetViewer WHERE userID = @UserId))";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@UserId", id);
                parameters.Add("@Password", pass);


                DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

                if (resultTable.Rows.Count == 1 && Convert.ToInt32(resultTable.Rows[0][0]) == 1)
                {
                    labelErrorHandler.Visible = true;
                    labelErrorHandler.Text = "The ID is already existing";
                    return;
                }

                string query2 = "SELECT COUNT(*) FROM Users WHERE userID = @UserId AND userPassword = @Password";
                Dictionary<string, object> parameters1 = new Dictionary<string, object>();
                parameters1.Add("@UserId", id);
                parameters1.Add("@Password", pass);

                DataTable resultTable1 = databaseConnection.ReadFromDatabase(query2, parameters1);

                if (resultTable1.Rows.Count > 0 && Convert.ToInt32(resultTable1.Rows[0][0]) > 0)
                {
                    string[] code = id.Split('-');

                    if (code.Length == 0)
                    {
                        ShowErrorMessage("The inputted ID did not appear in the database");
                        return;
                    }

                    string codeTag = code[0];

                    bool isValidRegistrationType = false;

                    switch (registrationType)
                    {
                        case RegistrationType.Administrator:
                            isValidRegistrationType = codeTag == "03";
                            break;
                        case RegistrationType.Viewer:
                            isValidRegistrationType = codeTag == "01";
                            break;
                        case RegistrationType.Coordinator:
                            isValidRegistrationType = codeTag == "02";
                            break;
                    }

                    if (isValidRegistrationType)
                    {
                        ActivatePanel(RegistrationAccountSetup1);
                    }
                    else
                    {
                        ShowErrorMessage("Your ID does not correspond with the registration type. Please select the correct one.");
                    }
                }
                else
                {
                    ShowErrorMessage("Invalid ID or Password");
                }


            }
        }

        private void ShowErrorMessage(string message)
        {
            labelErrorHandler.Visible = true;
            labelErrorHandler.Text = message;
        }
        private bool ValidatePhoneNumber(string phoneNumber)
        {
           
            return phoneNumber.StartsWith("09") && phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit);
        }
        private void buttonAccountSetup_Click(object sender, EventArgs e)
        {
            string firstname = textBoxAccSetupFirstName.Text;

            if (string.IsNullOrEmpty(firstname))
            {
                labelAccountSetupErrorHandler.Text = "Please enter your first name";
                MessagePrompt("Please enter your first name");
                return;
            }

            string middlename = textBoxAccSetupMiddleName.Text;

            if (string.IsNullOrEmpty(middlename))
            {
                labelAccountSetupErrorHandler.Text = "Please enter your middle name";
                MessagePrompt("Please enter your middle name");
                return;
            }

            string lastname = textBoxAccSetupLastName.Text;

            if (string.IsNullOrEmpty(lastname))
            {
                labelAccountSetupErrorHandler.Text = "Please enter your last name";
                MessagePrompt("Please enter your last name");
                return;
            }

            string phonenum = textBoxAccSetupPhoneNum.Text;

            if (string.IsNullOrEmpty(phonenum))
            {
                labelAccountSetupErrorHandler.Text = "Please enter a valid phone number.";
                MessagePrompt("Please enter a valid phone number.");
                return;
            }
            if (!ValidatePhoneNumber(phonenum))
            {
                MessagePrompt("Invalid phone number. Please enter a valid 11-digit number starting with '09'.");
                return;
            }

            string department = comboBoxAccSetupDepartment.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(department))
            {
                labelAccountSetupErrorHandler.Text = "Please enter your department";
                MessagePrompt("Please enter your department");
                return;
            }

            string address = textBoxAccSetupAddress1.Text;

            if (string.IsNullOrEmpty(address))
            {
                MessagePrompt("Please enter your address");
                labelAccountSetupErrorHandler.Text = "Please enter your address";
                return;
            }

            string email = textBoxAccSetupEmail.Text;
            string emailPattern = @"^\S+@\S+\.\S+$";
            if (string.IsNullOrEmpty(email))
            {
                MessagePrompt("Please enter your email");
                labelAccountSetupErrorHandler.Text = "Please enter your email";
                return;
            }

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessagePrompt("Invalid email format");
                labelAccountSetupErrorHandler.Text = "Invalid email format";
                return;
            }
            
            labelErrorHandler.Visible = false;

            string id = textBoxRegistrationID.Text;

            string query = string.Empty;

            Dictionary<string, object> parameters = new Dictionary<string, object>

            {
                { "@userId", id },
                { "@firstName", firstname },
                { "@middleName", middlename },
                { "@lastName", lastname },
                { "@phoneNumber", phonenum },
                { "@email", email },
                { "@address", address },
                { "@office", department }
            };

            switch (registrationType)
            {
                case RegistrationType.Administrator:
                    query = "INSERT INTO AssetAdministrator (userId, FName, MName, LName, PhoneNumber, " +
                        "Email, Address, Office) " +
                            "VALUES (@userId, @firstName, @middleName, @lastName, @phoneNumber, @email, @address, @office)";
                    break;

                case RegistrationType.Coordinator:
                    query = "INSERT INTO AssetCoordinator (userId, FName, MName, LName, PhoneNumber, " +
                        "Email, Address, Office) " +
                            "VALUES (@userId, @firstName, @middleName, @lastName, @phoneNumber, @email, @address, @office)";
                    break;

                case RegistrationType.Viewer:
                    query = "INSERT INTO AssetViewer (userId, assetViewerFName, assetViewerMName, assetViewerLName, assetViewerPhoneNum, " +
                        "assetViewerEmail, assetViewerAddress, assetViewerOffice) " +
                            "VALUES (@userId, @firstName, @middleName, @lastName, @phoneNumber, @email, @address, @office)";
                    break;
            }

            if (!string.IsNullOrEmpty(query))
            {
                databaseConnection.UploadToDatabase(query, parameters);
            }

            //  Progress
            ActivatePanel(RegistrationAccountSetup2);

        }

        byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void buttonBrowseFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG Files (*.jpg; *.jpeg)|*.jpg;*.jpeg", Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxRegistration2.Image = Image.FromFile(ofd.FileName);
                    pictureBoxRegistration2.SizeMode = PictureBoxSizeMode.StretchImage;
                    labelDirectoryString.Text = ofd.FileName;
                }
            }
           
        }


        private void StartForm_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if(pictureBoxRegistration2.Image != null)
            {
                string query = "UPDATE Users SET userImage = @img WHERE userID = @userId";
                Dictionary<string, object> parameters = new Dictionary<string, object>

                    {
                        { "@userId", textBoxRegistrationID.Text },
                        { "@img", ConvertImageToBytes(pictureBoxRegistration2.Image) }

                    };
                databaseConnection.UploadToDatabase(query, parameters);
                databaseConnection.CloseConnection();

                ActivatePanel(LoginPanel);
            } 
            else
            {
                ActivatePanel(LoginPanel);
            }
           

            
        }


        
        private void buttonMasterExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // If the form is closed by the user, exit the application
                Application.Exit();
            }
        }

        private void buttonSlogin_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.SetSessionHandler("03-1", "2730");
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();

            databaseConnection.CloseConnection();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.SetSessionHandler("02-2", "557");
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();

            databaseConnection.CloseConnection();

            this.Hide();
        }

        private void linkLabel1Policy_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogBoxes.InformationForm informationForm = new DialogBoxes.InformationForm();

            informationForm.ShowPolicy();
        }

        private void linkLabelTOR_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogBoxes.InformationForm informationForm = new DialogBoxes.InformationForm();

            informationForm.ShowTOS();
        }

        private void comboBoxAccSetupDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LoginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelErrorHandler_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrationAccountSetup1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegistrationAccountSetup2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonConfigureDatabase_Click(object sender, EventArgs e)
        {

        }

        private void labelDirectory_Click(object sender, EventArgs e)
        {

        }
    }
}
