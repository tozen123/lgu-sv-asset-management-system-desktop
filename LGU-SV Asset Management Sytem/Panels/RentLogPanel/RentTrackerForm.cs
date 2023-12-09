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
    public partial class RentTrackerForm : Form
    {

        int rentId;
        int assetId;
        int origQuantity;
        int returnedTotal;
        private DatabaseConnection databaseConnection;

        AssetRepositoryControl assetRepositoryControl;
        public RentTrackerForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;

            databaseConnection = new DatabaseConnection();
            assetRepositoryControl = new AssetRepositoryControl();
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

       

            string post_query = "UPDATE RentLog SET rentStatus = 'Missing' WHERE rentId = @assetId";

            Dictionary<string, object> post_parameters = new Dictionary<string, object>()
                {
                    {"@assetId", rentId}
                };

            databaseConnection.ReadFromDatabase(post_query, post_parameters);

            databaseConnection.CloseConnection();

            Initialize();
            this.Close();
        }

        private void buttonReturned_Click(object sender, EventArgs e)
        {


            string post_query = $"UPDATE RentLog SET rentReturnDate = '{DateTime.Now}', rentStatus = 'Returned' WHERE rentId = @assetId";

            Dictionary<string, object> post_parameters = new Dictionary<string, object>()
                {
                    {"@assetId", rentId}
                };

            databaseConnection.ReadFromDatabase(post_query, post_parameters);

            databaseConnection.CloseConnection();

            Initialize();
            this.Close();
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
                                rentReturnDate,
                                rentOriginQuantity
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
                origQuantity = Convert.ToInt32( row["rentOriginQuantity"].ToString());

                if (string.IsNullOrEmpty(textBoxRDate.Text))
                {
 
                    textBoxRDate.Text = "-";
                }

                if (textBoxStatus.Text.Equals("Returned") || textBoxStatus.Text.Equals("Missing"))
                {
                    buttonMssing.Enabled = false;
                    buttonReturned.Enabled = false;
                    buttonIncompleteReturned.Enabled = false;
                } 
                else
                {
                    buttonMssing.Enabled = true;
                    buttonReturned.Enabled = true;
                    buttonIncompleteReturned.Enabled = true;
                }
                groupBoxInfo.Visible = false;
            }

            if(textBoxStatus.Text.Equals("Incomplete Returned"))
            {
                buttonMssing.Enabled = false;
                buttonReturned.Enabled = false;
                buttonIncompleteReturned.Enabled = false;
                groupBoxInfo.Visible = true;

                textBoxTotalQuant.Text = origQuantity.ToString();


                Asset n = assetRepositoryControl.RetrieveAsset(assetId).retrievedAsset;
                returnedTotal = n.AssetQuantity;
                textBoxReturned.Text = returnedTotal.ToString();

                textBoxMissing.Text = (origQuantity - returnedTotal).ToString();
            }
            databaseConnection.CloseConnection();

        }

        private void buttonIncompleteReturned_Click(object sender, EventArgs e)
        {
            using (DeclaredMissingQuantity declaredMissingQuantityForm = new DeclaredMissingQuantity())
            {
                Asset asset = assetRepositoryControl.RetrieveAsset(assetId).retrievedAsset;

                declaredMissingQuantityForm.SetAssetToDeclared(assetId);

                if (textBoxStatus.Text.Equals("Incomplete Returned"))
                {
                    declaredMissingQuantityForm.SetReturned(asset.AssetQuantity);
                }
                else
                {
                    declaredMissingQuantityForm.SetReturned(0);

                }
                declaredMissingQuantityForm.SetOriginalQuantity(origQuantity);
                


                declaredMissingQuantityForm.SetData();
                declaredMissingQuantityForm.ShowDialog();
                int returned, total;
                if(declaredMissingQuantityForm.GetDialogResult() == DialogResult.OK)
                {
                    returned = declaredMissingQuantityForm.GetReturnedQuantityTotal();
                    total = declaredMissingQuantityForm.GetQuantityTotal();

                    
                    if(asset.AssetQuantity == 0)
                    {

                        string query = "UPDATE Assets SET assetIsMissing = 1 WHERE assetId = @assetId";

                        Dictionary<string, object> parameters = new Dictionary<string, object>()
                        {
                            {"@assetId", assetId}
                        };

                        databaseConnection.ReadFromDatabase(query, parameters);



                        string post_query1 = "UPDATE RentLog SET rentStatus = 'Missing' WHERE rentId = @assetId";

                        Dictionary<string, object> post_parameters1 = new Dictionary<string, object>()
                        {
                             {"@assetId", rentId}
                        };

                        databaseConnection.ReadFromDatabase(post_query1, post_parameters1);

                        databaseConnection.CloseConnection();

                        Initialize();
                        this.Close();
                        return;
                    }

                    if(asset != null)
                    {
                        asset.AssetQuantity = returned;

                        assetRepositoryControl.UpdateQuantity(asset);
                    }


                    string post_query = $"UPDATE RentLog SET rentStatus = 'Incomplete Returned' WHERE rentId = @assetId";

                    Dictionary<string, object> post_parameters = new Dictionary<string, object>()
                    {
                        {"@assetId", rentId}
                    };

                    databaseConnection.ReadFromDatabase(post_query, post_parameters);

                    databaseConnection.CloseConnection();

                   

                 
                }
                else if(declaredMissingQuantityForm.GetDialogResult() == DialogResult.Cancel)
                {
                    declaredMissingQuantityForm.Close();
                }

                
            }

            Initialize();
            this.Close();
        }
    }
}
