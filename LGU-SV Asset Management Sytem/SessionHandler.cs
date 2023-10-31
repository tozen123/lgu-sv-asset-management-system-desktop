using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{

    // This class facilitates the session of the system
    // After the user logins, this class is created in the system.

    
    class SessionHandler
    {
        private string current_user_id;

        public SessionHandler(string user_id)
        {
            current_user_id = user_id;
        }

        public string GetCurrentUserID()
        {
            return current_user_id;
        }

        public string GetTypeUser()
        {
            string code = GetCurrentUserID().Split('-')[0];
            switch (code)
            {
                case "01":
                        return "Asset Viewer";
                case "02":
                        return "Asset Operator";
                case "03":
                        return "Asset Manager";
                default:
                    return "Null";

            }
        }

        public string GetUserName(DatabaseConnection databaseConnection)
        {
            string query;
            switch (GetTypeUser())
            {
                case "Asset Viewer":
                    query = "SELECT assetViewerFName, assetViewerLName FROM AssetViewer WHERE userId = @userId";
                    break;
                case "Asset Operator":
                    query = "SELECT assetOperatorFName, assetOperatorLName FROM AssetOperator WHERE userId = @userId";
                    break;
                case "Asset Manager":
                    query = "SELECT assetManagerFname, assetManagerLName FROM AssetManager WHERE userId = @userId";
                    break;
                default:
                    return "Null";
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userId", GetCurrentUserID());
            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);
  
            return $"{resultTable.Rows[0][0]} {resultTable.Rows[0][1]}";
        }
    }
}
