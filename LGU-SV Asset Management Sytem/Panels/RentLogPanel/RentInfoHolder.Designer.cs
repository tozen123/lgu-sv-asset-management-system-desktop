
namespace LGU_SV_Asset_Management_Sytem.Panels.RentLogPanel
{
    partial class RentInfoHolder
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelAction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(20, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(34, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "title";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.Black;
            this.labelDate.Location = new System.Drawing.Point(20, 54);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(34, 23);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "title";
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAction.ForeColor = System.Drawing.Color.Black;
            this.labelAction.Location = new System.Drawing.Point(20, 96);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(34, 23);
            this.labelAction.TabIndex = 2;
            this.labelAction.Text = "title";
            // 
            // RentInfoHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(173)))));
            this.Controls.Add(this.labelAction);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelTitle);
            this.Name = "RentInfoHolder";
            this.Size = new System.Drawing.Size(656, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelAction;
    }
}
