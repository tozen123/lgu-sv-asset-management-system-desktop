
namespace LGU_SV_Asset_Management_Sytem
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.RegistrationStartPanel = new System.Windows.Forms.Panel();
            this.RegistrationStartPanel2 = new System.Windows.Forms.Panel();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxRegistrationPassword = new System.Windows.Forms.TextBox();
            this.textBoxRegistrationID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonManagerRole = new System.Windows.Forms.Button();
            this.buttonViewerRole = new System.Windows.Forms.Button();
            this.buttonOperatorRole = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.RegistrationStartPanel.SuspendLayout();
            this.RegistrationStartPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "LGU - San Vicente Asset Management System";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(72, 30);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(332, 20);
            this.textBoxEmail.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(72, 72);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(332, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(16, 120);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(16, 173);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(75, 23);
            this.buttonSignUp.TabIndex = 7;
            this.buttonSignUp.Text = "Sign Up";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.RegistrationStartPanel);
            this.LoginPanel.Controls.Add(this.textBoxEmail);
            this.LoginPanel.Controls.Add(this.buttonSignUp);
            this.LoginPanel.Controls.Add(this.textBoxPassword);
            this.LoginPanel.Controls.Add(this.label3);
            this.LoginPanel.Controls.Add(this.buttonLogin);
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Location = new System.Drawing.Point(15, 42);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(1080, 600);
            this.LoginPanel.TabIndex = 8;
            // 
            // RegistrationStartPanel
            // 
            this.RegistrationStartPanel.Controls.Add(this.RegistrationStartPanel2);
            this.RegistrationStartPanel.Controls.Add(this.buttonManagerRole);
            this.RegistrationStartPanel.Controls.Add(this.buttonViewerRole);
            this.RegistrationStartPanel.Controls.Add(this.buttonOperatorRole);
            this.RegistrationStartPanel.Location = new System.Drawing.Point(0, 0);
            this.RegistrationStartPanel.Name = "RegistrationStartPanel";
            this.RegistrationStartPanel.Size = new System.Drawing.Size(1080, 600);
            this.RegistrationStartPanel.TabIndex = 9;
            // 
            // RegistrationStartPanel2
            // 
            this.RegistrationStartPanel2.Controls.Add(this.labelPassword);
            this.RegistrationStartPanel2.Controls.Add(this.labelID);
            this.RegistrationStartPanel2.Controls.Add(this.textBoxRegistrationPassword);
            this.RegistrationStartPanel2.Controls.Add(this.textBoxRegistrationID);
            this.RegistrationStartPanel2.Controls.Add(this.label4);
            this.RegistrationStartPanel2.Location = new System.Drawing.Point(0, 0);
            this.RegistrationStartPanel2.Name = "RegistrationStartPanel2";
            this.RegistrationStartPanel2.Size = new System.Drawing.Size(1080, 600);
            this.RegistrationStartPanel2.TabIndex = 9;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(76, 152);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(76, 123);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 3;
            this.labelID.Text = "ID";
            // 
            // textBoxRegistrationPassword
            // 
            this.textBoxRegistrationPassword.Location = new System.Drawing.Point(135, 149);
            this.textBoxRegistrationPassword.Name = "textBoxRegistrationPassword";
            this.textBoxRegistrationPassword.Size = new System.Drawing.Size(364, 20);
            this.textBoxRegistrationPassword.TabIndex = 2;
            // 
            // textBoxRegistrationID
            // 
            this.textBoxRegistrationID.Location = new System.Drawing.Point(135, 120);
            this.textBoxRegistrationID.Name = "textBoxRegistrationID";
            this.textBoxRegistrationID.Size = new System.Drawing.Size(364, 20);
            this.textBoxRegistrationID.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Welcome Onboard!";
            // 
            // buttonManagerRole
            // 
            this.buttonManagerRole.Location = new System.Drawing.Point(16, 70);
            this.buttonManagerRole.Name = "buttonManagerRole";
            this.buttonManagerRole.Size = new System.Drawing.Size(75, 23);
            this.buttonManagerRole.TabIndex = 8;
            this.buttonManagerRole.Text = "Manager";
            this.buttonManagerRole.UseVisualStyleBackColor = true;
            this.buttonManagerRole.Click += new System.EventHandler(this.buttonManagerRole_Click);
            // 
            // buttonViewerRole
            // 
            this.buttonViewerRole.Location = new System.Drawing.Point(16, 173);
            this.buttonViewerRole.Name = "buttonViewerRole";
            this.buttonViewerRole.Size = new System.Drawing.Size(75, 23);
            this.buttonViewerRole.TabIndex = 7;
            this.buttonViewerRole.Text = "Viewer";
            this.buttonViewerRole.UseVisualStyleBackColor = true;
            this.buttonViewerRole.Click += new System.EventHandler(this.buttonViewerRole_Click);
            // 
            // buttonOperatorRole
            // 
            this.buttonOperatorRole.Location = new System.Drawing.Point(16, 120);
            this.buttonOperatorRole.Name = "buttonOperatorRole";
            this.buttonOperatorRole.Size = new System.Drawing.Size(75, 23);
            this.buttonOperatorRole.TabIndex = 4;
            this.buttonOperatorRole.Text = "Operator";
            this.buttonOperatorRole.UseVisualStyleBackColor = true;
            this.buttonOperatorRole.Click += new System.EventHandler(this.buttonOperatorRole_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 654);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.Text = "LGU-SAN VICENTE Asset Management System";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.RegistrationStartPanel.ResumeLayout(false);
            this.RegistrationStartPanel2.ResumeLayout(false);
            this.RegistrationStartPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Panel RegistrationStartPanel;
        private System.Windows.Forms.Button buttonViewerRole;
        private System.Windows.Forms.Button buttonOperatorRole;
        private System.Windows.Forms.Button buttonManagerRole;
        private System.Windows.Forms.Panel RegistrationStartPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxRegistrationPassword;
        private System.Windows.Forms.TextBox textBoxRegistrationID;
        private System.Windows.Forms.Label labelPassword;
    }
}