using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{

    public partial class AddAssetPanel : UserControl
    {
        List<Asset> assetToAdd = new List<Asset>();

        private DatabaseConnection databaseConnection;

        private List<PictureBox> pictureBoxList = new List<PictureBox>();

        string supervisor_id;
        string supervisor_location;
        Control pHandler;
        MainForm mainForm;
        public enum AssetType
        {
            New,
            Existing
        }

        public AssetType assetType;

        public AddAssetPanel(AssetType _assetType, string id, string location, Control _panelHandler, MainForm _mf)
        {
            InitializeComponent();
            supervisor_id = id;
            supervisor_location = location;
            mainForm = _mf;
            pHandler = _panelHandler;

            assetType = _assetType;
            databaseConnection = new DatabaseConnection();

            Init();

            Asset newAsset = new Asset();
            assetToAdd.Add(newAsset);
            pictureBoxAssetImage.Image = LGU_SV_Asset_Management_Sytem.Properties.Resources.empty_image;
            pictureBoxAssetImage.Image.Tag = "empty_image";
        }
        private void Init()
        {
            switch (assetType)
            {
                case AssetType.New:
                    buttonSave.Text = "Add New Asset";

                    break;
                case AssetType.Existing:
                    buttonSave.Text = "Add Existing Asset";

                    break;
            }

            pictureBoxList.Add(pictureBoxAssetImage);

            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            /*
            comboBoxAvailability.Items.Add("USED");
            comboBoxAvailability.Items.Add("AVAILABLE");
            */
            comboBoxCondition.Items.Add("SERVICEABLE");
            comboBoxCondition.Items.Add("NON-SERVICEABLE");

            // ----------------
            // ----------------
            // ----------------
            //  Automatically Sets the condition to serviceable
            comboBoxCondition.SelectedItem = comboBoxCondition.Items[0];
            comboBoxCondition.Enabled = false;
            // ----------------
            // ----------------
            // ----------------

            comboBoxUnit.Items.Add("SET");
            comboBoxUnit.Items.Add("SINGLE");


            string query = "SELECT  Id, FName, MName, LName FROM AssetCoordinator";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string result = "";
            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {
                    result += " " + row[col].ToString();
                }
                comboBoxEmployee.Items.Add(" | " + result.Split(' ')[1] + " | " + result.Split(' ')[2] + " " + result.Split(' ')[3] + " " + result.Split(' ')[4]);
                result = "";
            }

            databaseConnection.CloseConnection();

            ComboBoxRetriever(comboBoxCategory, "SELECT assetCategoryId, assetCategoryName FROM AssetCategory");
            ComboBoxRetriever(comboBoxSupplier, "SELECT supplierId, supplierName FROM Supplier");

        }

        public void ComboBoxRetriever(ComboBox combobox, string query)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string result = ""; 
            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {

                    result += " | " + row[col].ToString();
                }
                combobox.Items.Add(result);
                result = "";
            }

            databaseConnection.CloseConnection();
        }
        private void CloneControls(TabPage sourceTabPage, TabPage destinationTabPage)
        {
            foreach (Control control in sourceTabPage.Controls)
            {
                Control clonedControl = CloneControl(control);
                destinationTabPage.Controls.Add(clonedControl);
            }
        }
        private Control CloneControl(Control control)
        {
            // Clone controls by creating new instance based on the properties of the source control
            Type type = control.GetType();
            Control newControl = (Control)Activator.CreateInstance(type);
            newControl.Name = control.Name;
            newControl.Size = control.Size;
            newControl.Location = control.Location;
            newControl.Font = control.Font;


            // Conditional for handling controls
            if (control is Label)
            {
               
                ((Label)newControl).Text = ((Label)control).Text;
                ((Label)newControl).BackColor = ((Label)control).BackColor;
                ((Label)newControl).ForeColor = ((Label)control).ForeColor;
                if (control.Name == "labelAssetCount")
                {
                    ((Label)newControl).Text = (assetToAdd.Count + 1).ToString();
                }
            }
            else if (control is GroupBox)
            {
               
                ((GroupBox)newControl).Text = ((GroupBox)control).Text;

                foreach (Control groupBoxControl in ((GroupBox)control).Controls)
                {
                    Control clonedGroupBoxControl = CloneControl(groupBoxControl);
                    ((GroupBox)newControl).Controls.Add(clonedGroupBoxControl);

                    if (clonedGroupBoxControl is Button)
                    {
                        
                        ((Button)clonedGroupBoxControl).Text = ((Button)groupBoxControl).Text;
                        ((Button)clonedGroupBoxControl).Click += buttonUploadAssetImage_Click;
                        ((Button)clonedGroupBoxControl).BackColor = Color.Transparent;
                    }
                    else if (clonedGroupBoxControl is PictureBox)
                    {

                        pictureBoxList.Add((PictureBox)clonedGroupBoxControl);
                        ((PictureBox)clonedGroupBoxControl).Image = ((PictureBox)groupBoxControl).Image;

                        ((PictureBox)clonedGroupBoxControl).Image = null;
                        ((PictureBox)clonedGroupBoxControl).SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            else if (control is CheckBox)
            {
                
                ((CheckBox)newControl).Text = ((CheckBox)control).Text;
            }
            else if (control is TextBox)
            {
                ((TextBox)newControl).Text = ((TextBox)control).Text;
                ((TextBox)newControl).BackColor = ((TextBox)control).BackColor;
                ((TextBox)newControl).Text = "";
            }
            else if (control is ComboBox)
            {

                ComboBox sourceComboBox = (ComboBox)control;
                ComboBox clonedComboBox = (ComboBox)newControl;


                foreach (object item in sourceComboBox.Items)
                {
                    clonedComboBox.Items.Add(item);
                }
            } if (control is PictureBox)
            {
                ((PictureBox)newControl).BackColor = ((PictureBox)control).BackColor;
            }

            return newControl;
        }

        private void buttonAddMoreAsset_Click(object sender, EventArgs e)
        {
 
            Asset newAsset = new Asset();

  
            TabPage newTabPage = new TabPage("Asset " + (assetToAdd.Count + 1));
            newTabPage.BackColor = Color.White;

      
            CloneControls(tabAddingAsset.TabPages[0], newTabPage);

 
            tabAddingAsset.TabPages.Add(newTabPage);


            assetToAdd.Add(newAsset);
        }

        private void buttonUploadAssetImage_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int buttonIndex = pictureBoxList.FindIndex(pb => pb.Parent == clickedButton.Parent);
                if (buttonIndex != -1)
                {
                    PictureBox correspondingPictureBox = pictureBoxList[buttonIndex];
                    string designName = clickedButton.Name;
                    Console.WriteLine($"Button with design name '{designName}' was clicked for PictureBox {buttonIndex + 1}.");

                    // Call your image upload logic for the corresponding PictureBox
                    UploadImage(correspondingPictureBox);
                }
            }

        }

        private byte[] imageData;
        private void UploadImage(PictureBox pictureBox)
        {
            using (DialogBoxes.AssetUploadImageDialogBox uploadImageDialogBox = new DialogBoxes.AssetUploadImageDialogBox())
            {
                if (uploadImageDialogBox.ShowDialog() == DialogResult.OK)
                {
                    byte[] _imagedata = uploadImageDialogBox.imageByte;
                    if (_imagedata != null)
                    {
                        imageData = _imagedata;
                        pictureBox.Image = Utilities.ConvertByteArrayToImage(imageData);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            Console.WriteLine(assetToAdd.Count.ToString());
            Console.WriteLine(supervisor_id);
            for (int i = 0; i < tabAddingAsset.TabPages.Count && i < assetToAdd.Count; i++)
            {
                TabPage tabPage = tabAddingAsset.TabPages[i];
                Asset asset = assetToAdd[i];

                // Textbox
                TextBox TextBox_AssetName = tabPage.Controls.Find("textBoxName", true).FirstOrDefault() as TextBox;
                TextBox TextBox_Quantity = tabPage.Controls.Find("textBoxQuantity", true).FirstOrDefault() as TextBox;
                TextBox TextBox_PurchaseAmount = tabPage.Controls.Find("textBoxPurchaseAmount", true).FirstOrDefault() as TextBox;
                TextBox TextBox_LifeSpan = tabPage.Controls.Find("textBoxLifespan", true).FirstOrDefault() as TextBox;

                // ComboBox
                ComboBox ComboBox_Category = tabPage.Controls.Find("comboBoxCategory", true).FirstOrDefault() as ComboBox;
                ComboBox ComboBox_Unit = tabPage.Controls.Find("comboBoxUnit", true).FirstOrDefault() as ComboBox;
        
                //ComboBox ComboBox_Availability = tabPage.Controls.Find("comboBoxAvailability", true).FirstOrDefault() as ComboBox;
                ComboBox ComboBox_Condition = tabPage.Controls.Find("comboBoxCondition", true).FirstOrDefault() as ComboBox;

                ComboBox ComboBox_Employee = tabPage.Controls.Find("comboBoxEmployee", true).FirstOrDefault() as ComboBox;
                ComboBox ComboBox_Supplier = tabPage.Controls.Find("comboBoxSupplier", true).FirstOrDefault() as ComboBox;

                // DateTime
                DateTimePicker DateTimePicker_purchaseDate = tabPage.Controls.Find("dateTimePickerPurchase", true).FirstOrDefault() as DateTimePicker;

                // Checkbox
                CheckBox CheckBox_isMaintainable = tabPage.Controls.Find("checkBoxIsMaintanable", true).FirstOrDefault() as CheckBox;

                // Image
                PictureBox PictureBox_assetImage = tabPage.Controls.Find("pictureBoxAssetImage", true).FirstOrDefault() as PictureBox;



                //New Attrib

                RichTextBox richTextBox_Purpose = tabPage.Controls.Find("richTextBoxPurpose", true).FirstOrDefault() as RichTextBox;
                RichTextBox richTextBox_description = tabPage.Controls.Find("richTextBoxDesc", true).FirstOrDefault() as RichTextBox;
                TextBox textBox_pnumber = tabPage.Controls.Find("textBoxPNumber", true).FirstOrDefault() as TextBox;




                // QR Generator
                if (string.IsNullOrEmpty(TextBox_AssetName.Text))
                {
                    MessagePrompt("Empty Field: Asset Name cannot be empty.");
                    return;
                }

                if (string.IsNullOrEmpty(textBoxQuantity.Text))
                {
                    MessagePrompt("Empty Field: Quantity cannot be empty.");
                    return;
                }
                else if (!int.TryParse(textBoxQuantity.Text, out _))
                {
                    MessagePrompt("Invalid Input: Please enter a valid integer for the quantity.");
                    textBoxQuantity.Text = string.Empty;
                    return;
                }

                if (ComboBox_Category.SelectedItem == null)
                {
                    MessagePrompt("Empty Field: Please select a value from the category.");
                    return;
                }

                if (string.IsNullOrEmpty(textBoxPurchaseAmount.Text))
                {
                    MessagePrompt("Empty Field: Price cannot be empty.");
                    return;
                }
                else if (!int.TryParse(textBoxPurchaseAmount.Text, out _))
                {
                    MessagePrompt("Invalid Input: Please enter a valid integer for the price.");
                    textBoxPurchaseAmount.Text = string.Empty;
                    return;
                }

                if (comboBoxCondition.SelectedItem == null)
                {
                    MessagePrompt("Empty Field: Please select a value from the conditions.");
                    return;
                }

                if (ComboBox_Employee.SelectedItem == null)
                {
                    MessagePrompt("Empty Field: Please select a value from the coordinators.");
                    return;
                }

                if (string.IsNullOrEmpty(textBoxPNumber.Text))
                {
                    MessagePrompt("Empty Field: Property Number cannot be empty.");
                    return;
                }
                else if (!int.TryParse(textBoxPNumber.Text, out _))
                {
                    MessagePrompt("Invalid Input: Please enter a valid integer for the Property Number.");
                    textBoxPNumber.Text = string.Empty;
                    return;
                }

                if (ComboBox_Unit.SelectedItem == null)
                {
                    MessagePrompt("Empty Field: Please select a value from the units.");
                    return;
                }

                if (string.IsNullOrEmpty(richTextBoxPurpose.Text))
                {
                    MessagePrompt("Empty Field: Asset Purpose cannot be empty.");
                    return;
                }

                if (string.IsNullOrEmpty(richTextBoxDesc.Text))
                {
                    MessagePrompt("Empty Field: Asset Description cannot be empty.");
                    return;
                }

                if (comboBoxSupplier.SelectedItem == null)
                {
                    MessagePrompt("Empty Field: Please select a value from the suppliers.");
                    return;
                }

                
                if(pictureBoxAssetImage.Image == null)
                {
                    MessagePrompt("Empty Field: Please upload an image for the asset");
                    return;
                }


                // Region (First Reading [Need 2nd Reading for finalizing asset attributes])

                // Note for programmers who will read this section:
                // The following code might not represent the best implementation.
                // The code and logic could result in error on database inputs,
                // causing to major errors and evenn potential crashes due to a lack of validation.
                // This code was developed for a fast implementation to meet the deadline. :(


                // Supervisor
                if (int.TryParse(supervisor_id, out int parsedSupervisorId))
                    {
                        asset.AssetSupervisorId = parsedSupervisorId;
                    }

                    // Employee

                    if (int.TryParse(ComboBox_Employee.SelectedItem.ToString().Split(' ')[2], out int empId))
                    {
                        asset.CurrentEmployeeId = empId;
                    }


                    // Supplier

                    if (int.TryParse(ComboBox_Supplier.SelectedItem.ToString().Split(' ')[2], out int supId))
                    {
                        asset.SupplierId = supId;
                    }

                    // Category

                    if (int.TryParse(ComboBox_Category.SelectedItem?.ToString().Split(' ')[2], out int catId))
                    {
                        asset.AssetCategoryId = catId;
                    }
                    
                    asset.AssetName = TextBox_AssetName.Text;
                    asset.AssetCondition = ComboBox_Condition.SelectedItem?.ToString();
                    //asset.AssetAvailability = ComboBox_Availability.SelectedItem?.ToString();
                    asset.AssetLocation = supervisor_location;
                    asset.IsArchive = false;
                    asset.AssetPurchaseAmount = Convert.ToDecimal(TextBox_PurchaseAmount.Text);
                    asset.AssetQuantity = Convert.ToInt32(TextBox_Quantity.Text);
                    asset.AssetUnit = ComboBox_Unit.SelectedItem?.ToString();
                    asset.AssetImage = Utilities.ConvertImageToBytes(PictureBox_assetImage.Image);
                    asset.AssetPurchaseDate = DateTimePicker_purchaseDate.Value;
                    asset.IsMaintainable = CheckBox_isMaintainable.Checked;
                    asset.IsMissing = false;

                    asset.AssetPurpose = richTextBox_Purpose.Text;
                    asset.AssetDescription = richTextBox_description.Text;

                    asset.AssetPropertyNumber = Convert.ToInt32(textBox_pnumber.Text); 

                    // LifeSpan
                /*
                if (int.TryParse(TextBox_LifeSpan.Text, out int lifespan))
                    {
                        asset.AssetLifeSpan = lifespan;
                    }
                */
                //End Region


                /*
                 * 
                 * Important Notes to Remember:
                 * Maintenance are generated after null in the first creation of asset
                 * 
                 */


                /*
                // PRE-UPLOAD LOGIC
                string query = "INSERT INTO Assets (assetSupervisorID, currentAssetEmployeeID, supplierID, assetCategoryID, assetName," +
                    " assetCondition, assetAvailability, assetLocation, assetIsArchive, assetPurchaseDate, assetPurchaseAmount," +
                    " assetQuantity, assetUnit, assetImage, assetIsMissing, assetIsMaintainable, assetLifeSpan) VALUES " +
                    " (@supervisorId, @employeeId, @supplierId, @categoryId, @name, @condition, @availability,  @location, @isarchive," +
                    " @purchasedate, @purchaseamount, @quantity, @unit, @image, @ismissing, @ismaintainable, @lifeSpan)";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "@supervisorId",  asset.AssetSupervisorId },
                    { "@employeeId", asset.CurrentEmployeeId },
                    { "@supplierId",  asset.SupplierId },
                    { "@categoryId", asset.AssetCategoryId },
                    { "@name",  asset.AssetName },
                    { "@condition", asset.AssetCondition },
                    { "@availability", asset.AssetAvailability },
                    { "@location", asset.AssetLocation },
                    { "@isarchive", asset.IsArchive },
                    { "@purchasedate", asset.AssetPurchaseDate },
                    { "@purchaseamount", asset.AssetPurchaseAmount },
                    { "@quantity", asset.AssetQuantity },
                    { "@unit", asset.AssetQuantity },
                    { "@image", asset.AssetImage},
                    { "@ismissing", asset.IsMissing},
                    { "@ismaintainable", asset.IsMaintainable},
                    { "@lifeSpan", asset.AssetLifeSpan}

                };
                int qr_asset_gen_id = databaseConnection.UploadToDatabaseAndGetId(query, parameters);

                Console.WriteLine("Data Uploaded");

                // POST-UPLOAD LOGIC
                string QRDefinition = $"assetId:{qr_asset_gen_id};assetName:{asset.AssetName}";

                string query1 = "UPDATE Assets SET assetQrCodeImage = @generatedQrImageByte, assetQrStrDefinition = @qrDefinition WHERE " +
                    "assetId = @assetId";
                Dictionary<string, object> parameters1 = new Dictionary<string, object>()
                {
                    { "@generatedQrImageByte", GenerateAssetQRImageByte(QRDefinition)},
                    { "@qrDefinition", QRDefinition},
                    { "@assetId", qr_asset_gen_id}
                };

                databaseConnection.UploadToDatabase(query1, parameters1);

                databaseConnection.CloseConnection();

                //pictureBox1.Image = bitmap;

                //Generate Maintanence Logs ID based on the maintainable
                //Transfer History
                //Borrowed and Return History

                //QrShow Confirm Final


                */


            }

            //Confirmation
           
            using (AddAssetPanelConfirmation addAssetPanelConfirmation = new AddAssetPanelConfirmation(assetToAdd))
            {
                addAssetPanelConfirmation.ShowDialog();
                if (addAssetPanelConfirmation.GetResult() == DialogResult.OK)
                {
                    foreach (Asset asset in assetToAdd)
                    {
                        
                        string query = "INSERT INTO Assets (assetAdminID, currentCustodianAssetCoordID, supplierID, assetCategoryID, assetName," +
                        " assetCondition, assetLocation, assetIsArchive, assetAcknowledgeDate, assetPurchaseAmount," +
                        " assetQuantity, assetUnit, assetImage, assetIsMissing, assetIsMaintainable, assetPurpose, assetDescription, assetPropertyNumber) VALUES " +
                        " (@supervisorId, @employeeId, @supplierId, @categoryId, @name, @condition,  @location, @isarchive," +
                        " @purchasedate, @purchaseamount, @quantity, @unit, @image, @ismissing, @ismaintainable, @purpose, @description, @propertynumber)";

                        Dictionary<string, object> parameters = new Dictionary<string, object>()
                        {
                            { "@supervisorId",  asset.AssetSupervisorId },
                            { "@employeeId", asset.CurrentEmployeeId },
                            { "@supplierId",  asset.SupplierId },
                            { "@categoryId", asset.AssetCategoryId },
                            { "@name",  asset.AssetName },
                            { "@condition", asset.AssetCondition },
                           // { "@availability", asset.AssetAvailability },
                            { "@location", asset.AssetLocation },
                            { "@isarchive", asset.IsArchive },
                            { "@purchasedate", asset.AssetPurchaseDate },
                            { "@purchaseamount", asset.AssetPurchaseAmount },
                            { "@quantity", asset.AssetQuantity },
                            { "@unit", asset.AssetUnit },
                            { "@image", asset.AssetImage},
                            { "@ismissing", asset.IsMissing},
                            { "@ismaintainable", asset.IsMaintainable},
                            //{ "@lifeSpan", asset.AssetLifeSpan},
                            { "@purpose", asset.AssetPurpose},
                            { "@description", asset.AssetDescription},
                            { "@propertynumber", asset.AssetPropertyNumber}

                        };
                        int qr_asset_gen_id = databaseConnection.UploadToDatabaseAndGetId(query, parameters);

                        // POST-UPLOAD LOGIC
                        string QRDefinition = $"assetId:{qr_asset_gen_id};assetName:{asset.AssetName}";

                        // Other Attributes Post Update
                        asset.AssetId = qr_asset_gen_id;
                        asset.AssetQRCodeImage = GenerateAssetQRImageByte(QRDefinition);
                        asset.QRCode = QRDefinition;

                        string query1 = "UPDATE Assets SET assetQrCodeImage = @generatedQrImageByte, assetQrStrDefinition = @qrDefinition WHERE " +
                            "assetId = @assetId";

                        Dictionary<string, object> parameters1 = new Dictionary<string, object>()
                        {
                            { "@generatedQrImageByte", asset.AssetQRCodeImage},
                            { "@qrDefinition", asset.QRCode},
                            { "@assetId", qr_asset_gen_id}
                        };

                        databaseConnection.UploadToDatabase(query1, parameters1);

                        databaseConnection.CloseConnection();
                        
                    }


                    // Success Panel
                    SuccessPanel(assetToAdd);

                    addAssetPanelConfirmation.Close();
                }
                else if (addAssetPanelConfirmation.GetResult() == DialogResult.Cancel)
                {
                    addAssetPanelConfirmation.Close();
                }
            }

            
        }

        private void SuccessPanel(List<Asset> assetSuccessfulList)
        {
            using (AddAssetPanelSuccessfulQRShow addAssetPanelSuccessfulQRShow = new AddAssetPanelSuccessfulQRShow(assetSuccessfulList))
            {
                addAssetPanelSuccessfulQRShow.ShowDialog();
                if (addAssetPanelSuccessfulQRShow.GetResult() == DialogResult.OK)
                {

                    pHandler.Controls.Clear();
                    pHandler.SendToBack();
                    pHandler.Visible = false;

                    mainForm.LoadAssets();
                }
            }
        }

        private byte[] GenerateAssetQRImageByte(string QRDefinition)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions()
            {
                Width = 300,
                Height = 300,
                Margin = 1,
                PureBarcode = false
            };

            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(QRDefinition);

            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            Bitmap logo = null;
            if (mainForm != null)
            {

                Icon mainFormIcon = mainForm.Icon;
                logo = mainFormIcon.ToBitmap();

            }

            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));

            return Utilities.ConvertImageToBytes(bitmap);
        }

        private bool IsNullOrEmpty(Control control)
        {
            
            if (control == null)
            {
                return true;
            }

            if (control is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                return true;
            }
            else if (control is ComboBox comboBox && (comboBox.SelectedItem == null || comboBox.SelectedItem.ToString() == ""))
            {
                return true;
            }
            else if (control is DateTimePicker dateTimePicker && dateTimePicker.Value == DateTimePicker.MinimumDateTime)
            {
                return true;
            }
            else if (control is CheckBox checkBox && !checkBox.Checked)
            {
                return true;
            }

            return false;
        }

        private void MessagePrompt(string message)
        {
            DialogBoxes.MessagePromptDialogBox prompt = new DialogBoxes.MessagePromptDialogBox();
            prompt.SetMessage(message);
            prompt.Show();
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
