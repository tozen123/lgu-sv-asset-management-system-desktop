
namespace LGU_SV_Asset_Management_Sytem.Panels
{
    partial class OperatorHandledAssetPanel
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
            this.labelOperatorName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonExitPanel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset List:";
            // 
            // labelOperatorName
            // 
            this.labelOperatorName.AutoSize = true;
            this.labelOperatorName.Font = new System.Drawing.Font("Poppins Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperatorName.Location = new System.Drawing.Point(158, 26);
            this.labelOperatorName.Name = "labelOperatorName";
            this.labelOperatorName.Size = new System.Drawing.Size(161, 37);
            this.labelOperatorName.TabIndex = 1;
            this.labelOperatorName.Text = "LABEL_NAME";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1108, 507);
            this.dataGridView1.TabIndex = 2;
            // 
            // buttonExitPanel
            // 
            this.buttonExitPanel.Location = new System.Drawing.Point(1015, 29);
            this.buttonExitPanel.Name = "buttonExitPanel";
            this.buttonExitPanel.Size = new System.Drawing.Size(108, 34);
            this.buttonExitPanel.TabIndex = 3;
            this.buttonExitPanel.Text = "X";
            this.buttonExitPanel.UseVisualStyleBackColor = true;
            this.buttonExitPanel.Click += new System.EventHandler(this.buttonExitPanel_Click);
            // 
            // OperatorHandledAssetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonExitPanel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelOperatorName);
            this.Controls.Add(this.label1);
            this.Name = "OperatorHandledAssetPanel";
            this.Size = new System.Drawing.Size(1139, 586);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelOperatorName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonExitPanel;
    }
}
