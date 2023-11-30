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
        private string current_user_password;
  
        private bool isActive;

        public SessionHandler(string user_id, string password)
        {
            current_user_id = user_id;
            current_user_password = password;
           
            isActive = true;
        }

       
        public string GetCurrentUserPassword()
        {
            return current_user_password;
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
                        return "Asset Coordinator";
                case "03":
                        return "Asset Administrator";
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
                case "Asset Coordinator":
                    query = "SELECT FName, LName FROM AssetCoordinator WHERE userId = @userId";
                    break;
                case "Asset Administrator":
                    query = "SELECT FName, LName FROM AssetAdministrator WHERE userId = @userId";
                    break;
                default:
                    return "Null";
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userId", GetCurrentUserID());
            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);
  
            return $"{resultTable.Rows[0][0]} {resultTable.Rows[0][1]}";
        }


        public void OnCurrentSessionSafeChangePassword(string newpassword)
        {
            current_user_password = newpassword;
        }

        public void OnCurrentSessionEnd()
        {
            current_user_id = null;
            current_user_password = null;

            isActive = false;
        }

        public bool isCurrentSessionActive()
        {
            return isActive;
        }
    }
}
