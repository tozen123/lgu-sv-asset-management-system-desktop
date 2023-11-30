
namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
    partial class InformationForm
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
            this.richTextBoxHeader = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDetails = new System.Windows.Forms.RichTextBox();
            this.buttonClose = new LGU_SV_Asset_Management_Sytem.RoundedButton();
            this.SuspendLayout();
            // 
            // richTextBoxHeader
            // 
            this.richTextBoxHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxHeader.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxHeader.Location = new System.Drawing.Point(32, 21);
            this.richTextBoxHeader.Name = "richTextBoxHeader";
            this.richTextBoxHeader.Size = new System.Drawing.Size(537, 96);
            this.richTextBoxHeader.TabIndex = 17;
            this.richTextBoxHeader.Text = "";
            // 
            // richTextBoxDetails
            // 
            this.richTextBoxDetails.BackColor = System.Drawing.Color.White;
            this.richTextBoxDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDetails.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDetails.Location = new System.Drawing.Point(32, 147);
            this.richTextBoxDetails.Name = "richTextBoxDetails";
            this.richTextBoxDetails.ReadOnly = true;
            this.richTextBoxDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxDetails.Size = new System.Drawing.Size(537, 577);
            this.richTextBoxDetails.TabIndex = 18;
            this.richTextBoxDetails.Text = "";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.buttonClose.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(68)))));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.BorderColor = System.Drawing.Color.Transparent;
            this.buttonClose.BorderRadius = 8;
            this.buttonClose.BorderSize = 0;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Image = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.buttonClose;
            this.buttonClose.Location = new System.Drawing.Point(546, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonClose.Size = new System.Drawing.Size(40, 39);
            this.buttonClose.TabIndex = 16;
            this.buttonClose.TextColor = System.Drawing.Color.White;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 736);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBoxDetails);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.richTextBoxHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InformationForm";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton buttonClose;
        private System.Windows.Forms.RichTextBox richTextBoxHeader;
        private System.Windows.Forms.RichTextBox richTextBoxDetails;
    }
}