using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LGU_SV_Asset_Management_Sytem.Asset;

namespace LGU_SV_Asset_Management_Sytem.Panels.RentLogPanel
{
    public partial class DeclaredMissingQuantity : Form
    {
        int quantityReturned;
        int quantityTotal;
        int quantityTotalReturned;
        Asset assetToReturned;

        AssetRepositoryControl assetRepositoryControl;

        public DeclaredMissingQuantity()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            assetRepositoryControl = new AssetRepositoryControl();

            
        }
        public void SetData()
        {
            textBoxTotalQuantity.Text = quantityTotal.ToString();
            textBoxQuantityTotalReturned.Text = quantityTotalReturned.ToString();
        }
        public void SetReturned(int i)
        {
            quantityTotalReturned = i;
        }
        public void SetOriginalQuantity(int i)
        {
            quantityTotal = i;
        }
        public int GetReturnedQuantityTotal()
        {
            return quantityReturned;
        }
        public int GetQuantityTotal()
        {
            return quantityTotal;
        }
        
        public void SetAssetToDeclared(int assetId)
        {
            assetToReturned = assetRepositoryControl.RetrieveAsset(assetId).retrievedAsset;
        }

        public DialogResult GetDialogResult()
        {
            return this.DialogResult;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
           
            int i;

            if (string.IsNullOrEmpty(textBoxQuantityReturned.Text))
            {
                MessagePrompt("Please input something.");
                return;
            }

            if(int.TryParse(textBoxQuantityReturned.Text, out i))
            {
                if(i > quantityTotal)
                {
                    MessagePrompt("Incorrect Input. You have put a quantity that is greater than the asset total quantity.");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                else if (i == 0)
                {
                    MessagePrompt("Incorrect Input. There is should be an quantity. Since you are trying to set the asset as incompletely returned.");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }

                this.DialogResult = DialogResult.OK;
                quantityReturned = i;



                this.Close();
            }
            
        }

        private void textBoxTotalQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxQuantityReturned_TextChanged(object sender, EventArgs e)
        {

        }
        private void MessagePrompt(string message)
        {
            DialogBoxes.MessagePromptDialogBox prompt = new DialogBoxes.MessagePromptDialogBox();
            prompt.SetMessage(message);
            prompt.ShowDialog();
        }
    }
}
