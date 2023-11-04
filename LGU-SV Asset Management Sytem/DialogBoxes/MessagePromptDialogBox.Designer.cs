
namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
    partial class MessagePromptDialogBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonContinue = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.pictureBoxBorderTop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBorderTop)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(262, 155);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(189, 34);
            this.buttonContinue.TabIndex = 1;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(318, 39);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(40, 19);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "label1";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxBorderTop
            // 
            this.pictureBoxBorderTop.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxBorderTop.Location = new System.Drawing.Point(-2, -1);
            this.pictureBoxBorderTop.Name = "pictureBoxBorderTop";
            this.pictureBoxBorderTop.Size = new System.Drawing.Size(718, 27);
            this.pictureBoxBorderTop.TabIndex = 3;
            this.pictureBoxBorderTop.TabStop = false;
            // 
            // MessagePromptDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 201);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxBorderTop);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonContinue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MessagePromptDialogBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBorderTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.PictureBox pictureBoxBorderTop;
    }
}