
namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
    partial class UploadImageDialogBox
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUploadBrowse = new System.Windows.Forms.Button();
            this.buttonUploadFinish = new System.Windows.Forms.Button();
            this.labelDirectoryString = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.ErrorImage = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.EmptyProfile;
            this.pictureBoxImage.Image = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.EmptyProfile;
            this.pictureBoxImage.Location = new System.Drawing.Point(127, 80);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(291, 280);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
           
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upload Image";
            // 
            // buttonUploadBrowse
            // 
            this.buttonUploadBrowse.Location = new System.Drawing.Point(218, 13);
            this.buttonUploadBrowse.Name = "buttonUploadBrowse";
            this.buttonUploadBrowse.Size = new System.Drawing.Size(126, 38);
            this.buttonUploadBrowse.TabIndex = 2;
            this.buttonUploadBrowse.Text = "BROWSE";
            this.buttonUploadBrowse.UseVisualStyleBackColor = true;
            this.buttonUploadBrowse.Click += new System.EventHandler(this.buttonUploadBrowse_Click);
            // 
            // buttonUploadFinish
            // 
            this.buttonUploadFinish.Location = new System.Drawing.Point(12, 417);
            this.buttonUploadFinish.Name = "buttonUploadFinish";
            this.buttonUploadFinish.Size = new System.Drawing.Size(489, 43);
            this.buttonUploadFinish.TabIndex = 3;
            this.buttonUploadFinish.Text = "FINISH";
            this.buttonUploadFinish.UseVisualStyleBackColor = true;
            this.buttonUploadFinish.Click += new System.EventHandler(this.buttonUploadFinish_Click);
            // 
            // labelDirectoryString
            // 
            this.labelDirectoryString.AutoSize = true;
            this.labelDirectoryString.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirectoryString.Location = new System.Drawing.Point(12, 395);
            this.labelDirectoryString.Name = "labelDirectoryString";
            this.labelDirectoryString.Size = new System.Drawing.Size(116, 19);
            this.labelDirectoryString.TabIndex = 4;
            this.labelDirectoryString.Text = "DIRECTORY_STRING";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(430, 13);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(71, 38);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "X";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // UploadImageDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 470);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelDirectoryString);
            this.Controls.Add(this.buttonUploadFinish);
            this.Controls.Add(this.buttonUploadBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UploadImageDialogBox";
            this.Text = "Upload Image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUploadBrowse;
        private System.Windows.Forms.Button buttonUploadFinish;
        private System.Windows.Forms.Label labelDirectoryString;
        private System.Windows.Forms.Button buttonCancel;
    }
}