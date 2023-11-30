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
    public partial class DialogImageViewer : Form
    {

        public DialogImageViewer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public void SetImage(Image img)
        {
            pictureBoxDocImage.Image = img;

        }

        private void rbuttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
