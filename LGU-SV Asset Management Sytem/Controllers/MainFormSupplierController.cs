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
                if(CheckForExistingEntry(suppliername, phoneNumber, supplieraddress) == true)
                {
                    return (false, ErrorList.Error4()[0] + "\n" + ErrorList.Error4()[1]);
                }

                string query = "INSERT INTO Supplier (supplierName, supplierPhoneNum, supplierAddress) VALUES (@name, @phonenumber, @supplieraddr)";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@name", suppliername},
                    {"@phonenumber", phoneNumber },
                    {"@supplieraddr", supplieraddress }
                };

                databaseConnection.UploadToDatabase(query, parameters);

                databaseConnection.CloseConnection();

                return (true, null); 
            }
            catch (Exception ex)
            {
                return (false, ex.Message); 
            }
        }

        /*
         * Check for existing entries. return false if no existing and true if there is existing data
         */
        public bool CheckForExistingEntry(string suppliername, string phoneNumber, string supplieraddress)
        {
            string queryCheck = "SELECT COUNT(*) FROM Supplier WHERE supplierName = @name AND supplierPhoneNum = @phonenumber AND supplierAddress = @supplieraddr";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@name", suppliername},
                {"@phonenumber", phoneNumber },
                {"@supplieraddr", supplieraddress }
            };

            
            DataTable resultTable = databaseConnection.ReadFromDatabase(queryCheck, parameters);

            if(resultTable.Rows.Count == 1 && Convert.ToInt32(resultTable.Rows[0][0]) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
         * Delete Data
         */
        public (bool Success, string ErrorMessage) DeleteSupplierEntry(string supplier_id)
        {
            try
            {

                string query = "DELETE From Supplier WHERE supplierId = @supId";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@supId", supplier_id}
                };

                databaseConnection.ReadFromDatabase(query, parameters);

                databaseConnection.CloseConnection();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /*
         * Update Supplier Data
         */

        public (bool Success, string ErrorMessage) UpdateSupplierEntry(string supplier_id, string suppliername, string phoneNumber, string supplieraddress)
        {
            try
            {
                string query = "UPDATE Supplier " +
                    "SET supplierName = @suppliername, " +
                    "supplierPhoneNum = @phoneNumber, " +
                    "supplierAddress = @supplieraddress " +
                    "WHERE supplierId = @supId";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@supId", supplier_id},
                    {"@suppliername", suppliername},
                    {"@phoneNumber", phoneNumber},
                    {"@supplieraddress", supplieraddress}
                };

                databaseConnection.ReadFromDatabase(query, parameters);

                databaseConnection.CloseConnection();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }


}
