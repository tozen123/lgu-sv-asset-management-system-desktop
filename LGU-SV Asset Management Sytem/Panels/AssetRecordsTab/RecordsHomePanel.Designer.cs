
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
            this.dataGridViewAssetRecords = new System.Windows.Forms.DataGridView();
            this.panelViewedAsset = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAssetRecords
            // 
            this.dataGridViewAssetRecords.AllowUserToAddRows = false;
            this.dataGridViewAssetRecords.AllowUserToDeleteRows = false;
            this.dataGridViewAssetRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAssetRecords.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAssetRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssetRecords.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAssetRecords.Name = "dataGridViewAssetRecords";
            this.dataGridViewAssetRecords.ReadOnly = true;
            this.dataGridViewAssetRecords.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewAssetRecords.Size = new System.Drawing.Size(1123, 664);
            this.dataGridViewAssetRecords.TabIndex = 0;
            this.dataGridViewAssetRecords.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAssetRecords_CellMouseClick);
            // 
            // panelViewedAsset
            // 
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAssetRecords;
        private System.Windows.Forms.Panel panelViewedAsset;
    }
}
