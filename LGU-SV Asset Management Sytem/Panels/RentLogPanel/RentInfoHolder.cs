using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.RentLogPanel
{
    public partial class RentInfoHolder : UserControl
    {
        public RentInfoHolder()
        {
            InitializeComponent();
        }
        public void SetTitle(string i)
        {
            labelTitle.Text = i;
        }
        public void SetDate(string i)
        {
            labelDate.Text = i;
        }
        public void SetAction(string i)
        {
            labelAction.Text = i;
        }
    }
}
