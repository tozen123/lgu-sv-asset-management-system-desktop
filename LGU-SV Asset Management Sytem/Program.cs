using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           
            
        }
        public static void TestDB()
        {
            AssetManager john = new AssetManager();
            john.AssetManagerID = 123;
            john.AssetManagerFName = "John";
            john.AssetManagerMName = "M";
            john.AssetManagerLName = "Doe";
            john.AssetManagerPhoneNum = 912345672;

            string query = "INSERT INTO AssetManager (assetManagerId, assetManagerFName, assetManagerMName, assetManagerLName, assetManagerPhoneNumber) " +
                "VALUES (@Value1, @Value2, @Value3, @Value4, @Value5)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Value1", 123 },
                { "@Value2", "John" },
                { "@Value3", "M" },
                { "@Value4", "Doe" },
                { "@Value5", 912345672 }
            };

            john.UploadToDatabase(query, parameters);
        }
    }
}
