using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    public class AssetCategory
    {
        public string AssetCategoryId { get; set; }
        public string AssetCategoryName { get; set; }
        public string AssetCategoryDescription { get; set; }
    }
    /*
     * 
     * 1. Attach other methods to the asset categories
     * 2. Add checker method for duplicates
     * 
     */
    public class AssetCategoryRepositoryControl
    {
        private DatabaseConnection databaseConnection;

        public AssetCategoryRepositoryControl()
        {
            databaseConnection = new DatabaseConnection();
        }

        public (bool Success, string ErrorMessage) AddToDatabase(AssetCategory assetCategory)
        {
            try
            {
                string query = "INSERT INTO AssetCategory (assetCategoryName, assetCategoryDescription) VALUES (@assetCategoryName, @assetCategoryDescription)";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@assetCategoryName", assetCategory.AssetCategoryName },
                    {"@assetCategoryDescription", assetCategory.AssetCategoryDescription}
                };

                databaseConnection.UploadToDatabase(query, parameters);

                databaseConnection.CloseConnection();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            
        }

        public (bool Success, string ErrorMessage) DeleteToDatabase(AssetCategory assetCategory)
        {
            try
            {
                string query = "DELETE From AssetCategory WHERE assetCategoryId = @assetCategoryId";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@assetCategoryId", assetCategory.AssetCategoryId}
                };

                databaseConnection.ReadFromDatabase(query, parameters);

                databaseConnection.CloseConnection();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool Success, string ErrorMessage) UpdateToDatabase(AssetCategory assetCategory)
        {
            try
            {
                string query = "UPDATE AssetCategory " +
                    "SET assetCategoryName = @assetCategoryName, " +
                    "assetCategoryDescription = @assetCategoryDescription " +
                    "WHERE supplierId = @supId";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@assetCategoryName", assetCategory.AssetCategoryName},
                    {"@assetCategoryDescription", assetCategory.AssetCategoryDescription}
                };

                databaseConnection.ReadFromDatabase(query, parameters);

                databaseConnection.CloseConnection();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

    }
}
