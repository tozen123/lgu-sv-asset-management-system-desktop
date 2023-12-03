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
    public partial class RentTrackerForm : Form
    {

        int rentId;
        int assetId;
        private DatabaseConnection databaseConnection;
        public RentTrackerForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;

            databaseConnection = new DatabaseConnection();
        }

        public void Initialize()
        {
            CheckedRent();
        }

        public void SetRentID(int id)
        {
            rentId = id;
        }
        public void SetAssetID(int id)
        {
            assetId = id;
        }
        
        private void buttonMssing_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Assets SET assetIsMissing = 1 WHERE assetId = @assetId";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@assetId", assetId}
                };

            databaseConnection.ReadFromDatabase(query, parameters);

       

            string post_query = "UPDATE RentLog SET rentStatus = 'Missing' WHERE assetId = @assetId";

            Dictionary<string, object> post_parameters = new Dictionary<string, object>()
                {
                    {"@assetId", assetId}
                };

            databaseConnection.ReadFromDatabase(post_query, post_parameters);

            databaseConnection.CloseConnection();

            Initialize();
        }

        private void buttonReturned_Click(object sender, EventArgs e)
        {
           


            string post_query = $"UPDATE RentLog SET rentReturnDate = '{DateTime.Now}', rentStatus = 'Returned' WHERE assetId = @assetId";

            Dictionary<string, object> post_parameters = new Dictionary<string, object>()
                {
                    {"@assetId", assetId}
                };

            databaseConnection.ReadFromDatabase(post_query, post_parameters);

            databaseConnection.CloseConnection();

            Initialize();
        }

        private void CheckedRent()
        {
            string query = @"
                            SELECT
                                rentId,
                                assetId,
                                renteeFirstName,
                                renteeMidName,
                                renteeLastName,
                                renteeAddress,
                                renteeBirthdate,
                                renteeContactNumber,
                                renteeLicenseNumber,
                                renteeValidIDImage,
                                rentInitiatedDate,
                                rentStatus,
                                rentReturnDate
                            FROM
                                [LGU_AMS_DB].[dbo].[RentLog]
                            WHERE
                                rentId = @rentId;
                            ";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                    {"@rentId", rentId}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            if (resultTable.Rows.Count > 0)
            {
                DataRow row = resultTable.Rows[0];

                textBoxStartDate.Text = row["rentInitiatedDate"].ToString();
               
                textBoxRDate.Text = row["rentReturnDate"].ToString();
                textBoxStatus.Text = row["rentStatus"].ToString();
                if (string.IsNullOrEmpty(textBoxRDate.Text))
                {
 
                    textBoxRDate.Text = "-";
                }

                if (textBoxStatus.Text.Equals("Returned") || textBoxStatus.Text.Equals("Missing"))
                {
                    buttonMssing.Enabled = false;
                    buttonReturned.Enabled = false;
                } 
                else
                {
                    buttonMssing.Enabled = true;
                    buttonReturned.Enabled = true;
                }
            }


                databaseConnection.CloseConnection();

        }
    }
}
