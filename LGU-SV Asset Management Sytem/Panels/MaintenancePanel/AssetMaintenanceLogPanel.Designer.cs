
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNewLog = new System.Windows.Forms.Button();
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.dataGridViewMaintenanceLogs = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxMLogSearch = new System.Windows.Forms.TextBox();
            this.buttonMLogPerfSearch = new System.Windows.Forms.Button();
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
            this.buttonNewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonNewLog.FlatAppearance.BorderSize = 0;
            this.buttonNewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewLog.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonNewLog.ForeColor = System.Drawing.Color.White;
            this.buttonNewLog.Location = new System.Drawing.Point(632, 23);
            this.buttonNewLog.Name = "buttonNewLog";
            this.buttonNewLog.Size = new System.Drawing.Size(123, 30);
            this.buttonNewLog.TabIndex = 5;
            this.buttonNewLog.Text = "New Log";
            this.buttonNewLog.UseVisualStyleBackColor = false;
            this.buttonNewLog.Click += new System.EventHandler(this.buttonNewLog_Click);
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonSchedule.FlatAppearance.BorderSize = 0;
            this.buttonSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSchedule.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonSchedule.ForeColor = System.Drawing.Color.White;
            this.buttonSchedule.Location = new System.Drawing.Point(493, 24);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(123, 30);
            this.buttonSchedule.TabIndex = 6;
            this.buttonSchedule.Text = "Schedule";
            this.buttonSchedule.UseVisualStyleBackColor = false;
            this.buttonSchedule.Visible = false;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // dataGridViewMaintenanceLogs
            // 
            this.dataGridViewMaintenanceLogs.AllowUserToAddRows = false;
            this.dataGridViewMaintenanceLogs.AllowUserToDeleteRows = false;
            this.dataGridViewMaintenanceLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMaintenanceLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMaintenanceLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewMaintenanceLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMaintenanceLogs.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewMaintenanceLogs.Location = new System.Drawing.Point(5, 82);
            this.dataGridViewMaintenanceLogs.Name = "dataGridViewMaintenanceLogs";
            this.dataGridViewMaintenanceLogs.ReadOnly = true;
            this.dataGridViewMaintenanceLogs.Size = new System.Drawing.Size(1155, 611);
            this.dataGridViewMaintenanceLogs.TabIndex = 7;
            this.dataGridViewMaintenanceLogs.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMaintenanceLogs_CellMouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.pictureBox1.Location = new System.Drawing.Point(-14, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1200, 10);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxMLogSearch
            // 
            this.textBoxMLogSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMLogSearch.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMLogSearch.Location = new System.Drawing.Point(761, 23);
            this.textBoxMLogSearch.Name = "textBoxMLogSearch";
            this.textBoxMLogSearch.Size = new System.Drawing.Size(355, 30);
            this.textBoxMLogSearch.TabIndex = 8;
            this.textBoxMLogSearch.TextChanged += new System.EventHandler(this.textBoxMLogSearch_TextChanged);
            // 
            // buttonMLogPerfSearch
            // 
            this.buttonMLogPerfSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMLogPerfSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonMLogPerfSearch.FlatAppearance.BorderSize = 0;
            this.buttonMLogPerfSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMLogPerfSearch.Image = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.buttonSearch;
            this.buttonMLogPerfSearch.Location = new System.Drawing.Point(1122, 23);
            this.buttonMLogPerfSearch.Name = "buttonMLogPerfSearch";
            this.buttonMLogPerfSearch.Size = new System.Drawing.Size(38, 31);
            this.buttonMLogPerfSearch.TabIndex = 9;
            this.buttonMLogPerfSearch.UseVisualStyleBackColor = false;
            this.buttonMLogPerfSearch.Click += new System.EventHandler(this.buttonMLogPerfSearch_Click);
            // 
            // panelLogMiniHandler
            // 
            this.panelLogMiniHandler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLogMiniHandler.Location = new System.Drawing.Point(493, 63);
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
            this.Controls.Add(this.buttonMLogPerfSearch);
            this.Controls.Add(this.textBoxMLogSearch);
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
        private System.Windows.Forms.TextBox textBoxMLogSearch;
        private System.Windows.Forms.Button buttonMLogPerfSearch;
        private System.Windows.Forms.Panel panelLogMiniHandler;
        private System.Windows.Forms.Label labelAssetIdWithName;
    }
}
