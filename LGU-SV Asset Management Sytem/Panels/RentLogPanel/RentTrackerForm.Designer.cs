
namespace LGU_SV_Asset_Management_Sytem.Panels.RentLogPanel
{
    partial class RentTrackerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentTrackerForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonMssing = new System.Windows.Forms.Button();
            this.buttonReturned = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxRDate = new System.Windows.Forms.TextBox();
            this.textBoxStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonIncompleteReturned = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTotalQuant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReturned = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMissing = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonIncompleteReturned);
            this.groupBox1.Controls.Add(this.buttonMssing);
            this.groupBox1.Controls.Add(this.buttonReturned);
            this.groupBox1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // buttonMssing
            // 
            this.buttonMssing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonMssing.FlatAppearance.BorderSize = 0;
            this.buttonMssing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMssing.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMssing.ForeColor = System.Drawing.Color.White;
            this.buttonMssing.Location = new System.Drawing.Point(478, 30);
            this.buttonMssing.Name = "buttonMssing";
            this.buttonMssing.Size = new System.Drawing.Size(195, 42);
            this.buttonMssing.TabIndex = 1;
            this.buttonMssing.Text = "DECLARE AS MISSING";
            this.buttonMssing.UseVisualStyleBackColor = false;
            this.buttonMssing.Click += new System.EventHandler(this.buttonMssing_Click);
            // 
            // buttonReturned
            // 
            this.buttonReturned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonReturned.FlatAppearance.BorderSize = 0;
            this.buttonReturned.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturned.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturned.ForeColor = System.Drawing.Color.White;
            this.buttonReturned.Location = new System.Drawing.Point(53, 30);
            this.buttonReturned.Name = "buttonReturned";
            this.buttonReturned.Size = new System.Drawing.Size(195, 42);
            this.buttonReturned.TabIndex = 0;
            this.buttonReturned.Text = "RETURNED";
            this.buttonReturned.UseVisualStyleBackColor = false;
            this.buttonReturned.Click += new System.EventHandler(this.buttonReturned_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBoxInfo);
            this.groupBox2.Controls.Add(this.textBoxStatus);
            this.groupBox2.Controls.Add(this.textBoxRDate);
            this.groupBox2.Controls.Add(this.textBoxStartDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 306);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(177, 117);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(515, 31);
            this.textBoxStatus.TabIndex = 5;
            // 
            // textBoxRDate
            // 
            this.textBoxRDate.Location = new System.Drawing.Point(177, 77);
            this.textBoxRDate.Name = "textBoxRDate";
            this.textBoxRDate.ReadOnly = true;
            this.textBoxRDate.Size = new System.Drawing.Size(515, 31);
            this.textBoxRDate.TabIndex = 4;
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Location = new System.Drawing.Point(177, 40);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.ReadOnly = true;
            this.textBoxStartDate.Size = new System.Drawing.Size(515, 31);
            this.textBoxStartDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Returned Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rent Start Date:";
            // 
            // buttonIncompleteReturned
            // 
            this.buttonIncompleteReturned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonIncompleteReturned.FlatAppearance.BorderSize = 0;
            this.buttonIncompleteReturned.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIncompleteReturned.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIncompleteReturned.ForeColor = System.Drawing.Color.White;
            this.buttonIncompleteReturned.Location = new System.Drawing.Point(266, 30);
            this.buttonIncompleteReturned.Name = "buttonIncompleteReturned";
            this.buttonIncompleteReturned.Size = new System.Drawing.Size(195, 42);
            this.buttonIncompleteReturned.TabIndex = 2;
            this.buttonIncompleteReturned.Text = "INCOMPLETE RETURNED";
            this.buttonIncompleteReturned.UseVisualStyleBackColor = false;
            this.buttonIncompleteReturned.Click += new System.EventHandler(this.buttonIncompleteReturned_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.label7);
            this.groupBoxInfo.Controls.Add(this.textBoxMissing);
            this.groupBoxInfo.Controls.Add(this.label6);
            this.groupBoxInfo.Controls.Add(this.textBoxTotalQuant);
            this.groupBoxInfo.Controls.Add(this.label5);
            this.groupBoxInfo.Controls.Add(this.textBoxReturned);
            this.groupBoxInfo.Controls.Add(this.label4);
            this.groupBoxInfo.Location = new System.Drawing.Point(7, 162);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(709, 138);
            this.groupBoxInfo.TabIndex = 6;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Incomplete Returned Information";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(574, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "Total Quantity";
            // 
            // textBoxTotalQuant
            // 
            this.textBoxTotalQuant.Location = new System.Drawing.Point(389, 37);
            this.textBoxTotalQuant.Name = "textBoxTotalQuant";
            this.textBoxTotalQuant.ReadOnly = true;
            this.textBoxTotalQuant.Size = new System.Drawing.Size(179, 31);
            this.textBoxTotalQuant.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 28);
            this.label5.TabIndex = 13;
            this.label5.Text = "Out Of";
            // 
            // textBoxReturned
            // 
            this.textBoxReturned.Location = new System.Drawing.Point(190, 37);
            this.textBoxReturned.Name = "textBoxReturned";
            this.textBoxReturned.ReadOnly = true;
            this.textBoxReturned.Size = new System.Drawing.Size(124, 31);
            this.textBoxReturned.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "Quantity Returned: ";
            // 
            // textBoxMissing
            // 
            this.textBoxMissing.Location = new System.Drawing.Point(309, 85);
            this.textBoxMissing.Name = "textBoxMissing";
            this.textBoxMissing.ReadOnly = true;
            this.textBoxMissing.Size = new System.Drawing.Size(390, 31);
            this.textBoxMissing.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(283, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Missing/Failed To Returned Asset Quantity:";
            // 
            // RentTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 425);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RentTrackerForm";
            this.Text = "RentTrackerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReturned;
        private System.Windows.Forms.Button buttonMssing;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStartDate;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxRDate;
        private System.Windows.Forms.Button buttonIncompleteReturned;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTotalQuant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxReturned;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMissing;
    }
}