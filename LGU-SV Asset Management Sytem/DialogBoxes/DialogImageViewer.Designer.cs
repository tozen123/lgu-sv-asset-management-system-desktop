
namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
    partial class DialogImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogImageViewer));
            this.pictureBoxDocImage = new System.Windows.Forms.PictureBox();
            this.rbuttonClose = new LGU_SV_Asset_Management_Sytem.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDocImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDocImage
            // 
            this.pictureBoxDocImage.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxDocImage.Name = "pictureBoxDocImage";
            this.pictureBoxDocImage.Size = new System.Drawing.Size(665, 622);
            this.pictureBoxDocImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDocImage.TabIndex = 0;
            this.pictureBoxDocImage.TabStop = false;
            // 
            // rbuttonClose
            // 
            this.rbuttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.rbuttonClose.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.rbuttonClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbuttonClose.BorderRadius = 8;
            this.rbuttonClose.BorderSize = 0;
            this.rbuttonClose.FlatAppearance.BorderSize = 0;
            this.rbuttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbuttonClose.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbuttonClose.ForeColor = System.Drawing.Color.White;
            this.rbuttonClose.Location = new System.Drawing.Point(234, 641);
            this.rbuttonClose.Name = "rbuttonClose";
            this.rbuttonClose.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.rbuttonClose.Size = new System.Drawing.Size(209, 38);
            this.rbuttonClose.TabIndex = 14;
            this.rbuttonClose.Text = "CLOSE";
            this.rbuttonClose.TextColor = System.Drawing.Color.White;
            this.rbuttonClose.UseVisualStyleBackColor = false;
            this.rbuttonClose.Click += new System.EventHandler(this.rbuttonClose_Click);
            // 
            // DialogImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 691);
            this.Controls.Add(this.rbuttonClose);
            this.Controls.Add(this.pictureBoxDocImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogImageViewer";
            this.Text = "LGU-SV AMS: IMAGE VIEWER";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDocImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDocImage;
        private RoundedButton rbuttonClose;
    }
}