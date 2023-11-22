
namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{
    partial class RecordsHomePanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewAssetRecords = new System.Windows.Forms.DataGridView();
            this.panelViewedAsset = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAssetRecords
            // 
            this.dataGridViewAssetRecords.AllowUserToAddRows = false;
            this.dataGridViewAssetRecords.AllowUserToDeleteRows = false;
            this.dataGridViewAssetRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAssetRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAssetRecords.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAssetRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAssetRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAssetRecords.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAssetRecords.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAssetRecords.Name = "dataGridViewAssetRecords";
            this.dataGridViewAssetRecords.ReadOnly = true;
            this.dataGridViewAssetRecords.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewAssetRecords.Size = new System.Drawing.Size(1120, 664);
            this.dataGridViewAssetRecords.TabIndex = 0;
            this.dataGridViewAssetRecords.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAssetRecords_CellMouseClick);
            // 
            // panelViewedAsset
            // 
            this.panelViewedAsset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelViewedAsset.Location = new System.Drawing.Point(3, 20);
            this.panelViewedAsset.Name = "panelViewedAsset";
            this.panelViewedAsset.Size = new System.Drawing.Size(1123, 568);
            this.panelViewedAsset.TabIndex = 2;
            // 
            // RecordsHomePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewAssetRecords);
            this.Controls.Add(this.panelViewedAsset);
            this.Name = "RecordsHomePanel";
            this.Size = new System.Drawing.Size(1129, 670);
            this.Load += new System.EventHandler(this.RecordsHomePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAssetRecords;
        private System.Windows.Forms.Panel panelViewedAsset;
    }
}
