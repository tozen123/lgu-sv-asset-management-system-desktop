using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
    public partial class ConfirmationPrompt : Form
    {
        public ConfirmationPrompt()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
           
        }

        public DialogResult GetResult()
        {
            return this.DialogResult;
        }
           
        public void SetData (Asset asset)
        {
            textBoxId.Text = asset.AssetId.ToString();
            textBoxName.Text = asset.AssetName;
            textBoxQuantity.Text = asset.AssetQuantity.ToString();
            textBoxLocation.Text = asset.AssetLocation;
            textBoxPAmount.Text = asset.AssetPurchaseAmount.ToString();
            textBoxPDate.Text = asset.AssetPurchaseDate.ToString();
               /*
            if (asset.AssetLastMaintenanceID.ToString() == "0")
            {
                textBoxLMaintenance.Text = "N/A";
            }
            else
            {
                textBoxLMaintenance.Text = asset.AssetLastMaintenanceID.ToString();
            }
               */
            textBoxUnit.Text = asset.AssetUnit;
            textBoxCondition.Text = asset.AssetCondition;
           // textBoxAvailability.Text = asset.AssetAvailability;
            //textBoxLifeSpan.Text = asset.AssetLifeSpan.ToString();




            //TextBoxes 2
            textBoxEmployee.Text = asset.EmployeeName;
            textBoxAssetCategory.Text = asset.AssetCategoryName;
            textBoxSupplier.Text = asset.SupplierName;
        }

        public void SetConfirmationTitle(string title)
        {
            labelConfirmationTitle.Text = title;
        }
        public void SetConfirmationMessage(string message)
        {
            labelConfirmationMessage.Text = message;
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonClose_Click_1(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonConfirm_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void labelConfirmationMessage_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ConfirmationPrompt_Load(object sender, EventArgs e)
        {

        }
    }

    
}
