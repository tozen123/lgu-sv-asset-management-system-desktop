using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{
    public partial class RecordsHomePanel : UserControl
    {
        private DatabaseConnection databaseConnection;
        string userLocation;
        public RecordsHomePanel(string _userLocation)
        {
            databaseConnection = new DatabaseConnection();

            InitializeComponent();
            userLocation = _userLocation;

            InitializeRecords();
           
        }


        private DataTable FetchDataFromDB()
        {
            string query = "SELECT A.assetId, " +
                   "       CONCAT(ASupervisor.assetSupervisorFName, ' ', ASupervisor.assetSupervisorMName, ' ', ASupervisor.assetSupervisorLName) AS assetSupervisorFullName, " +
                   "       CONCAT(AEmployee.AssetEmployeeFName, ' ', AEmployee.AssetEmployeeMName, ' ', AEmployee.AssetEmployeeLName) AS currentAssetEmployeeFullName, " +
                   "       Supplier.supplierName, " +
                   "       ACategory.assetCategoryName, " +
                   "       A.assetName, A.assetCondition, A.assetAvailability, " +
                   "       A.assetQrCodeImage, A.assetLocation, A.assetPurchaseDate, A.assetPurchaseAmount, " +
                   "       A.assetQuantity, A.assetUnit, A.assetIsMaintainable, A.assetLifeSpan " +
                   "FROM Assets A " +
                   "LEFT JOIN AssetSupervisor ASupervisor ON A.assetSupervisorID = ASupervisor.assetSupervisorID " +
                   "LEFT JOIN AssetEmployee AEmployee ON A.currentAssetEmployeeID = AEmployee.assetEmployeeID " +
                   "LEFT JOIN Supplier ON A.supplierID = Supplier.supplierID " +
                   "LEFT JOIN AssetCategory ACategory ON A.assetCategoryID = ACategory.assetCategoryID " +
                   "WHERE A.assetLocation = @uLocation";


            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@uLocation", userLocation}
            };

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }

        private void InitializeRecords()
        {
            dataGridViewAssetRecords.DataSource = FetchDataFromDB();

  
            dataGridViewAssetRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
           
         
           
        }

      
    }
}
