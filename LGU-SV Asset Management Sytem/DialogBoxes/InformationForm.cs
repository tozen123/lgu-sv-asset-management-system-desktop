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
    public partial class InformationForm : Form
    {
        public InformationForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            
        }

        private void SetUpHeaderPolicy()
        {
            richTextBoxHeader.ReadOnly = false;
            richTextBoxHeader.Clear();
            richTextBoxHeader.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxHeader.AppendText("" +
                "\nPrivacy Policy Use for LGU - SV" +
                "\nAsset Management System");
            richTextBoxHeader.ReadOnly = true;
        }
        private void SetUpHeaderTOS()
        {
            richTextBoxHeader.ReadOnly = false;
            richTextBoxHeader.Clear();
            richTextBoxHeader.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxHeader.AppendText("" +
                "\nTerms of Use for LGU - SV" +
                "\nAsset Management System");
            richTextBoxHeader.ReadOnly = true;
        }

        public void ShowPolicy()
        {
            SetUpHeaderPolicy();
            SetUpMessagePolicy();
            this.ShowDialog();
        }

        public void ShowTOS()
        {
            SetUpHeaderTOS();
            SetUpMessageTOS();
            this.ShowDialog();
        }

        public void SetUpMessageTOS()
        {
            Font regularFont = richTextBoxDetails.Font;


            Font boldFont = new Font(regularFont, FontStyle.Bold);

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nPlease read these terms of use carefully before accessing or using LGU - SV Asset Management System. By accessing or using the system, you agree to be bound by these terms of use. If you not agree with these terms, please do not use the system.\n");

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nI. Acceptance of Terms\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nBy accessing or using the AMS Asset Management System, you acknowledge that you have read, understood, and agree to comply with these Terms of Use. These Terms of Use constitute a legally binding agreement between you and AMS.\n");

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nII. User Eligibility\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nYou must be an authorized employee or contractor of AMS to use the System. By using the System, you represent and warrant that you have the authority and permission to use it on behalf of AMS.\n");

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nIII. User Accounts\n");
            
            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nYou are responsible for maintaining the confidentiality of your account credentials(username and password) You agree to notify us immediately of any unauthorized use of your account.AMS reserves the right to suspend or terminate your account at its discretion, especially in cases of misuse or violations of these Terms of Use.\n");
            
            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nIV. Access and Permissions\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nYour access to and use of the System are subject to the permissions and roles assigned to you by AMS.Unauthorized access to, modification of, or interference with the System is strictly prohibited.\n");

            
        }

        public void SetUpMessagePolicy()
        {
            Font regularFont = richTextBoxDetails.Font;


            Font boldFont = new Font(regularFont, FontStyle.Bold);

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nI. Introduction\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nWelcome to AMS' Asset Management System. We are committed to protecting your privacy and handling your data with care.\n");

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nII. Data Handling\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nWe pledge to handle your data with care and take appropriate measures to protect it. This includes safeguarding it from unauthorized access, ensuring its accuracy, and using it only for the purposes described in this policy.\n");

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nIII. Data Usage\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nWe pledge to handle your data with care and take appropriate measures to protect it. This includes safeguarding it from unauthorized access, ensuring its accuracy, and using it only for the purposes described in this policy.\n");

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nIV. Data Sharing\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nWe do not share your data with third parties unless required by law or as necessary to provide our services.\n");

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nV. Data Security\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nWe take reasonable steps to protect your data from unauthorized access, disclosure, alteration, or destruction. However, no method of data transmission or storage is completely secure, and we cannot guarantee absolute security.\n");

            richTextBoxDetails.SelectionFont = boldFont;
            richTextBoxDetails.AppendText("\nVI. Changes to this Privacy Policy\n");

            richTextBoxDetails.SelectionFont = regularFont;
            richTextBoxDetails.AppendText("\nWe may update this Privacy Policy to reflect changes in our practices or for other operational, legal, or regulatory reasons.Any updates will be posted on our website or communicated through other appropriate channels.\n");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
