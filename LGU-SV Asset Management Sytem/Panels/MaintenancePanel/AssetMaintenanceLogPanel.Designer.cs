
namespace LGU_SV_Asset_Management_Sytem.Panels.MaintenancePanel
{
    partial class AssetMaintenanceLogPanel
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNewLog = new System.Windows.Forms.Button();
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.dataGridViewMaintenanceLogs = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panelLogMiniHandler = new System.Windows.Forms.Panel();
            this.labelAssetIdWithName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintenanceLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(14, 14);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(54, 43);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "<";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNewLog
            // 
            this.buttonNewLog.Location = new System.Drawing.Point(577, 31);
            this.buttonNewLog.Name = "buttonNewLog";
            this.buttonNewLog.Size = new System.Drawing.Size(123, 23);
            this.buttonNewLog.TabIndex = 5;
            this.buttonNewLog.Text = "New Log";
            this.buttonNewLog.UseVisualStyleBackColor = true;
            this.buttonNewLog.Click += new System.EventHandler(this.buttonNewLog_Click);
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Location = new System.Drawing.Point(706, 31);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(123, 23);
            this.buttonSchedule.TabIndex = 6;
            this.buttonSchedule.Text = "Schedule";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // dataGridViewMaintenanceLogs
            // 
            this.dataGridViewMaintenanceLogs.AllowUserToAddRows = false;
            this.dataGridViewMaintenanceLogs.AllowUserToDeleteRows = false;
            this.dataGridViewMaintenanceLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMaintenanceLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaintenanceLogs.Location = new System.Drawing.Point(5, 82);
            this.dataGridViewMaintenanceLogs.Name = "dataGridViewMaintenanceLogs";
            this.dataGridViewMaintenanceLogs.ReadOnly = true;
            this.dataGridViewMaintenanceLogs.Size = new System.Drawing.Size(1155, 611);
            this.dataGridViewMaintenanceLogs.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.pictureBox1.Location = new System.Drawing.Point(-14, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1200, 10);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(835, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1122, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "SRCH";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panelLogMiniHandler
            // 
            this.panelLogMiniHandler.Location = new System.Drawing.Point(577, 67);
            this.panelLogMiniHandler.Name = "panelLogMiniHandler";
            this.panelLogMiniHandler.Size = new System.Drawing.Size(485, 500);
            this.panelLogMiniHandler.TabIndex = 10;
            // 
            // labelAssetIdWithName
            // 
            this.labelAssetIdWithName.AutoSize = true;
            this.labelAssetIdWithName.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold);
            this.labelAssetIdWithName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.labelAssetIdWithName.Location = new System.Drawing.Point(74, 15);
            this.labelAssetIdWithName.Name = "labelAssetIdWithName";
            this.labelAssetIdWithName.Size = new System.Drawing.Size(226, 42);
            this.labelAssetIdWithName.TabIndex = 3;
            this.labelAssetIdWithName.Text = "ASSET_ID_NAME";
            // 
            // AssetMaintenanceLogPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridViewMaintenanceLogs);
            this.Controls.Add(this.buttonSchedule);
            this.Controls.Add(this.buttonNewLog);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelAssetIdWithName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelLogMiniHandler);
            this.Name = "AssetMaintenanceLogPanel";
            this.Size = new System.Drawing.Size(1167, 698);
            this.Load += new System.EventHandler(this.AssetMaintenanceLogPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaintenanceLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNewLog;
        private System.Windows.Forms.Button buttonSchedule;
        private System.Windows.Forms.DataGridView dataGridViewMaintenanceLogs;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelLogMiniHandler;
        private System.Windows.Forms.Label labelAssetIdWithName;
    }
}
