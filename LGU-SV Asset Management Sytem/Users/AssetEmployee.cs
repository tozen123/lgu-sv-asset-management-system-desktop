using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LGU_SV_Asset_Management_Sytem
{
    class AssetEmployee : User
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

        public class AssetEmployeeRepositoryControl
        {
            private DatabaseConnection databaseConnection;

            public AssetEmployeeRepositoryControl()
            {
                databaseConnection = new DatabaseConnection();
            }

            public (bool Success, string ErrorMessage, DataTable resultTable) GetAllOperators()
            {
                try
                {
                    string query = "SELECT assetEmployeeId, assetEmployeeFName, assetEmployeeMName, " +
                        "assetEmployeeLName, assetEmployeePhoneNum, " +
                        "assetEmployeeEmail, assetEmployeeAddress, " +
                        "assetEmployeeOffice " +
                        "FROM AssetEmployee";


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

            public (bool Success, string ErrorMessage) AddToDatabase(AssetEmployee assetEmployee)
            {
                try
                {
                    string query = "INSERT INTO AssetEmployee " +
                        "(assetEmployeeFName, assetEmployeeMName, assetEmployeeLName, assetEmployeePhoneNum, " +
                        "assetEmployeeEmail, assetEmployeeAddress, assetEmployeeOffice) " +
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
        }
    }
}
