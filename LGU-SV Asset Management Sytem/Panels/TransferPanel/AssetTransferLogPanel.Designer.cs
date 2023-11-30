
namespace LGU_SV_Asset_Management_Sytem.Panels.TransferPanel
{
    partial class AssetTransferLogPanel
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
            this.labelAssetIdWithName = new System.Windows.Forms.Label();
            this.dataGridViewTransferLogs = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransferLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Image = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.buttonBack;
            this.buttonBack.Location = new System.Drawing.Point(9, 8);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(54, 43);
            this.buttonBack.TabIndex = 10;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelAssetIdWithName
            // 
            this.labelAssetIdWithName.AutoSize = true;
            this.labelAssetIdWithName.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssetIdWithName.Location = new System.Drawing.Point(69, 17);
            this.labelAssetIdWithName.Name = "labelAssetIdWithName";
            this.labelAssetIdWithName.Size = new System.Drawing.Size(179, 34);
            this.labelAssetIdWithName.TabIndex = 9;
            this.labelAssetIdWithName.Text = "ASSET_ID_NAME";
            // 
            // dataGridViewTransferLogs
            // 
            this.dataGridViewTransferLogs.AllowUserToAddRows = false;
            this.dataGridViewTransferLogs.AllowUserToDeleteRows = false;
            this.dataGridViewTransferLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTransferLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransferLogs.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTransferLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTransferLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransferLogs.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTransferLogs.Location = new System.Drawing.Point(18, 70);
            this.dataGridViewTransferLogs.Name = "dataGridViewTransferLogs";
            this.dataGridViewTransferLogs.ReadOnly = true;
            this.dataGridViewTransferLogs.Size = new System.Drawing.Size(1135, 611);
            this.dataGridViewTransferLogs.TabIndex = 11;
            this.dataGridViewTransferLogs.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTransferLogs_CellMouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.pictureBox1.Location = new System.Drawing.Point(-11, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1200, 10);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // AssetTransferLogPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewTransferLogs);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelAssetIdWithName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AssetTransferLogPanel";
            this.Size = new System.Drawing.Size(1167, 698);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransferLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelAssetIdWithName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridViewTransferLogs;
    }
}
