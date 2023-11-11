
namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
    partial class OptionDialogBox
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAddExistingAsset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNewAsset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Green;
            this.pictureBox1.Location = new System.Drawing.Point(-10, -11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(730, 54);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonAddExistingAsset
            // 
            this.buttonAddExistingAsset.Location = new System.Drawing.Point(170, 227);
            this.buttonAddExistingAsset.Name = "buttonAddExistingAsset";
            this.buttonAddExistingAsset.Size = new System.Drawing.Size(385, 56);
            this.buttonAddExistingAsset.TabIndex = 1;
            this.buttonAddExistingAsset.Text = "Add Existing Asset";
            this.buttonAddExistingAsset.UseVisualStyleBackColor = true;
            this.buttonAddExistingAsset.Click += new System.EventHandler(this.buttonAddExistingAsset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose type of asset";
            // 
            // buttonNewAsset
            // 
            this.buttonNewAsset.Location = new System.Drawing.Point(170, 150);
            this.buttonNewAsset.Name = "buttonNewAsset";
            this.buttonNewAsset.Size = new System.Drawing.Size(385, 56);
            this.buttonNewAsset.TabIndex = 4;
            this.buttonNewAsset.Text = "Add New Asset";
            this.buttonNewAsset.UseVisualStyleBackColor = true;
            this.buttonNewAsset.Click += new System.EventHandler(this.buttonNewAsset_Click);
            // 
            // OptionDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 329);
            this.Controls.Add(this.buttonNewAsset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddExistingAsset);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionDialogBox";
            this.Text = "OptionDIalogBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddExistingAsset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNewAsset;
    }
}