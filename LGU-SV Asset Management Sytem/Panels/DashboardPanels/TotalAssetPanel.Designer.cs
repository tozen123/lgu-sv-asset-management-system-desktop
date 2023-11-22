
namespace LGU_SV_Asset_Management_Sytem.Panels.DashboardPanels
{
    partial class TotalAssetPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelCountAsset = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Asset ";
            // 
            // labelCountAsset
            // 
            this.labelCountAsset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCountAsset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.labelCountAsset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelCountAsset.Font = new System.Drawing.Font("Poppins", 54F, System.Drawing.FontStyle.Bold);
            this.labelCountAsset.ForeColor = System.Drawing.Color.White;
            this.labelCountAsset.Location = new System.Drawing.Point(377, 136);
            this.labelCountAsset.Name = "labelCountAsset";
            this.labelCountAsset.ReadOnly = true;
            this.labelCountAsset.Size = new System.Drawing.Size(180, 108);
            this.labelCountAsset.TabIndex = 21;
            this.labelCountAsset.TabStop = false;
            this.labelCountAsset.Text = "00";
            this.labelCountAsset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TotalAssetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.labelCountAsset);
            this.Controls.Add(this.label1);
            this.Name = "TotalAssetPanel";
            this.Size = new System.Drawing.Size(571, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox labelCountAsset;
    }
}
