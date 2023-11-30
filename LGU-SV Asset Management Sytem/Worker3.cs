using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem
{
    public class Worker3
    {
        private MainForm mainform;
        public Worker3(MainForm form)
        {
            this.mainform = form;
            InitializeAbout();
        }

        public void InitializeAbout()
        {
            mainform.richTextBoxAboutHeader.ReadOnly = false;
            mainform.richTextBoxAboutHeader.Clear();
            mainform.richTextBoxAboutHeader.SelectionAlignment = HorizontalAlignment.Center;
            mainform.richTextBoxAboutHeader.AppendText(
                "LGU - San Vicente " +
                "\nAsset Management System");
            mainform.richTextBoxAboutHeader.ReadOnly = true;
            
        }
    }
}
