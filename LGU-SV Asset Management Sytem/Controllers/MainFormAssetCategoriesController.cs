using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LGU_SV_Asset_Management_Sytem.Controllers
{
    class MainFormAssetCategoriesController
    {
        private DatabaseConnection databaseConnection;
        public MainFormAssetCategoriesController(DatabaseConnection _dbc)
        {
            databaseConnection = _dbc;
        }
        public DataTable GetAllAssetCategories()
        {
            string query = "SELECT assetCategoryId, assetCategoryName, assetCategoryDescription FROM AssetCategory";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();

            return resultTable;
        }

        
    }
}
