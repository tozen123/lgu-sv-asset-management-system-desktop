
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.labelOperatorName = new System.Windows.Forms.Label();
            this.buttonBack = new LGU_SV_Asset_Management_Sytem.RoundedButton();
            this.dataGridViewAssetRecords = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset List:";
            // 
            // labelOperatorName
            // 
            this.labelOperatorName.AutoSize = true;
            this.labelOperatorName.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperatorName.Location = new System.Drawing.Point(198, 26);
            this.labelOperatorName.Name = "labelOperatorName";
            this.labelOperatorName.Size = new System.Drawing.Size(154, 37);
            this.labelOperatorName.TabIndex = 1;
            this.labelOperatorName.Text = "LABEL_NAME";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.buttonBack.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.buttonBack.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonBack.BorderRadius = 15;
            this.buttonBack.BorderSize = 0;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Image = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.buttonBack;
            this.buttonBack.Location = new System.Drawing.Point(15, 14);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonBack.Size = new System.Drawing.Size(54, 49);
            this.buttonBack.TabIndex = 58;
            this.buttonBack.TextColor = System.Drawing.Color.White;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonExitPanel_Click);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAssetRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAssetRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAssetRecords.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAssetRecords.Location = new System.Drawing.Point(13, 69);
            this.dataGridViewAssetRecords.Name = "dataGridViewAssetRecords";
            this.dataGridViewAssetRecords.ReadOnly = true;
            this.dataGridViewAssetRecords.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewAssetRecords.Size = new System.Drawing.Size(1113, 503);
            this.dataGridViewAssetRecords.TabIndex = 59;
            // 
            // OperatorHandledAssetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewAssetRecords);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelOperatorName);
            this.Controls.Add(this.label1);
            this.Name = "OperatorHandledAssetPanel";
            this.Size = new System.Drawing.Size(1139, 586);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelOperatorName;
        private RoundedButton buttonBack;
        private System.Windows.Forms.DataGridView dataGridViewAssetRecords;
    }
}
