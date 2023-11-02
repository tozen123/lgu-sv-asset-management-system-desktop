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
    public partial class UploadImageDialogBox : Form
    {
        public byte[] imageByte { get; set; }
        Image prevImage;
        public UploadImageDialogBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            prevImage = pictureBoxImage.Image;
        }

        public DialogResult GetResult()
        {
            return this.DialogResult;
        }

        private void buttonUploadBrowse_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG Files (*.jpg; *.jpeg)|*.jpg;*.jpeg", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxImage.Image = Image.FromFile(ofd.FileName);
                    pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    labelDirectoryString.Text = ofd.FileName;
                }
            }
        }

        private void buttonUploadFinish_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if(prevImage == pictureBoxImage.Image)
            {
                imageByte = null;
            } 
            else
            {
                imageByte = Utilities.ConvertImageToBytes(pictureBoxImage.Image);
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
