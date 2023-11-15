using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    public class AssetBehaviour
    {
        private DatabaseConnection databaseConnection;

        public AssetBehaviour()
        {
            databaseConnection = new DatabaseConnection();
        }

        public void UploadToDatabase(string query, Dictionary<string, object> parameters)
        {
            databaseConnection.UploadToDatabase(query, parameters);
        }
    }
}
