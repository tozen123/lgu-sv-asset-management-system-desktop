using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    public class Asset : AssetBehaviour
    {
        // Integers
        private int assetId, assetSupervisorId, currentEmployeeId, supplierId, assetCategoryId;
          
        // Property for assetId
        public int AssetId
        {
            get { return assetId; }
            set { assetId = value; }
        }

        // Property for assetSupervisorId
        public int AssetSupervisorId
        {
            get { return assetSupervisorId; }
            set { assetSupervisorId = value; }
        }

        // Property for currentEmployeeId
        public int CurrentEmployeeId
        {
            get { return currentEmployeeId; }
            set { currentEmployeeId = value; }
        }

        // Property for supplierId
        public int SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }

        // Property for assetCategoryId
        public int AssetCategoryId
        {
            get { return assetCategoryId; }
            set { assetCategoryId = value; }
        }


        private string assetName, assetLocation, QrCode;
        private byte[] assetQrCodeImage;

        // Property for assetName
        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }

        // Property for assetLocation
        public string AssetLocation
        {
            get { return assetLocation; }
            set { assetLocation = value; }
        }

        // Property for qrCode
        public string QRCode
        {
            get { return QrCode; }
            set { QrCode = value; }
        }

        //Property for QRCodeImage
        public byte[] AssetQRCodeImage
        {
            get { return assetQrCodeImage; }
            set { assetQrCodeImage = value; }
        }

        private byte[] assetImage;
        //Property for Asset IMage
        public byte[] AssetImage
        {
            get { return assetImage; }
            set { assetImage = value; }
        }

        private string assetCondition;
        public string AssetCondition
        {
            get { return assetCondition; }
            set { assetCondition = value; }
        }


        private Boolean isArchive, isMissing, isMaintainable;

        // Property for isArchive
        public bool IsArchive
        {
            get { return isArchive; }
            set { isArchive = value; }
        }

        // Property for isMissing
        public bool IsMissing
        {
            get { return isMissing; }
            set { isMissing = value; }
        }

        // Property for isMaintainable

       
        public bool IsMaintainable
        {
            get { return isMaintainable; }
            set { isMaintainable = value; }
        }

        private decimal assetPurchaseAmount;

        // Property for assetPurchaseAmount
        public decimal AssetPurchaseAmount
        {
            get { return assetPurchaseAmount; }
            set { assetPurchaseAmount = value; }
        }

        private DateTime assetPurchaseDate;

        // Property for assetPurchaseDate
        public DateTime AssetPurchaseDate
        {
            get { return assetPurchaseDate; }
            set { assetPurchaseDate = value; }
        }

        private string assetMaintenanceLogsID;

        // Property for assetMaintenanceLogsID
        public string AssetMaintenanceLogsID
        {
            get { return assetMaintenanceLogsID; }
            set { assetMaintenanceLogsID = value; }
        }

        private int assetQuantity;

        // Property for assetQuantity
        public int AssetQuantity
        {
            get { return assetQuantity; }
            set { assetQuantity = value; }
        }

        // Property for assetUnit

        private string assetUnit;
        public string AssetUnit
        {
            get { return assetUnit; }
            set { assetUnit = value; }
        }

  


        //Oms

        private string supplierName, assetCategoryName, employeeName;
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }

        public string AssetCategoryName
        {
            get { return assetCategoryName; }
            set { assetCategoryName = value; }
        }

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        private string assetPurpose, assetDescription;
        public string AssetPurpose
        {
            get { return assetPurpose; }
            set { assetPurpose = value; }
        }

        public string AssetDescription
        {
            get { return assetDescription; }
            set { assetDescription = value; }
        }

        private int assetPropertyNumber;
        public int AssetPropertyNumber
        {
            get { return assetPropertyNumber; }
            set { assetPropertyNumber = value; }
        }

        public class AssetRepositoryControl
        {
            private DatabaseConnection databaseConnection;
            public AssetRepositoryControl()
            {
                databaseConnection = new DatabaseConnection();
            }

            public (bool Success, string ErrorMessage) UpdateToDatabase(Asset _asset)
            {
                try
                {
                    string query = "UPDATE Assets " +
                        "SET " +
                        "assetName = @assetName, " +
                        "assetQuantity = @assetQuantity, " +
                        "assetPurchaseAmount = @AssetPAmount, " +
                        "assetPurpose = @assetPurpose, " +
                        "assetDescription = @assetDesc, " +
                        "supplierID = @assetSupId, " +
                        "assetPropertyNumber = @assetPNumber, " +
                        "assetCondition = @assetCondition, " +
                        "assetImage = @assetImage " +
                        "WHERE " +
                        "assetId = @assetId";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@assetName", _asset.AssetName},
                        {"@assetQuantity", _asset.AssetQuantity},
                        {"@AssetPAmount", _asset.AssetPurchaseAmount},
                        {"@assetPurpose", _asset.AssetPurpose},
                        {"@assetDesc", _asset.AssetDescription},
                        {"@assetSupId", _asset.SupplierId},
                        {"@assetPNumber", _asset.AssetPropertyNumber},
                        {"@assetCondition", _asset.AssetCondition},
                        {"@assetId", _asset.AssetId},
                        {"@assetImage", _asset.AssetImage}
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
            public (bool Success, string ErrorMessage) UpdateOfficeAndLocationToDatabase(Asset _asset)
            {
                try
                {
                    string query = "UPDATE Assets " +
                        "SET " +
                        "assetLocation = @assetLocation, " +
                        "currentCustodianAssetCoordID = @currentCustodianAssetCoordID " +
                        "WHERE " +
                        "assetId = @assetId";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@assetId", _asset.AssetId},
                        {"@assetLocation", _asset.AssetLocation},
                        {"@currentCustodianAssetCoordID", _asset.CurrentEmployeeId}
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
            public (bool Success, string ErrorMessage) DeleteToDatabase(Asset asset)
            {
                try
                {
                    string query = "DELETE From Assets WHERE assetId = @id";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@id", asset.AssetId}
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

            public (bool Success, string ErrorMessage) SetArchiveState(Asset asset)
            {
                try
                {
                    string query = "UPDATE Assets SET assetIsArchive = @state WHERE assetId = @id";

                    int value;
                    if (asset.isArchive == true)
                    {
                        value = 1;
                    } 
                    else
                    {
                        value = 0;
                    }
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@id", asset.AssetId},
                        {"@state",  value}
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

            public (Asset retrievedAsset, bool Success, string ErrorMessage) RetrieveAsset(int assetId)
            {
           
                try
                {
                    Asset retrievedAsset = new Asset();

                    string query = $@"
                                    SELECT
                                        assetId,
                                        assetAdminID,
                                        assetName,
                                        currentCustodianAssetCoordID,
                                        supplierID,
                                        assetCategoryID,
                                        assetCondition,
                                        assetQrCodeImage,
                                        assetQrStrDefinition,
                                        assetLocation,
                                        assetIsArchive,
                                        assetAcknowledgeDate,
                                        assetPurchaseAmount,
                                        assetQuantity,
                                        assetUnit,
                                        assetImage,
                                        assetIsMaintainable,
                                        assetIsMissing,
                                        assetPurpose,
                                        assetDescription,
                                        assetPropertyNumber
                                    FROM Assets WHERE assetId = {assetId}";

                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);


                    if (resultTable.Rows.Count > 0)
                    { 
                        DataRow row = resultTable.Rows[0];

                        retrievedAsset.AssetId = Convert.ToInt32(row["assetId"]);
                        retrievedAsset.AssetSupervisorId = Convert.ToInt32(row["assetAdminID"]);
                        retrievedAsset.AssetName = Convert.ToString(row["assetName"]);
                        retrievedAsset.CurrentEmployeeId = Convert.ToInt32(row["currentCustodianAssetCoordID"]);
                        retrievedAsset.SupplierId = Convert.ToInt32(row["supplierID"]); 
                        retrievedAsset.AssetCategoryId = Convert.ToInt32(row["assetCategoryID"]);
                        retrievedAsset.AssetCondition = Convert.ToString(row["assetCondition"]);
                        retrievedAsset.AssetQRCodeImage = (byte[])row["assetQrCodeImage"];
                        retrievedAsset.QRCode = Convert.ToString(row["assetQrStrDefinition"]);
                        retrievedAsset.AssetLocation = Convert.ToString(row["assetLocation"]);
                        retrievedAsset.IsArchive = Convert.ToBoolean(row["assetIsArchive"]);
                        retrievedAsset.AssetPurchaseDate = Convert.ToDateTime(row["assetAcknowledgeDate"]);
                        retrievedAsset.AssetPurchaseAmount = Convert.ToDecimal(row["assetPurchaseAmount"]);
                        retrievedAsset.AssetQuantity = Convert.ToInt32(row["assetQuantity"]);
                        retrievedAsset.AssetUnit = Convert.ToString(row["assetUnit"]);
                        retrievedAsset.AssetImage = (byte[])row["assetImage"];
                        retrievedAsset.IsMaintainable = Convert.ToBoolean(row["assetIsMaintainable"]);
                        retrievedAsset.IsMissing = Convert.ToBoolean(row["assetIsMissing"]);
                        retrievedAsset.AssetPurpose = Convert.ToString(row["assetPurpose"]);
                        retrievedAsset.AssetDescription = Convert.ToString(row["assetDescription"]);
                        retrievedAsset.AssetPropertyNumber = Convert.ToInt32(row["assetPropertyNumber"]);
                    }

                    databaseConnection.CloseConnection();

                    return (retrievedAsset, true, null);
                }
                catch (Exception ex)
                {
                    return (null, false, ex.Message);
                }
            }
        }

    }
}
