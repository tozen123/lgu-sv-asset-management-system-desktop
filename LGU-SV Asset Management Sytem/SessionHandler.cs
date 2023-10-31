using System;
using System.Collections.Generic;
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
    }
}
