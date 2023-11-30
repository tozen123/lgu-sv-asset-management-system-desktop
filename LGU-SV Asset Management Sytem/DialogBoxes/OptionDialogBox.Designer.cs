
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbuttonAddExistingAsset = new LGU_SV_Asset_Management_Sytem.RoundedButton();
            this.rbuttonNewAsset = new LGU_SV_Asset_Management_Sytem.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new LGU_SV_Asset_Management_Sytem.RoundedButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Controls.Add(this.rbuttonAddExistingAsset);
            this.groupBox1.Controls.Add(this.rbuttonNewAsset);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 305);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // rbuttonAddExistingAsset
            // 
            this.rbuttonAddExistingAsset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.rbuttonAddExistingAsset.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.rbuttonAddExistingAsset.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbuttonAddExistingAsset.BorderRadius = 15;
            this.rbuttonAddExistingAsset.BorderSize = 0;
            this.rbuttonAddExistingAsset.FlatAppearance.BorderSize = 0;
            this.rbuttonAddExistingAsset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbuttonAddExistingAsset.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.rbuttonAddExistingAsset.ForeColor = System.Drawing.Color.White;
            this.rbuttonAddExistingAsset.Location = new System.Drawing.Point(147, 214);
            this.rbuttonAddExistingAsset.Name = "rbuttonAddExistingAsset";
            this.rbuttonAddExistingAsset.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.rbuttonAddExistingAsset.Size = new System.Drawing.Size(341, 67);
            this.rbuttonAddExistingAsset.TabIndex = 14;
            this.rbuttonAddExistingAsset.Text = "Add Existing Asset";
            this.rbuttonAddExistingAsset.TextColor = System.Drawing.Color.White;
            this.rbuttonAddExistingAsset.UseVisualStyleBackColor = false;
            this.rbuttonAddExistingAsset.Click += new System.EventHandler(this.buttonAddExistingAsset_Click);
            // 
            // rbuttonNewAsset
            // 
            this.rbuttonNewAsset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.rbuttonNewAsset.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.rbuttonNewAsset.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbuttonNewAsset.BorderRadius = 15;
            this.rbuttonNewAsset.BorderSize = 0;
            this.rbuttonNewAsset.FlatAppearance.BorderSize = 0;
            this.rbuttonNewAsset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbuttonNewAsset.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbuttonNewAsset.ForeColor = System.Drawing.Color.White;
            this.rbuttonNewAsset.Location = new System.Drawing.Point(147, 131);
            this.rbuttonNewAsset.Name = "rbuttonNewAsset";
            this.rbuttonNewAsset.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.rbuttonNewAsset.Size = new System.Drawing.Size(341, 67);
            this.rbuttonNewAsset.TabIndex = 13;
            this.rbuttonNewAsset.Text = "Add New Asset";
            this.rbuttonNewAsset.TextColor = System.Drawing.Color.White;
            this.rbuttonNewAsset.UseVisualStyleBackColor = false;
            this.rbuttonNewAsset.Click += new System.EventHandler(this.buttonNewAsset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 51);
            this.label1.TabIndex = 12;
            this.label1.Text = "CHOOSE TYPE OF ASSET";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.buttonClose.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.BorderColor = System.Drawing.Color.Transparent;
            this.buttonClose.BorderRadius = 8;
            this.buttonClose.BorderSize = 0;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Image = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.buttonClose;
            this.buttonClose.Location = new System.Drawing.Point(573, 28);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonClose.Size = new System.Drawing.Size(40, 39);
            this.buttonClose.TabIndex = 15;
            this.buttonClose.TextColor = System.Drawing.Color.White;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // OptionDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(653, 329);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionDialogBox";
            this.Text = "OptionDIalogBox";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private RoundedButton buttonClose;
        private RoundedButton rbuttonAddExistingAsset;
        private RoundedButton rbuttonNewAsset;
        private System.Windows.Forms.Label label1;
    }
}