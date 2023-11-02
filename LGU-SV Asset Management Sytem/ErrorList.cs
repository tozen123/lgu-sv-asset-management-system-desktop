using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    static class ErrorList
    {
        /*
         * Error 1: This error message is for the case that the system user session already ended but the user
         * still inside the system.
         */
        public static string[] Error1()
        {
            string Title()
            {
                return "Error 1: Session Handler";
            }

            string Message()
            {
                return "INTERNAL ERROR: YOU SHOULD NOT BE HERE. \nTHE SESSION ALREADY ENDED. SYSTEM WILL NOW EXIT";
            }

            string i = Title() + "-" + Message();
            return i.Split('-');
        }

        /*
         * Error 2: This error message is for the case that the system user session failed to fetch data from the 
         * database
         */
        public static string[] Error2()
        {
            string Title()
            {
                return "Error 2: Session Handler";
            }

            string Message()
            {
                return "INTERNAL ERROR: SYSTEM FAILED TO FETCH DATA \nTHE SESSION DID NOT PROCEED PROPERLY. SYSTEM WILL NOW EXIT";
            }

            string i = Title() + "-" + Message();
            return i.Split('-');
        }

        /*
         * Error 3: 
         */
        public static string[] Error3()
        {
            string Title()
            {
                return "Error 3: Input Error";
            }

            string Message()
            {
                return "INPUT ERROR OCCURED.";
            }

            string i = Title() + "-" + Message();
            return i.Split('-');
        }
    }
}
