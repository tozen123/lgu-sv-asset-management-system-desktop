using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LGU_SV_Asset_Management_Sytem.AssetMaintenanceLog;

namespace LGU_SV_Asset_Management_Sytem.Panels.MaintenancePanel
{
    public partial class AddNewMaintenanceLogPanel : UserControl
    {
        Asset asset;
        Panel parentPanel;
        User currentUser;

        AssetMaintenanceLogRepositoryControl assetMaintenanceLogRepositoryControl = new AssetMaintenanceLogRepositoryControl();

        AssetMaintenanceLogPanel parentLogPanel;
        public AddNewMaintenanceLogPanel(Panel _parentPanel, Asset _asset, User _currentUser, AssetMaintenanceLogPanel _parentLogPanel)
        {
            InitializeComponent();

            asset = _asset;
            parentPanel = _parentPanel;

            currentUser = _currentUser;
            parentLogPanel = _parentLogPanel;
        }


        private void AddNewMaintenanceLogPanel_Load(object sender, EventArgs e)
        {

        }

        private void Close()
        {
            parentPanel.Controls.Clear();
            parentPanel.SendToBack();
            parentPanel.Visible = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AssetMaintenanceLog assetMaintenanceLog = new AssetMaintenanceLog();

           
            if (dateTimePickerMaintenanceDate.Value > DateTime.Now)
            {
                MessagePrompt("Maintenance Date cannot be in the future.");
                return; 
            }

            assetMaintenanceLog.MaintenanceDate = dateTimePickerMaintenanceDate.Value;


            if (!int.TryParse(textBoxCost.Text, out int maintenanceCost) || maintenanceCost < 0)
            {
                MessagePrompt("Invalid Maintenance Cost. Please enter a valid positive integer.");
                return; 
            }
            assetMaintenanceLog.MaintenanceCost = maintenanceCost;

      
            if (comboBoxCategory.SelectedItem == null)
            {
                MessagePrompt("Please select a Maintenance Category.");
                return; 
            }

            assetMaintenanceLog.MaintenanceCategory = comboBoxCategory.SelectedItem.ToString();

            if (comboBoxStatus.SelectedItem == null)
            {
                MessagePrompt("Please select a Maintenance Status.");
                return; 
            }
            assetMaintenanceLog.MaintenanceStatus = comboBoxStatus.SelectedItem.ToString();

            assetMaintenanceLog.MaintenanceDescription = richTextBoxDescription.Text;

            assetMaintenanceLog.AssetId = asset.AssetId;
            assetMaintenanceLog.AssetEmployeeId = currentUser.UserRoleBasedID;

            var result = assetMaintenanceLogRepositoryControl.AddToDatabase(assetMaintenanceLog);
            if (result.Success)
            {
                MessagePrompt("Maintenance log added successfully!");
                parentLogPanel.InitializeRecords();

                Close();
            }
            else
            {
                MessagePrompt($"{ErrorList.Error5()[0] + " | " + ErrorList.Error5()[1]}{result.ErrorMessage}");
            }
            
        }

        private void MessagePrompt(string message)
        {
            DialogBoxes.MessagePromptDialogBox prompt = new DialogBoxes.MessagePromptDialogBox();
            prompt.SetMessage(message);
            prompt.Show();
        }

    }
}
