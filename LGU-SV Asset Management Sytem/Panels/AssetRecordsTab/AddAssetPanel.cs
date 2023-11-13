using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{

    public partial class AddAssetPanel : UserControl
    {
        List<Asset> assetToAdd = new List<Asset>();

        private DatabaseConnection databaseConnection;

        private List<PictureBox> pictureBoxList = new List<PictureBox>();

        string supervisor_id;

        public enum AssetType
        {
            New,
            Existing
        }

        public AssetType assetType;

        public AddAssetPanel(AssetType _assetType, string id)
        {
            InitializeComponent();
            supervisor_id = id;

            assetType = _assetType;
            databaseConnection = new DatabaseConnection();

            Init();

            Asset newAsset = new Asset();
            assetToAdd.Add(newAsset);

          
        }
        private void Init()
        {
            switch (assetType)
            {
                case AssetType.New:
                    buttonAdd.Text = "Add New Asset";

                    break;
                case AssetType.Existing:
                    buttonAdd.Text = "Add Existing Asset";

                    break;
            }

            pictureBoxList.Add(pictureBoxAssetImage);

            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            comboBoxAvailability.Items.Add("USED");
            comboBoxAvailability.Items.Add("AVAILABLE");

            comboBoxCondition.Items.Add("WORKING");
            comboBoxCondition.Items.Add("INOPERABLE");

            comboBoxLocation.Items.Add("GSO-General Services Office");
            comboBoxLocation.Items.Add("MHO-Municipal Health Office");
            comboBoxLocation.Items.Add("MCR-Municipal Civil Registrar");
            comboBoxLocation.Items.Add("MEO-Municipal Engineering Office");
            comboBoxLocation.Items.Add("MBO-Municipal Budget Office");
            comboBoxLocation.Items.Add("Accounting Office");

            comboBoxUnit.Items.Add("SET");
            comboBoxUnit.Items.Add("SINGLE");


            string query = "SELECT  assetEmployeeId, assetEmployeeFName, assetEmployeeMName, assetEmployeeLName FROM AssetEmployee";
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

            // Conditional for handling controls
            if (control is Label)
            {
               
                ((Label)newControl).Text = ((Label)control).Text;
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
                ComboBox ComboBox_Location = tabPage.Controls.Find("comboBoxLocation", true).FirstOrDefault() as ComboBox;
                ComboBox ComboBox_Availability = tabPage.Controls.Find("comboBoxAvailability", true).FirstOrDefault() as ComboBox;
                ComboBox ComboBox_Condition = tabPage.Controls.Find("comboBoxCondition", true).FirstOrDefault() as ComboBox;

                ComboBox ComboBox_Employee = tabPage.Controls.Find("comboBoxEmployee", true).FirstOrDefault() as ComboBox;
                ComboBox ComboBox_Supplier = tabPage.Controls.Find("comboBoxSupplier", true).FirstOrDefault() as ComboBox;

                // DateTime
                DateTimePicker DateTimePicker_purchaseDate = tabPage.Controls.Find("dateTimePickerPurchase", true).FirstOrDefault() as DateTimePicker;

                // Checkbox
                CheckBox CheckBox_isMaintainable = tabPage.Controls.Find("checkBoxIsMaintanable", true).FirstOrDefault() as CheckBox;

                // Image
                PictureBox PictureBox_assetImage = tabPage.Controls.Find("pictureBoxAssetImage", true).FirstOrDefault() as PictureBox;

                // QR Generator

                //Validate
                if (IsNullOrEmpty(TextBox_AssetName) || IsNullOrEmpty(TextBox_Quantity) ||
                    IsNullOrEmpty(TextBox_PurchaseAmount) || IsNullOrEmpty(TextBox_LifeSpan) ||
                    IsNullOrEmpty(ComboBox_Category) || IsNullOrEmpty(ComboBox_Unit) ||
                    IsNullOrEmpty(ComboBox_Location) || IsNullOrEmpty(ComboBox_Availability) ||
                    IsNullOrEmpty(ComboBox_Condition) || IsNullOrEmpty(ComboBox_Employee) ||
                    IsNullOrEmpty(ComboBox_Supplier) || IsNullOrEmpty(DateTimePicker_purchaseDate) ||
                    IsNullOrEmpty(CheckBox_isMaintainable) || IsNullOrEmpty(PictureBox_assetImage))
                {
                    MessagePrompt("HEYYYYYY ! Empty field found!");
                }
                else
                {
              
                    asset.AssetName = TextBox_AssetName.Text;
                    asset.AssetQuantity = Convert.ToInt32(TextBox_Quantity.Text);
                    asset.AssetPurchaseAmount = Convert.ToDecimal(TextBox_PurchaseAmount.Text);


                    //Supervisor
                    if (int.TryParse(supervisor_id, out int parsedSupervisorId))
                    {
                        asset.AssetSupervisorId = parsedSupervisorId;
                    }

                    //Employee
                    
                    if (int.TryParse(ComboBox_Employee.SelectedItem.ToString().Split(' ')[2], out int empId))
                    {
                        asset.CurrentEmployeeId = empId;
                    }


                    ////Supplier
                    
                    if (int.TryParse(ComboBox_Supplier.SelectedItem.ToString().Split(' ')[2], out int supId))
                    {
                        asset.SupplierId = supId;
                    }


                    asset.AssetUnit = ComboBox_Unit.SelectedItem?.ToString();
                    asset.AssetLocation = ComboBox_Location.SelectedItem?.ToString();
                   
                    asset.AssetPurchaseDate = DateTimePicker_purchaseDate.Value;

                  
                    asset.IsMaintainable = CheckBox_isMaintainable.Checked;

                  
                    asset.AssetImage = Utilities.ConvertImageToBytes(PictureBox_assetImage.Image);

                    /*
                     * 
                     * MAIN PROGRESS HERE
                     * 
                     */

                    //Gen QR
                    //Gen QR Image
                    //Generate Maintanence Logs ID based on the maintainable
                    //Transfer History
                    //Borrowed and Return History
                    //CategoryID

                    //Change Asset Location, base it on the current supervisor location
                }

            }

            foreach (Asset asset in assetToAdd)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"Asset Supervisor ID: {asset.AssetSupervisorId}");
                Console.WriteLine($"Current Employee ID: {asset.CurrentEmployeeId}");
                Console.WriteLine($"Supplier ID: {asset.SupplierId}");
                Console.WriteLine($"Asset Category ID: {asset.AssetCategoryId}");
                Console.WriteLine($"Asset Last Maintenance ID: {asset.AssetLastMaintenanceID}");
                Console.WriteLine($"Asset Name: {asset.AssetName}");
                Console.WriteLine($"Asset Location: {asset.AssetLocation}");
                Console.WriteLine($"QR Code: {asset.QRCode}");
                Console.WriteLine($"QR Code Image: ");
                Console.WriteLine($"Asset Image: {asset.AssetImage}");
                Console.WriteLine($"Asset Availability: {asset.AssetAvailability}");
                Console.WriteLine($"Asset Condition: {asset.AssetCondition}");
                Console.WriteLine($"Is Archive: {asset.IsArchive}");
                Console.WriteLine($"Is Missing: {asset.IsMissing}");
                Console.WriteLine($"Asset Purchase Amount: {asset.AssetPurchaseAmount}");
                Console.WriteLine($"Asset Purchase Date: {asset.AssetPurchaseDate}");
                Console.WriteLine($"Asset Maintenance Logs ID: {asset.AssetMaintenanceLogsID}");
                Console.WriteLine($"Asset Quantity: {asset.AssetQuantity}");
                Console.WriteLine($"Asset Unit: {asset.AssetUnit}");
                Console.WriteLine($"Is Maintainable: {asset.IsMaintainable}");
                Console.WriteLine("------------------------------------------");
            }
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

      
    }
}
