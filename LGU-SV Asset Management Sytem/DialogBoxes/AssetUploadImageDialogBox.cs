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
    public partial class AssetUploadImageDialogBox : Form
    {
        public byte[] imageByte { get; set; }
        public AssetUploadImageDialogBox()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public DialogResult GetResult()
        {
            return this.DialogResult;
        }

        private void buttonBrowseImage_Click(object sender, EventArgs e)
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            imageByte = Utilities.ConvertImageToBytes(pictureBoxImage.Image);
        }
    }
}
