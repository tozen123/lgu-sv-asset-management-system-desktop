using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LGU_SV_Asset_Management_Sytem
{
    class AssetCoordinator : User
    {
        private int assetEmployeeId;

        // Property for assetEmployeeId
        public int AssetEmployeeId
        {
            get { return assetEmployeeId; }
            set { assetEmployeeId = value; }
        }

        private string assetEmployeeFirstName, assetEmployeeMiddleName, assetEmployeeLastName, assetEmployeeAddress;

        // Property for assetEmployeeFirstName
        public string AssetEmployeeFirstName
        {
            get { return assetEmployeeFirstName; }
            set { assetEmployeeFirstName = value; }
        }

        // Property for assetEmployeeMiddleName
        public string AssetEmployeeMiddleName
        {
            get { return assetEmployeeMiddleName; }
            set { assetEmployeeMiddleName = value; }
        }

        // Property for assetEmployeeLastName
        public string AssetEmployeeLastName
        {
            get { return assetEmployeeLastName; }
            set { assetEmployeeLastName = value; }
        }

        private string assetEmployeePhoneNum;

        // Property for assetEmployeePhoneNum
        public string AssetEmployeePhoneNum
        {
            get { return assetEmployeePhoneNum; }
            set { assetEmployeePhoneNum = value; }
        }

        // Property for assetEmployeeAddress
        public string AssetEmployeeAddress
        {
            get { return assetEmployeeAddress; }
            set { assetEmployeeAddress = value; }
        }

        private string assetEmployeeEmail;
        // Property for assetEmployeeEmail
        public string AssetEmployeeEmail
        {
            get { return assetEmployeeEmail; }
            set { assetEmployeeEmail = value; }
        }

        private string assetEmployeeOffice;
        // Property for assetEmployeeOffice
        public string AssetEmployeeOffice
        {
            get { return assetEmployeeOffice; }
            set { assetEmployeeOffice = value; }
        }

        public class AssetCoordinatorRepositoryControl
        {
            private DatabaseConnection databaseConnection;

            public AssetCoordinatorRepositoryControl()
            {
                databaseConnection = new DatabaseConnection();
            }

            public (bool Success, string ErrorMessage, DataTable resultTable) GetAllOperators()
            {
                try
                {
                    string query = "SELECT Id, FName, MName, " +
                        "LName, PhoneNumber, " +
                        "Email, Address, " +
                        "Office " +
                        "FROM AssetCoordinator";


                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    DataTable table = databaseConnection.ReadFromDatabase(query, parameters);

                    databaseConnection.CloseConnection();

                    return (true, null, table);
                }
                catch (Exception ex)
                {
                    return (false, ex.Message, null);
                }
            }

            public (bool Success, string ErrorMessage) AddToDatabase(AssetCoordinator assetEmployee)
            {
                try
                {
                    string query = "INSERT INTO AssetCoordinator " +
                        "(FName, MName, LName, PhoneNumber, " +
                        "Email, Address, Office) " +
                        "VALUES " +
                        "(@assetEmployeeFName, @assetEmployeeMName, @assetEmployeeLName, @assetEmployeePhoneNum, " +
                        "@assetEmployeeEmail, @assetEmployeeAddress, @assetEmployeeOffice)";

                                Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@assetEmployeeFName", assetEmployee.AssetEmployeeFirstName },
                        {"@assetEmployeeMName", assetEmployee.AssetEmployeeMiddleName},
                        {"@assetEmployeeLName", assetEmployee.AssetEmployeeLastName},
                        {"@assetEmployeePhoneNum", assetEmployee.AssetEmployeePhoneNum},
                        {"@assetEmployeeEmail", assetEmployee.AssetEmployeeEmail},
                        {"@assetEmployeeAddress", assetEmployee.AssetEmployeeAddress},
                        {"@assetEmployeeOffice", assetEmployee.AssetEmployeeOffice}
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

            public (string name, bool Success, string ErrorMessage) GetCoordinatorName(int id)
            {
                try
                {
                    string query = "SELECT FName, MName, LName FROM AssetCoordinator WHERE Id = @id";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@id", id }
                    };

                    DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);
                    if (resultTable.Rows.Count > 0)
                    {
                        DataRow row = resultTable.Rows[0];

                       
                        string fname = row["FName"].ToString();
                        string mname = row["MName"].ToString();
                        string lname = row["LName"].ToString();

                        string resultName = $"{fname} {mname} {lname}";

                        databaseConnection.CloseConnection();

                        return (resultName, true, null);
                    }
                    else
                    {
                        
                        return ("", false, "No matching record found.");
                    }
                }
                catch (Exception ex)
                {
                    return ("", false, ex.Message);
                }
            }

            public (string office, bool Success, string ErrorMessage) GetCoordinatorOffice(int id)
            {
                try
                {
                    string query = "SELECT Office FROM AssetCoordinator WHERE Id = @id";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@id", id }
                    };

                    DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);
                    if (resultTable.Rows.Count > 0)
                    {
                        DataRow row = resultTable.Rows[0];


                        string office = row["Office"].ToString();
               

                        string resultName = $"{office}";

                        databaseConnection.CloseConnection();

                        return (resultName, true, null);
                    }
                    else
                    {

                        return ("", false, "No matching record found.");
                    }
                }
                catch (Exception ex)
                {
                    return ("", false, ex.Message);
                }
            }
        }
    }
}
