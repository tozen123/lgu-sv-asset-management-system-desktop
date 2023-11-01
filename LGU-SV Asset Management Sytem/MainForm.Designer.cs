
namespace LGU_SV_Asset_Management_Sytem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTabControl = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.textBoxProfileAddress = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxProfilePosition = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxProfileOffice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxProfilePassword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxProfileEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxProfilePhoneNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAssetRecords = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabArchiveRecords = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tabGenReport = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabOthers = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUserType = new System.Windows.Forms.Label();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonOthers = new System.Windows.Forms.Button();
            this.buttonGenerateReports = new System.Windows.Forms.Button();
            this.buttonArchiveRecords = new System.Windows.Forms.Button();
            this.buttonAssetRecords = new System.Windows.Forms.Button();
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonProfileSave = new System.Windows.Forms.Button();
            this.buttonProfileCancel = new System.Windows.Forms.Button();
            this.panelTabControl.SuspendLayout();
            this.tabProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabDashboard.SuspendLayout();
            this.tabAssetRecords.SuspendLayout();
            this.tabArchiveRecords.SuspendLayout();
            this.tabGenReport.SuspendLayout();
            this.tabOthers.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabControl
            // 
            this.panelTabControl.Controls.Add(this.tabProfile);
            this.panelTabControl.Controls.Add(this.tabDashboard);
            this.panelTabControl.Controls.Add(this.tabAssetRecords);
            this.panelTabControl.Controls.Add(this.tabArchiveRecords);
            this.panelTabControl.Controls.Add(this.tabGenReport);
            this.panelTabControl.Controls.Add(this.tabOthers);
            this.panelTabControl.Controls.Add(this.tabAbout);
            this.panelTabControl.Controls.Add(this.tabSettings);
            this.panelTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.panelTabControl.Location = new System.Drawing.Point(159, 12);
            this.panelTabControl.Multiline = true;
            this.panelTabControl.Name = "panelTabControl";
            this.panelTabControl.SelectedIndex = 0;
            this.panelTabControl.Size = new System.Drawing.Size(1013, 737);
            this.panelTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.panelTabControl.TabIndex = 0;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.buttonProfileCancel);
            this.tabProfile.Controls.Add(this.buttonProfileSave);
            this.tabProfile.Controls.Add(this.textBoxProfileAddress);
            this.tabProfile.Controls.Add(this.label15);
            this.tabProfile.Controls.Add(this.textBoxProfilePosition);
            this.tabProfile.Controls.Add(this.label14);
            this.tabProfile.Controls.Add(this.textBoxProfileOffice);
            this.tabProfile.Controls.Add(this.label13);
            this.tabProfile.Controls.Add(this.textBoxProfilePassword);
            this.tabProfile.Controls.Add(this.label12);
            this.tabProfile.Controls.Add(this.textBoxProfileEmail);
            this.tabProfile.Controls.Add(this.label11);
            this.tabProfile.Controls.Add(this.textBoxProfilePhoneNumber);
            this.tabProfile.Controls.Add(this.label10);
            this.tabProfile.Controls.Add(this.textBoxProfileName);
            this.tabProfile.Controls.Add(this.label9);
            this.tabProfile.Controls.Add(this.buttonEditProfile);
            this.tabProfile.Controls.Add(this.pictureBox1);
            this.tabProfile.Controls.Add(this.label3);
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(1005, 711);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "tabPage1";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // textBoxProfileAddress
            // 
            this.textBoxProfileAddress.BackColor = System.Drawing.Color.Silver;
            this.textBoxProfileAddress.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfileAddress.Location = new System.Drawing.Point(558, 399);
            this.textBoxProfileAddress.Name = "textBoxProfileAddress";
            this.textBoxProfileAddress.Size = new System.Drawing.Size(378, 31);
            this.textBoxProfileAddress.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(371, 402);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 28);
            this.label15.TabIndex = 16;
            this.label15.Text = "Address:";
            // 
            // textBoxProfilePosition
            // 
            this.textBoxProfilePosition.BackColor = System.Drawing.Color.Silver;
            this.textBoxProfilePosition.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfilePosition.Location = new System.Drawing.Point(558, 342);
            this.textBoxProfilePosition.Name = "textBoxProfilePosition";
            this.textBoxProfilePosition.Size = new System.Drawing.Size(378, 31);
            this.textBoxProfilePosition.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(371, 345);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 28);
            this.label14.TabIndex = 14;
            this.label14.Text = "Position:";
            // 
            // textBoxProfileOffice
            // 
            this.textBoxProfileOffice.BackColor = System.Drawing.Color.Silver;
            this.textBoxProfileOffice.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfileOffice.Location = new System.Drawing.Point(558, 291);
            this.textBoxProfileOffice.Name = "textBoxProfileOffice";
            this.textBoxProfileOffice.Size = new System.Drawing.Size(378, 31);
            this.textBoxProfileOffice.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(371, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 28);
            this.label13.TabIndex = 12;
            this.label13.Text = "Office/Department:";
            // 
            // textBoxProfilePassword
            // 
            this.textBoxProfilePassword.BackColor = System.Drawing.Color.Silver;
            this.textBoxProfilePassword.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfilePassword.Location = new System.Drawing.Point(558, 240);
            this.textBoxProfilePassword.Name = "textBoxProfilePassword";
            this.textBoxProfilePassword.Size = new System.Drawing.Size(378, 31);
            this.textBoxProfilePassword.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(371, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 28);
            this.label12.TabIndex = 10;
            this.label12.Text = "Password:";
            // 
            // textBoxProfileEmail
            // 
            this.textBoxProfileEmail.BackColor = System.Drawing.Color.Silver;
            this.textBoxProfileEmail.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfileEmail.Location = new System.Drawing.Point(558, 190);
            this.textBoxProfileEmail.Name = "textBoxProfileEmail";
            this.textBoxProfileEmail.Size = new System.Drawing.Size(378, 31);
            this.textBoxProfileEmail.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(371, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 28);
            this.label11.TabIndex = 8;
            this.label11.Text = "E-mail:";
            // 
            // textBoxProfilePhoneNumber
            // 
            this.textBoxProfilePhoneNumber.BackColor = System.Drawing.Color.Silver;
            this.textBoxProfilePhoneNumber.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfilePhoneNumber.Location = new System.Drawing.Point(558, 135);
            this.textBoxProfilePhoneNumber.Name = "textBoxProfilePhoneNumber";
            this.textBoxProfilePhoneNumber.Size = new System.Drawing.Size(378, 31);
            this.textBoxProfilePhoneNumber.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(371, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 28);
            this.label10.TabIndex = 6;
            this.label10.Text = "Phone Number:";
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.BackColor = System.Drawing.Color.Silver;
            this.textBoxProfileName.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfileName.Location = new System.Drawing.Point(558, 85);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.Size = new System.Drawing.Size(378, 31);
            this.textBoxProfileName.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(371, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 28);
            this.label9.TabIndex = 4;
            this.label9.Text = "Name:";
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Location = new System.Drawing.Point(16, 426);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(314, 47);
            this.buttonEditProfile.TabIndex = 3;
            this.buttonEditProfile.Text = "EDIT";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.EmptyProfile;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(314, 327);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 56);
            this.label3.TabIndex = 1;
            this.label3.Text = "Account Profile";
            // 
            // tabDashboard
            // 
            this.tabDashboard.Controls.Add(this.label1);
            this.tabDashboard.Location = new System.Drawing.Point(4, 22);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(1005, 711);
            this.tabDashboard.TabIndex = 1;
            this.tabDashboard.Text = "tabPage2";
            this.tabDashboard.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dashboard";
            // 
            // tabAssetRecords
            // 
            this.tabAssetRecords.Controls.Add(this.label2);
            this.tabAssetRecords.Location = new System.Drawing.Point(4, 22);
            this.tabAssetRecords.Name = "tabAssetRecords";
            this.tabAssetRecords.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssetRecords.Size = new System.Drawing.Size(1005, 711);
            this.tabAssetRecords.TabIndex = 2;
            this.tabAssetRecords.Text = "tabPage3";
            this.tabAssetRecords.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asset Records";
            // 
            // tabArchiveRecords
            // 
            this.tabArchiveRecords.Controls.Add(this.label4);
            this.tabArchiveRecords.Location = new System.Drawing.Point(4, 22);
            this.tabArchiveRecords.Name = "tabArchiveRecords";
            this.tabArchiveRecords.Padding = new System.Windows.Forms.Padding(3);
            this.tabArchiveRecords.Size = new System.Drawing.Size(1005, 711);
            this.tabArchiveRecords.TabIndex = 3;
            this.tabArchiveRecords.Text = "tabPage4";
            this.tabArchiveRecords.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Archive Records";
            // 
            // tabGenReport
            // 
            this.tabGenReport.Controls.Add(this.label5);
            this.tabGenReport.Location = new System.Drawing.Point(4, 22);
            this.tabGenReport.Name = "tabGenReport";
            this.tabGenReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenReport.Size = new System.Drawing.Size(1005, 711);
            this.tabGenReport.TabIndex = 4;
            this.tabGenReport.Text = "tabPage5";
            this.tabGenReport.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Generate Report";
            // 
            // tabOthers
            // 
            this.tabOthers.Controls.Add(this.label6);
            this.tabOthers.Location = new System.Drawing.Point(4, 22);
            this.tabOthers.Name = "tabOthers";
            this.tabOthers.Padding = new System.Windows.Forms.Padding(3);
            this.tabOthers.Size = new System.Drawing.Size(1005, 711);
            this.tabOthers.TabIndex = 5;
            this.tabOthers.Text = "tabPage6";
            this.tabOthers.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Others";
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.label7);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(1005, 711);
            this.tabAbout.TabIndex = 6;
            this.tabAbout.Text = "tabPage7";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(491, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "About";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.label8);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1005, 711);
            this.tabSettings.TabIndex = 7;
            this.tabSettings.Text = "tabPage8";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(491, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.labelUserName);
            this.groupBox1.Controls.Add(this.labelUserType);
            this.groupBox1.Controls.Add(this.buttonAbout);
            this.groupBox1.Controls.Add(this.buttonSettings);
            this.groupBox1.Controls.Add(this.buttonLogout);
            this.groupBox1.Controls.Add(this.buttonOthers);
            this.groupBox1.Controls.Add(this.buttonGenerateReports);
            this.groupBox1.Controls.Add(this.buttonArchiveRecords);
            this.groupBox1.Controls.Add(this.buttonAssetRecords);
            this.groupBox1.Controls.Add(this.buttonDashboard);
            this.groupBox1.Controls.Add(this.buttonProfile);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 737);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(43, 55);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(76, 16);
            this.labelUserName.TabIndex = 20;
            this.labelUserName.Text = "USER_NAME";
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserType.Location = new System.Drawing.Point(44, 71);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(58, 12);
            this.labelUserType.TabIndex = 19;
            this.labelUserType.Text = "USER_TYPE";
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(6, 628);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(126, 28);
            this.buttonAbout.TabIndex = 18;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(6, 662);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(126, 28);
            this.buttonSettings.TabIndex = 17;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(6, 696);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(126, 28);
            this.buttonLogout.TabIndex = 16;
            this.buttonLogout.Text = "Log Out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // buttonOthers
            // 
            this.buttonOthers.Location = new System.Drawing.Point(6, 397);
            this.buttonOthers.Name = "buttonOthers";
            this.buttonOthers.Size = new System.Drawing.Size(126, 45);
            this.buttonOthers.TabIndex = 15;
            this.buttonOthers.Text = "Others";
            this.buttonOthers.UseVisualStyleBackColor = true;
            this.buttonOthers.Click += new System.EventHandler(this.buttonOthers_Click);
            // 
            // buttonGenerateReports
            // 
            this.buttonGenerateReports.Location = new System.Drawing.Point(6, 337);
            this.buttonGenerateReports.Name = "buttonGenerateReports";
            this.buttonGenerateReports.Size = new System.Drawing.Size(126, 45);
            this.buttonGenerateReports.TabIndex = 14;
            this.buttonGenerateReports.Text = "Generate Reports";
            this.buttonGenerateReports.UseVisualStyleBackColor = true;
            this.buttonGenerateReports.Click += new System.EventHandler(this.buttonGenerateReports_Click);
            // 
            // buttonArchiveRecords
            // 
            this.buttonArchiveRecords.Location = new System.Drawing.Point(6, 274);
            this.buttonArchiveRecords.Name = "buttonArchiveRecords";
            this.buttonArchiveRecords.Size = new System.Drawing.Size(126, 45);
            this.buttonArchiveRecords.TabIndex = 13;
            this.buttonArchiveRecords.Text = "Archive Records";
            this.buttonArchiveRecords.UseVisualStyleBackColor = true;
            this.buttonArchiveRecords.Click += new System.EventHandler(this.buttonArchiveRecords_Click);
            // 
            // buttonAssetRecords
            // 
            this.buttonAssetRecords.Location = new System.Drawing.Point(6, 212);
            this.buttonAssetRecords.Name = "buttonAssetRecords";
            this.buttonAssetRecords.Size = new System.Drawing.Size(126, 45);
            this.buttonAssetRecords.TabIndex = 12;
            this.buttonAssetRecords.Text = "Asset Records";
            this.buttonAssetRecords.UseVisualStyleBackColor = true;
            this.buttonAssetRecords.Click += new System.EventHandler(this.buttonAssetRecords_Click);
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.Location = new System.Drawing.Point(6, 151);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(126, 45);
            this.buttonDashboard.TabIndex = 11;
            this.buttonDashboard.Text = "Dashboard";
            this.buttonDashboard.UseVisualStyleBackColor = true;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // buttonProfile
            // 
            this.buttonProfile.Location = new System.Drawing.Point(11, 22);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(27, 62);
            this.buttonProfile.TabIndex = 10;
            this.buttonProfile.Text = "-";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonProfileSave
            // 
            this.buttonProfileSave.Location = new System.Drawing.Point(16, 479);
            this.buttonProfileSave.Name = "buttonProfileSave";
            this.buttonProfileSave.Size = new System.Drawing.Size(155, 47);
            this.buttonProfileSave.TabIndex = 18;
            this.buttonProfileSave.Text = "SAVE";
            this.buttonProfileSave.UseVisualStyleBackColor = true;
            // 
            // buttonProfileCancel
            // 
            this.buttonProfileCancel.Location = new System.Drawing.Point(175, 479);
            this.buttonProfileCancel.Name = "buttonProfileCancel";
            this.buttonProfileCancel.Size = new System.Drawing.Size(155, 47);
            this.buttonProfileCancel.TabIndex = 19;
            this.buttonProfileCancel.Text = "CANCEL";
            this.buttonProfileCancel.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "LGU-SAN VICENTE Asset Management System";
            this.panelTabControl.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabDashboard.ResumeLayout(false);
            this.tabDashboard.PerformLayout();
            this.tabAssetRecords.ResumeLayout(false);
            this.tabAssetRecords.PerformLayout();
            this.tabArchiveRecords.ResumeLayout(false);
            this.tabArchiveRecords.PerformLayout();
            this.tabGenReport.ResumeLayout(false);
            this.tabGenReport.PerformLayout();
            this.tabOthers.ResumeLayout(false);
            this.tabOthers.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl panelTabControl;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabAssetRecords;
        private System.Windows.Forms.TabPage tabArchiveRecords;
        private System.Windows.Forms.TabPage tabGenReport;
        private System.Windows.Forms.TabPage tabOthers;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonOthers;
        private System.Windows.Forms.Button buttonGenerateReports;
        private System.Windows.Forms.Button buttonArchiveRecords;
        private System.Windows.Forms.Button buttonAssetRecords;
        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.TextBox textBoxProfileAddress;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxProfilePosition;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxProfileOffice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxProfilePassword;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxProfileEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxProfilePhoneNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonProfileCancel;
        private System.Windows.Forms.Button buttonProfileSave;
    }
}