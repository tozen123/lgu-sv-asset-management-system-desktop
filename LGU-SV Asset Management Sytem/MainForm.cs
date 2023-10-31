using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem
{
    public partial class MainForm : Form
    {
        // Reference for SessionHandler
        private SessionHandler sessionHandler;
        public MainForm()
        {
            InitializeComponent();
        }

        public void SetSessionHandler(string user_id)
        {
            sessionHandler = new SessionHandler(user_id);
            Console.WriteLine(sessionHandler.GetCurrentUserID());
        }
    }
}
