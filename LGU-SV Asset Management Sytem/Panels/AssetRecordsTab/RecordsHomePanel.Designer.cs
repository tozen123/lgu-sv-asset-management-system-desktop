
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewAssetRecords = new System.Windows.Forms.DataGridView();
            this.panelViewedAsset = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonFilter = new LGU_SV_Asset_Management_Sytem.RoundedButton();
            this.panelFilterSet = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxAO = new System.Windows.Forms.CheckBox();
            this.checkBoxMBO = new System.Windows.Forms.CheckBox();
            this.checkBoxMEO = new System.Windows.Forms.CheckBox();
            this.checkBoxMCR = new System.Windows.Forms.CheckBox();
            this.checkBoxMHO = new System.Windows.Forms.CheckBox();
            this.checkBoxGSO = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxServiceable = new System.Windows.Forms.CheckBox();
            this.checkBoxNonServiceable = new System.Windows.Forms.CheckBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox2014 = new System.Windows.Forms.CheckBox();
            this.checkBox2015 = new System.Windows.Forms.CheckBox();
            this.checkBox2016 = new System.Windows.Forms.CheckBox();
            this.checkBox2017 = new System.Windows.Forms.CheckBox();
            this.checkBox2019 = new System.Windows.Forms.CheckBox();
            this.checkBox2020 = new System.Windows.Forms.CheckBox();
            this.checkBox2018 = new System.Windows.Forms.CheckBox();
            this.checkBox2021 = new System.Windows.Forms.CheckBox();
            this.checkBox2022 = new System.Windows.Forms.CheckBox();
            this.checkBox2023 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetRecords)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelFilterSet.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAssetRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewAssetRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAssetRecords.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewAssetRecords.Location = new System.Drawing.Point(3, 69);
            this.dataGridViewAssetRecords.Name = "dataGridViewAssetRecords";
            this.dataGridViewAssetRecords.ReadOnly = true;
            this.dataGridViewAssetRecords.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewAssetRecords.Size = new System.Drawing.Size(1123, 598);
            this.dataGridViewAssetRecords.TabIndex = 0;
            this.dataGridViewAssetRecords.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAssetRecords_CellMouseClick);
            // 
            // panelViewedAsset
            // 
            this.panelViewedAsset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelViewedAsset.Location = new System.Drawing.Point(3, 69);
            this.panelViewedAsset.Name = "panelViewedAsset";
            this.panelViewedAsset.Size = new System.Drawing.Size(1123, 568);
            this.panelViewedAsset.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonFilter);
            this.groupBox1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(960, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 59);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.White;
            this.buttonFilter.BackgroundColor = System.Drawing.Color.White;
            this.buttonFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonFilter.BorderRadius = 8;
            this.buttonFilter.BorderSize = 1;
            this.buttonFilter.FlatAppearance.BorderSize = 0;
            this.buttonFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilter.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilter.ForeColor = System.Drawing.Color.White;
            this.buttonFilter.Image = global::LGU_SV_Asset_Management_Sytem.Properties.Resources.filter_icon;
            this.buttonFilter.Location = new System.Drawing.Point(56, 24);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonFilter.Size = new System.Drawing.Size(56, 25);
            this.buttonFilter.TabIndex = 35;
            this.buttonFilter.TextColor = System.Drawing.Color.White;
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // panelFilterSet
            // 
            this.panelFilterSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilterSet.AutoSize = true;
            this.panelFilterSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.panelFilterSet.Controls.Add(this.groupBox2);
            this.panelFilterSet.Location = new System.Drawing.Point(705, 59);
            this.panelFilterSet.Name = "panelFilterSet";
            this.panelFilterSet.Size = new System.Drawing.Size(418, 550);
            this.panelFilterSet.TabIndex = 4;
            this.panelFilterSet.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.buttonApply);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 525);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.checkBoxAO);
            this.groupBox5.Controls.Add(this.checkBoxMBO);
            this.groupBox5.Controls.Add(this.checkBoxMEO);
            this.groupBox5.Controls.Add(this.checkBoxMCR);
            this.groupBox5.Controls.Add(this.checkBoxMHO);
            this.groupBox5.Controls.Add(this.checkBoxGSO);
            this.groupBox5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(43, 289);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(312, 189);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Office";
            // 
            // checkBoxAO
            // 
            this.checkBoxAO.AutoSize = true;
            this.checkBoxAO.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAO.Location = new System.Drawing.Point(55, 154);
            this.checkBoxAO.Name = "checkBoxAO";
            this.checkBoxAO.Size = new System.Drawing.Size(159, 26);
            this.checkBoxAO.TabIndex = 8;
            this.checkBoxAO.Text = "AO-Accounting Office";
            this.checkBoxAO.UseVisualStyleBackColor = true;
            // 
            // checkBoxMBO
            // 
            this.checkBoxMBO.AutoSize = true;
            this.checkBoxMBO.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMBO.Location = new System.Drawing.Point(55, 129);
            this.checkBoxMBO.Name = "checkBoxMBO";
            this.checkBoxMBO.Size = new System.Drawing.Size(202, 26);
            this.checkBoxMBO.TabIndex = 7;
            this.checkBoxMBO.Text = "MBO-Municipal Budget Office";
            this.checkBoxMBO.UseVisualStyleBackColor = true;
            // 
            // checkBoxMEO
            // 
            this.checkBoxMEO.AutoSize = true;
            this.checkBoxMEO.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMEO.Location = new System.Drawing.Point(55, 102);
            this.checkBoxMEO.Name = "checkBoxMEO";
            this.checkBoxMEO.Size = new System.Drawing.Size(229, 26);
            this.checkBoxMEO.TabIndex = 6;
            this.checkBoxMEO.Text = "MEO-Municipal Engineering Office";
            this.checkBoxMEO.UseVisualStyleBackColor = true;
            // 
            // checkBoxMCR
            // 
            this.checkBoxMCR.AutoSize = true;
            this.checkBoxMCR.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMCR.Location = new System.Drawing.Point(55, 75);
            this.checkBoxMCR.Name = "checkBoxMCR";
            this.checkBoxMCR.Size = new System.Drawing.Size(202, 26);
            this.checkBoxMCR.TabIndex = 5;
            this.checkBoxMCR.Text = "MCR-Municipal Civil Registrar";
            this.checkBoxMCR.UseVisualStyleBackColor = true;
            // 
            // checkBoxMHO
            // 
            this.checkBoxMHO.AutoSize = true;
            this.checkBoxMHO.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMHO.Location = new System.Drawing.Point(55, 51);
            this.checkBoxMHO.Name = "checkBoxMHO";
            this.checkBoxMHO.Size = new System.Drawing.Size(199, 26);
            this.checkBoxMHO.TabIndex = 4;
            this.checkBoxMHO.Text = "MHO-Municipal Health Office";
            this.checkBoxMHO.UseVisualStyleBackColor = true;
            // 
            // checkBoxGSO
            // 
            this.checkBoxGSO.AutoSize = true;
            this.checkBoxGSO.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGSO.Location = new System.Drawing.Point(55, 26);
            this.checkBoxGSO.Name = "checkBoxGSO";
            this.checkBoxGSO.Size = new System.Drawing.Size(195, 26);
            this.checkBoxGSO.TabIndex = 3;
            this.checkBoxGSO.Text = "GSO-General Services Office";
            this.checkBoxGSO.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.checkBoxServiceable);
            this.groupBox4.Controls.Add(this.checkBoxNonServiceable);
            this.groupBox4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(43, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 87);
            this.groupBox4.TabIndex = 53;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Condition";
            // 
            // checkBoxServiceable
            // 
            this.checkBoxServiceable.AutoSize = true;
            this.checkBoxServiceable.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxServiceable.Location = new System.Drawing.Point(32, 39);
            this.checkBoxServiceable.Name = "checkBoxServiceable";
            this.checkBoxServiceable.Size = new System.Drawing.Size(97, 26);
            this.checkBoxServiceable.TabIndex = 7;
            this.checkBoxServiceable.Text = "Serviceable";
            this.checkBoxServiceable.UseVisualStyleBackColor = true;
            // 
            // checkBoxNonServiceable
            // 
            this.checkBoxNonServiceable.AutoSize = true;
            this.checkBoxNonServiceable.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNonServiceable.Location = new System.Drawing.Point(168, 39);
            this.checkBoxNonServiceable.Name = "checkBoxNonServiceable";
            this.checkBoxNonServiceable.Size = new System.Drawing.Size(128, 26);
            this.checkBoxNonServiceable.TabIndex = 6;
            this.checkBoxNonServiceable.Text = "Non-Serviceable";
            this.checkBoxNonServiceable.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(77)))), ((int)(((byte)(46)))));
            this.buttonApply.FlatAppearance.BorderSize = 0;
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApply.ForeColor = System.Drawing.Color.White;
            this.buttonApply.Location = new System.Drawing.Point(201, 484);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(154, 30);
            this.buttonApply.TabIndex = 52;
            this.buttonApply.Text = "APPLY";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.checkBox2014);
            this.groupBox3.Controls.Add(this.checkBox2015);
            this.groupBox3.Controls.Add(this.checkBox2016);
            this.groupBox3.Controls.Add(this.checkBox2017);
            this.groupBox3.Controls.Add(this.checkBox2019);
            this.groupBox3.Controls.Add(this.checkBox2020);
            this.groupBox3.Controls.Add(this.checkBox2018);
            this.groupBox3.Controls.Add(this.checkBox2021);
            this.groupBox3.Controls.Add(this.checkBox2022);
            this.groupBox3.Controls.Add(this.checkBox2023);
            this.groupBox3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(43, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 158);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Year";
            // 
            // checkBox2014
            // 
            this.checkBox2014.AutoSize = true;
            this.checkBox2014.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2014.Location = new System.Drawing.Point(31, 124);
            this.checkBox2014.Name = "checkBox2014";
            this.checkBox2014.Size = new System.Drawing.Size(56, 27);
            this.checkBox2014.TabIndex = 14;
            this.checkBox2014.Text = "2014";
            this.checkBox2014.UseVisualStyleBackColor = true;
            // 
            // checkBox2015
            // 
            this.checkBox2015.AutoSize = true;
            this.checkBox2015.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2015.Location = new System.Drawing.Point(225, 92);
            this.checkBox2015.Name = "checkBox2015";
            this.checkBox2015.Size = new System.Drawing.Size(56, 27);
            this.checkBox2015.TabIndex = 13;
            this.checkBox2015.Text = "2015";
            this.checkBox2015.UseVisualStyleBackColor = true;
            // 
            // checkBox2016
            // 
            this.checkBox2016.AutoSize = true;
            this.checkBox2016.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2016.Location = new System.Drawing.Point(125, 91);
            this.checkBox2016.Name = "checkBox2016";
            this.checkBox2016.Size = new System.Drawing.Size(56, 27);
            this.checkBox2016.TabIndex = 12;
            this.checkBox2016.Text = "2016";
            this.checkBox2016.UseVisualStyleBackColor = true;
            // 
            // checkBox2017
            // 
            this.checkBox2017.AutoSize = true;
            this.checkBox2017.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2017.Location = new System.Drawing.Point(32, 91);
            this.checkBox2017.Name = "checkBox2017";
            this.checkBox2017.Size = new System.Drawing.Size(55, 27);
            this.checkBox2017.TabIndex = 11;
            this.checkBox2017.Text = "2017";
            this.checkBox2017.UseVisualStyleBackColor = true;
            // 
            // checkBox2019
            // 
            this.checkBox2019.AutoSize = true;
            this.checkBox2019.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2019.Location = new System.Drawing.Point(125, 59);
            this.checkBox2019.Name = "checkBox2019";
            this.checkBox2019.Size = new System.Drawing.Size(56, 27);
            this.checkBox2019.TabIndex = 10;
            this.checkBox2019.Text = "2019";
            this.checkBox2019.UseVisualStyleBackColor = true;
            // 
            // checkBox2020
            // 
            this.checkBox2020.AutoSize = true;
            this.checkBox2020.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2020.Location = new System.Drawing.Point(32, 58);
            this.checkBox2020.Name = "checkBox2020";
            this.checkBox2020.Size = new System.Drawing.Size(59, 27);
            this.checkBox2020.TabIndex = 9;
            this.checkBox2020.Text = "2020";
            this.checkBox2020.UseVisualStyleBackColor = true;
            // 
            // checkBox2018
            // 
            this.checkBox2018.AutoSize = true;
            this.checkBox2018.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2018.Location = new System.Drawing.Point(226, 59);
            this.checkBox2018.Name = "checkBox2018";
            this.checkBox2018.Size = new System.Drawing.Size(56, 27);
            this.checkBox2018.TabIndex = 9;
            this.checkBox2018.Text = "2018";
            this.checkBox2018.UseVisualStyleBackColor = true;
            // 
            // checkBox2021
            // 
            this.checkBox2021.AutoSize = true;
            this.checkBox2021.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2021.Location = new System.Drawing.Point(226, 26);
            this.checkBox2021.Name = "checkBox2021";
            this.checkBox2021.Size = new System.Drawing.Size(55, 27);
            this.checkBox2021.TabIndex = 8;
            this.checkBox2021.Text = "2021";
            this.checkBox2021.UseVisualStyleBackColor = true;
            // 
            // checkBox2022
            // 
            this.checkBox2022.AutoSize = true;
            this.checkBox2022.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2022.Location = new System.Drawing.Point(125, 26);
            this.checkBox2022.Name = "checkBox2022";
            this.checkBox2022.Size = new System.Drawing.Size(58, 27);
            this.checkBox2022.TabIndex = 7;
            this.checkBox2022.Text = "2022";
            this.checkBox2022.UseVisualStyleBackColor = true;
            // 
            // checkBox2023
            // 
            this.checkBox2023.AutoSize = true;
            this.checkBox2023.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2023.Location = new System.Drawing.Point(32, 26);
            this.checkBox2023.Name = "checkBox2023";
            this.checkBox2023.Size = new System.Drawing.Size(59, 27);
            this.checkBox2023.TabIndex = 6;
            this.checkBox2023.Text = "2023";
            this.checkBox2023.UseVisualStyleBackColor = true;
            // 
            // RecordsHomePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFilterSet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewAssetRecords);
            this.Controls.Add(this.panelViewedAsset);
            this.Name = "RecordsHomePanel";
            this.Size = new System.Drawing.Size(1129, 670);
            this.Load += new System.EventHandler(this.RecordsHomePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssetRecords)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelFilterSet.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAssetRecords;
        private System.Windows.Forms.Panel panelViewedAsset;
        private System.Windows.Forms.GroupBox groupBox1;
        private RoundedButton buttonFilter;
        private System.Windows.Forms.Panel panelFilterSet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox2014;
        private System.Windows.Forms.CheckBox checkBox2015;
        private System.Windows.Forms.CheckBox checkBox2016;
        private System.Windows.Forms.CheckBox checkBox2017;
        private System.Windows.Forms.CheckBox checkBox2019;
        private System.Windows.Forms.CheckBox checkBox2020;
        private System.Windows.Forms.CheckBox checkBox2018;
        private System.Windows.Forms.CheckBox checkBox2021;
        private System.Windows.Forms.CheckBox checkBox2022;
        private System.Windows.Forms.CheckBox checkBox2023;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxServiceable;
        private System.Windows.Forms.CheckBox checkBoxNonServiceable;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBoxMCR;
        private System.Windows.Forms.CheckBox checkBoxMHO;
        private System.Windows.Forms.CheckBox checkBoxGSO;
        private System.Windows.Forms.CheckBox checkBoxAO;
        private System.Windows.Forms.CheckBox checkBoxMBO;
        private System.Windows.Forms.CheckBox checkBoxMEO;
    }
}
