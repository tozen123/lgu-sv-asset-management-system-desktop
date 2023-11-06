using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LGU_SV_Asset_Management_Sytem
{
    class AssetOperator: User
    {
        //Level
        

        private int assetOperatorId;

        // Property for assetOperatorId
        public int AssetOperatorId
        {
            get { return assetOperatorId; }
            set { assetOperatorId = value; }
        }

        private string assetOperatorFirstName, assetOperatorMiddleName, assetOperatorLastName, assetOperatorAddress;

        // Property for assetOperatorFirstName
        public string AssetOperatorFirstName
        {
            get { return assetOperatorFirstName; }
            set { assetOperatorFirstName = value; }
        }

        // Property for assetOperatorMiddleName
        public string AssetOperatorMiddleName
        {
            get { return assetOperatorMiddleName; }
            set { assetOperatorMiddleName = value; }
        }

        // Property for assetOperatorLastName
        public string AssetOperatorLastName
        {
            get { return assetOperatorLastName; }
            set { assetOperatorLastName = value; }
        }

        private string assetOperatorPhoneNum;

        // Property for assetOperatorPhoneNum
        public string AssetOperatorPhoneNum
        {
            get { return assetOperatorPhoneNum; }
            set { assetOperatorPhoneNum = value; }
        }

        // Property for assetOperatorAddress
        public string AssetOperatorAddress
        {
            get { return assetOperatorAddress; }
            set { assetOperatorAddress = value; }
        }

        private string assetOperatorEmail;
        // Property for assetOperatorEmail
        public string AssetOperatorEmail
        {
            get { return assetOperatorEmail; }
            set { assetOperatorEmail = value; }
        }

        private string assetOperatorOffice;
        // Property for assetOperatorOffice
        public string AssetOperatorOffice
        {
            get { return assetOperatorOffice; }
            set { assetOperatorOffice = value; }
        }

        public class AssetOperatorRepositoryControl
        {
            private DatabaseConnection databaseConnection;

            public AssetOperatorRepositoryControl()
            {
                databaseConnection = new DatabaseConnection();
            }

            public (bool Success, string ErrorMessage, DataTable resultTable) GetAllOperators()
            {
                try
                {
                    string query = "SELECT assetOperatorId, assetOperatorFName, assetOperatorMName " +
                        "assetOperatorLName, assetOperatorPhoneNum, " +
                        "assetOperatorEmail, assetOperatorAddress, " +
                        "assetOperatorOffice " +
                        "From AssetOperator";

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

            public (bool Success, string ErrorMessage) AddToDatabase(AssetOperator assetOperator)
            {
                try
                {
                    string query = "INSERT INTO AssetOperator " +
                        "(assetOperatorFName, assetOperatorMName, assetOperatorLName, assetOperatorPhoneNum, " +
                        "assetOperatorEmail, assetOperatorAddress, assetOperatorOffice) " +
                        "VALUES " +
                        "(@assetCategoryName, @assetCategoryDescription)";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@assetOperatorFName", assetOperator.assetOperatorFirstName },
                        {"@assetOperatorMName", assetOperator.assetOperatorMiddleName},
                        {"@assetOperatorLName", assetOperator.assetOperatorLastName},
                        {"@assetOperatorPhoneNum", assetOperator.assetOperatorPhoneNum},
                        {"@assetOperatorEmail", assetOperator.assetOperatorEmail},
                        {"@assetOperatorAddress", assetOperator.assetOperatorAddress},
                        {"@assetOperatorOffice", assetOperator.assetOperatorOffice}
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
