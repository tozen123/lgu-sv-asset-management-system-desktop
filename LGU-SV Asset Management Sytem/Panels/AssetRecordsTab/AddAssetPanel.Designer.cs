
namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{
    partial class AddAssetPanel
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
            this.buttonAddMoreAsset = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelAssetCount = new System.Windows.Forms.Label();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.pictureBoxAssetImage = new System.Windows.Forms.PictureBox();
            this.buttonUploadAssetImage = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.checkBoxIsMaintanable = new System.Windows.Forms.CheckBox();
            this.textBoxLifespan = new System.Windows.Forms.TextBox();
            this.textBoxPurchaseAmount = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxCondition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxAvailability = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.dateTimePickerPurchase = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxLocation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAddingAsset = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAssetImage)).BeginInit();
            this.tabAddingAsset.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddMoreAsset
            // 
            this.buttonAddMoreAsset.Location = new System.Drawing.Point(3, 3);
            this.buttonAddMoreAsset.Name = "buttonAddMoreAsset";
            this.buttonAddMoreAsset.Size = new System.Drawing.Size(109, 23);
            this.buttonAddMoreAsset.TabIndex = 0;
            this.buttonAddMoreAsset.Text = "+ Add More Asset";
            this.buttonAddMoreAsset.UseVisualStyleBackColor = true;
            this.buttonAddMoreAsset.Click += new System.EventHandler(this.buttonAddMoreAsset_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(924, 552);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(193, 36);
            this.buttonAdd.TabIndex = 28;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelAssetCount);
            this.tabPage1.Controls.Add(this.groupBoxImage);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.comboBoxEmployee);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.comboBoxSupplier);
            this.tabPage1.Controls.Add(this.checkBoxIsMaintanable);
            this.tabPage1.Controls.Add(this.textBoxLifespan);
            this.tabPage1.Controls.Add(this.textBoxPurchaseAmount);
            this.tabPage1.Controls.Add(this.textBoxQuantity);
            this.tabPage1.Controls.Add(this.textBoxName);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.comboBoxCondition);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.comboBoxAvailability);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboBoxUnit);
            this.tabPage1.Controls.Add(this.dateTimePickerPurchase);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboBoxLocation);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboBoxCategory);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1105, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Asset 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelAssetCount
            // 
            this.labelAssetCount.AutoSize = true;
            this.labelAssetCount.Location = new System.Drawing.Point(36, 29);
            this.labelAssetCount.Name = "labelAssetCount";
            this.labelAssetCount.Size = new System.Drawing.Size(13, 13);
            this.labelAssetCount.TabIndex = 54;
            this.labelAssetCount.Text = "1";
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.pictureBoxAssetImage);
            this.groupBoxImage.Controls.Add(this.buttonUploadAssetImage);
            this.groupBoxImage.Location = new System.Drawing.Point(719, 207);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(308, 249);
            this.groupBoxImage.TabIndex = 53;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Asset Image";
            // 
            // pictureBoxAssetImage
            // 
            this.pictureBoxAssetImage.Location = new System.Drawing.Point(60, 19);
            this.pictureBoxAssetImage.Name = "pictureBoxAssetImage";
            this.pictureBoxAssetImage.Size = new System.Drawing.Size(204, 194);
            this.pictureBoxAssetImage.TabIndex = 1;
            this.pictureBoxAssetImage.TabStop = false;
            // 
            // buttonUploadAssetImage
            // 
            this.buttonUploadAssetImage.Location = new System.Drawing.Point(81, 219);
            this.buttonUploadAssetImage.Name = "buttonUploadAssetImage";
            this.buttonUploadAssetImage.Size = new System.Drawing.Size(160, 23);
            this.buttonUploadAssetImage.TabIndex = 0;
            this.buttonUploadAssetImage.Text = "Upload Image";
            this.buttonUploadAssetImage.UseVisualStyleBackColor = true;
            this.buttonUploadAssetImage.Click += new System.EventHandler(this.buttonUploadAssetImage_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(716, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Employee:";
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(830, 159);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(197, 21);
            this.comboBoxEmployee.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(716, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Supplier:";
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(830, 121);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(197, 21);
            this.comboBoxSupplier.TabIndex = 49;
            // 
            // checkBoxIsMaintanable
            // 
            this.checkBoxIsMaintanable.AutoSize = true;
            this.checkBoxIsMaintanable.Location = new System.Drawing.Point(719, 77);
            this.checkBoxIsMaintanable.Name = "checkBoxIsMaintanable";
            this.checkBoxIsMaintanable.Size = new System.Drawing.Size(130, 17);
            this.checkBoxIsMaintanable.TabIndex = 48;
            this.checkBoxIsMaintanable.Text = "Is Asset Maintanable?";
            this.checkBoxIsMaintanable.UseVisualStyleBackColor = true;
            // 
            // textBoxLifespan
            // 
            this.textBoxLifespan.Location = new System.Drawing.Point(496, 210);
            this.textBoxLifespan.Name = "textBoxLifespan";
            this.textBoxLifespan.Size = new System.Drawing.Size(197, 20);
            this.textBoxLifespan.TabIndex = 47;
            // 
            // textBoxPurchaseAmount
            // 
            this.textBoxPurchaseAmount.Location = new System.Drawing.Point(150, 253);
            this.textBoxPurchaseAmount.Name = "textBoxPurchaseAmount";
            this.textBoxPurchaseAmount.Size = new System.Drawing.Size(197, 20);
            this.textBoxPurchaseAmount.TabIndex = 37;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(150, 114);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(197, 20);
            this.textBoxQuantity.TabIndex = 31;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(150, 73);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(197, 20);
            this.textBoxName.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(382, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "LifeSpan";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(382, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Condition:";
            // 
            // comboBoxCondition
            // 
            this.comboBoxCondition.FormattingEnabled = true;
            this.comboBoxCondition.Location = new System.Drawing.Point(496, 162);
            this.comboBoxCondition.Name = "comboBoxCondition";
            this.comboBoxCondition.Size = new System.Drawing.Size(197, 21);
            this.comboBoxCondition.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(382, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Availability:";
            // 
            // comboBoxAvailability
            // 
            this.comboBoxAvailability.FormattingEnabled = true;
            this.comboBoxAvailability.Location = new System.Drawing.Point(496, 114);
            this.comboBoxAvailability.Name = "comboBoxAvailability";
            this.comboBoxAvailability.Size = new System.Drawing.Size(197, 21);
            this.comboBoxAvailability.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Unit:";
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Location = new System.Drawing.Point(496, 73);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(197, 21);
            this.comboBoxUnit.TabIndex = 40;
            // 
            // dateTimePickerPurchase
            // 
            this.dateTimePickerPurchase.Location = new System.Drawing.Point(496, 253);
            this.dateTimePickerPurchase.Name = "dateTimePickerPurchase";
            this.dateTimePickerPurchase.Size = new System.Drawing.Size(197, 20);
            this.dateTimePickerPurchase.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Purchase Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Purchase Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Location:";
            // 
            // comboBoxLocation
            // 
            this.comboBoxLocation.FormattingEnabled = true;
            this.comboBoxLocation.Location = new System.Drawing.Point(150, 207);
            this.comboBoxLocation.Name = "comboBoxLocation";
            this.comboBoxLocation.Size = new System.Drawing.Size(197, 21);
            this.comboBoxLocation.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Category:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(150, 159);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(197, 21);
            this.comboBoxCategory.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Quantity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Name:";
            // 
            // tabAddingAsset
            // 
            this.tabAddingAsset.Controls.Add(this.tabPage1);
            this.tabAddingAsset.Location = new System.Drawing.Point(4, 33);
            this.tabAddingAsset.Name = "tabAddingAsset";
            this.tabAddingAsset.SelectedIndex = 0;
            this.tabAddingAsset.Size = new System.Drawing.Size(1113, 513);
            this.tabAddingAsset.TabIndex = 29;
            // 
            // AddAssetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabAddingAsset);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonAddMoreAsset);
            this.Name = "AddAssetPanel";
            this.Size = new System.Drawing.Size(1129, 591);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAssetImage)).EndInit();
            this.tabAddingAsset.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddMoreAsset;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.PictureBox pictureBoxAssetImage;
        private System.Windows.Forms.Button buttonUploadAssetImage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.CheckBox checkBoxIsMaintanable;
        private System.Windows.Forms.TextBox textBoxLifespan;
        private System.Windows.Forms.TextBox textBoxPurchaseAmount;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxAvailability;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.DateTimePicker dateTimePickerPurchase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabAddingAsset;
        private System.Windows.Forms.Label labelAssetCount;
    }
}
