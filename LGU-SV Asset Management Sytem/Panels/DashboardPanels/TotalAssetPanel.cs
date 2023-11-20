using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.DashboardPanels
{
    public partial class TotalAssetPanel : UserControl
    {

        private DatabaseConnection databaseConnection;

        public TotalAssetPanel()
        {
            InitializeComponent();
            databaseConnection = new DatabaseConnection();

            CountAssets();
        }

        private void CountAssets()
        {
            string query = "SELECT COUNT(*) FROM Assets";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            string count = "";
            foreach (DataRow row in resultTable.Rows)
            {
                foreach (DataColumn col in resultTable.Columns)
                {
                    count = row[col].ToString(); 
                }
            }
            labelCountAsset.Text = count;
        }
    }
}
