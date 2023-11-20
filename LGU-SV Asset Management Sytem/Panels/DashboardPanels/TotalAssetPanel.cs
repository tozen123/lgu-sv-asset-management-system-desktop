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

        string office;
        public TotalAssetPanel(string _office)
        {
            InitializeComponent();
            databaseConnection = new DatabaseConnection();
            office = _office;
            CountAssets();
        }

        private void CountAssets()
        {
            string query = "SELECT COUNT(*) FROM Assets WHERE assetLocation = @loc";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@loc", office}
            };

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
