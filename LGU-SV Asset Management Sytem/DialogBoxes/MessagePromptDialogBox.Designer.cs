
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
            this.pictureBoxBorderTop = new System.Windows.Forms.PictureBox();
            this.labelMessage = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBorderTop)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(265, 155);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(189, 34);
            this.buttonContinue.TabIndex = 1;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
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
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.SystemColors.Control;
            this.labelMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelMessage.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(29, 32);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(660, 117);
            this.labelMessage.TabIndex = 4;
            this.labelMessage.Text = "";
            // 
            // MessagePromptDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 201);
            this.ControlBox = false;
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.pictureBoxBorderTop);
            this.Controls.Add(this.buttonContinue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MessagePromptDialogBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBorderTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.PictureBox pictureBoxBorderTop;
        private System.Windows.Forms.RichTextBox labelMessage;
    }
}