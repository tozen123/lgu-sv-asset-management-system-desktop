using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
     
    public class AssetLoader
    {
        private DatabaseConnection databaseConnection;

        public AssetLoader()
        {
            databaseConnection = new DatabaseConnection();

            LoadAsset();
        }

        public void LoadAsset()
        {
            // Fetch All Asset

            string query = "SELECT A.assetId, " +
                           "       A.assetPropertyNumber, A.assetName, " +
                           "       CONCAT(AAdmin.FName, ' ', AAdmin.MName, ' ', AAdmin.LName, '; ', AAdmin.Id) AS AAdminFullName, " +
                           "       CONCAT(ACoor.FName, ' ', ACoor.MName, ' ', ACoor.LName, '; ', ACoor.Id) AS currentCustodianCoordinatorFullName, " +
                           "       CONCAT(Supplier.supplierName, '; ',  Supplier.supplierID) AS Supplier, " +
                           "       CONCAT(ACategory.assetCategoryName, '; ', ACategory.assetCategoryID) AS AssetCategory, " +
                           "       A.assetQrCodeImage, A.assetQrStrDefinition, A.assetLocation, A.assetAcknowledgeDate, A.assetPurchaseAmount, " +
                           "       A.assetQuantity, A.assetUnit, A.assetImage, A.assetIsArchive, A.assetIsMaintainable," +
                           "       A.assetIsMissing, A.assetPurpose, A.assetDescription, A.assetCondition " +
                           "FROM Assets A " +
                           "LEFT JOIN AssetAdministrator AAdmin ON  A.assetAdminID = AAdmin.Id  " +
                           "LEFT JOIN AssetCoordinator ACoor ON A.currentCustodianAssetCoordID = ACoor.Id " +
                           "LEFT JOIN Supplier ON A.supplierID = Supplier.supplierID " +
                           "LEFT JOIN AssetCategory ACategory ON A.assetCategoryID = ACategory.assetCategoryID";



            Dictionary<string, object> parameters = new Dictionary<string, object>();

        }
    }
}
