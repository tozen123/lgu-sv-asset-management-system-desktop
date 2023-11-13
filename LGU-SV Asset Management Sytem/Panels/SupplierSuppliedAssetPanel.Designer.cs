
namespace LGU_SV_Asset_Management_Sytem.Panels
{
    partial class SupplierSuppliedAssetPanel
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
            this.buttonExitPanel = new System.Windows.Forms.Button();
            this.labelSupplierName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonExitPanel
            // 
            this.buttonExitPanel.Location = new System.Drawing.Point(1018, 13);
            this.buttonExitPanel.Name = "buttonExitPanel";
            this.buttonExitPanel.Size = new System.Drawing.Size(108, 34);
            this.buttonExitPanel.TabIndex = 4;
            this.buttonExitPanel.Text = "X";
            this.buttonExitPanel.UseVisualStyleBackColor = true;
            this.buttonExitPanel.Click += new System.EventHandler(this.buttonExitPanel_Click);
            // 
            // labelSupplierName
            // 
            this.labelSupplierName.AutoSize = true;
            this.labelSupplierName.Location = new System.Drawing.Point(44, 33);
            this.labelSupplierName.Name = "labelSupplierName";
            this.labelSupplierName.Size = new System.Drawing.Size(35, 13);
            this.labelSupplierName.TabIndex = 5;
            this.labelSupplierName.Text = "label1";
            // 
            // SupplierSuppliedAssetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSupplierName);
            this.Controls.Add(this.buttonExitPanel);
            this.Name = "SupplierSuppliedAssetPanel";
            this.Size = new System.Drawing.Size(1142, 589);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExitPanel;
        private System.Windows.Forms.Label labelSupplierName;
    }
}
