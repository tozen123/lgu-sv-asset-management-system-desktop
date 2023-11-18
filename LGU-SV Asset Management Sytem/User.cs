using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
  
    public class User
    {
        private DatabaseConnection databaseConnection;

        public User()
        {
            databaseConnection = new DatabaseConnection();
        }

        public enum AccessLevel
        {
            Employee,
            Supervisor,
            Viewer
        }

        public AccessLevel Role;

        public virtual AccessLevel SetAccessLevel(AccessLevel role)
        {
            return Role = role;
        }

        public virtual AccessLevel GetAccessLevel()
        {
            if(Role == 0)
            {
                Console.WriteLine("Error Occured No Set Level");
                return 0;
            }
            Console.WriteLine("User is "+Role);
            return Role;
        }

        public virtual string GetStringAccessLevel()
        {
            switch (Role)
            {
                case AccessLevel.Viewer:
                    return "Asset Viewer";

                case AccessLevel.Supervisor:
                    return "Asset Supervisor";
 
                case AccessLevel.Employee:
                    return "Asset Employee";
                default:
                    return "NULL_DATA_USER";
            }
            
        }
        public void UploadToDatabase(string query, Dictionary<string, object> parameters)
        {
            databaseConnection.UploadToDatabase(query, parameters);
        }
    }
}
