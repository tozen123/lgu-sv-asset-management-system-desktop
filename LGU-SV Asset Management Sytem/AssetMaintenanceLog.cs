using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    class AssetMaintenanceLog
    {
       
        private string _maintenanceLogId;
        private int _assetId;
        private string _assetEmployeeId;

        private DateTime _maintenanceDate;

        private string _maintenanceDescription;
        private string _maintenanceStatus;
        private string _maintenanceCategory;

        private decimal _maintenanceCost;

        // Property for MaintenanceLogId
        public string MaintenanceLogId
        {
            get { return _maintenanceLogId; }
            set { _maintenanceLogId = value; }
        }

        // Property for AssetId
        public int AssetId
        {
            get { return _assetId; }
            set { _assetId = value; }
        }

        // Property for AssetOperatorId
        public string AssetEmployeeId
        {
            get { return _assetEmployeeId; }
            set { _assetEmployeeId = value; }
        }

        // Property for MaintenanceDate
        public DateTime MaintenanceDate
        {
            get { return _maintenanceDate; }
            set { _maintenanceDate = value; }
        }

        // Property for MaintenanceDescription
        public string MaintenanceDescription
        {
            get { return _maintenanceDescription; }
            set { _maintenanceDescription = value; }
        }

        // Property for MaintenanceStatus
        public string MaintenanceStatus
        {
            get { return _maintenanceStatus; }
            set { _maintenanceStatus = value; }
        }

        // Property for MaintenanceCategory
        public string MaintenanceCategory
        {
            get { return _maintenanceCategory; }
            set { _maintenanceCategory = value; }
        }

        // Property for MaintenanceCost
        public decimal MaintenanceCost
        {
            get { return _maintenanceCost; }
            set { _maintenanceCost = value; }
        }
        public class AssetMaintenanceLogRepositoryControl
        {
            private DatabaseConnection databaseConnection;

            public AssetMaintenanceLogRepositoryControl()
            {
                databaseConnection = new DatabaseConnection();
            }

            public (bool Success, string ErrorMessage) AddToDatabase(AssetMaintenanceLog _assetMaintenanceLog)
            {
                try
                {
                    string query = "INSERT INTO MaintenanceLog (assetId, assetEmployeeId, maintenanceDate, maintenanceDescription, " +
                        "maintenanceStatus, maintenanceCost, maintenanceCategory) VALUES (@assetId, @assetEmpId, @mDate, @mDesc, @mStatus, @mCost, " +
                        "@mCategory)";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@assetId", _assetMaintenanceLog.AssetId},
                        {"@assetEmpId", _assetMaintenanceLog.AssetEmployeeId},
                        {"@mDate", _assetMaintenanceLog.MaintenanceDate},
                        {"@mDesc", _assetMaintenanceLog.MaintenanceDescription},
                        {"@mStatus", _assetMaintenanceLog.MaintenanceStatus},
                        {"@mCost", _assetMaintenanceLog._maintenanceCost},
                        {"@mCategory", _assetMaintenanceLog._maintenanceCategory}
                        
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

            public (bool Success, string ErrorMessage) DeleteToDatabase(AssetMaintenanceLog _assetMaintenanceLog)
            {
                try
                {
                    string query = "DELETE FROM MaintenanceLog WHERE maintenanceLogId = @mId";

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {"@mId", _assetMaintenanceLog.MaintenanceLogId}

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

            public void UpdateLog()
            {

            }

            public void UpdateLogStatus()
            {

            }
        }

    }
}
