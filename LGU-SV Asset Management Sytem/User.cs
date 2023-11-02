using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
  
    class User
    {
        private DatabaseConnection databaseConnection;

        public User()
        {
            databaseConnection = new DatabaseConnection();
        }

        public enum AccessLevel
        {
            Operator,
            Manager,
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

        public void UploadToDatabase(string query, Dictionary<string, object> parameters)
        {
            databaseConnection.UploadToDatabase(query, parameters);
        }
    }
}
