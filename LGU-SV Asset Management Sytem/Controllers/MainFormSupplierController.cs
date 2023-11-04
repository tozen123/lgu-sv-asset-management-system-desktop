using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LGU_SV_Asset_Management_Sytem.Controllers
{
    class MainFormSupplierController
    {
        private DatabaseConnection databaseConnection;
        public MainFormSupplierController(DatabaseConnection _dbc)
        {
            databaseConnection = _dbc;
        }

        public DataTable GetAllSupplier()
        {
            string query = "SELECT supplierId, supplierName, supplierPhoneNum, supplierAddress FROM Supplier";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            databaseConnection.CloseConnection();
            return resultTable;
        }

        public (bool Success, string ErrorMessage) AddNewSupplier(string suppliername, string phoneNumber, string supplieraddress)
        {
            try
            {
                string query = "INSERT INTO Supplier (supplierName, supplierPhoneNum, supplierAddress) VALUES (@name, @phonenumber, @supplieraddr)";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@name", suppliername},
                    {"@phonenumber", phoneNumber },
                    {"@supplieraddr", supplieraddress }
                };

                databaseConnection.UploadToDatabase(query, parameters);

                databaseConnection.CloseConnection();

                return (true, null); // Upload was successful, no error message
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Upload failed, include the error message
            }
        }

    }


}
