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
        private string _assetId;
        private string _assetOperatorId;

        private DateTime _maintenanceDate;

        private string _maintenanceDescription;
        private string _maintenanceStatus;

        private decimal _maintenanceCost;

        // Property for MaintenanceLogId
        public string MaintenanceLogId
        {
            get { return _maintenanceLogId; }
            set { _maintenanceLogId = value; }
        }

        // Property for AssetId
        public string AssetId
        {
            get { return _assetId; }
            set { _assetId = value; }
        }

        // Property for AssetOperatorId
        public string AssetOperatorId
        {
            get { return _assetOperatorId; }
            set { _assetOperatorId = value; }
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

        // Property for MaintenanceCost
        public decimal MaintenanceCost
        {
            get { return _maintenanceCost; }
            set { _maintenanceCost = value; }
        }
        public class AssetMaintenanceLogRepositoryControl
        {
            void ViewLog()
            {

            }

            void SetLogs()
            {

            }

            void AddNewLog()
            {

            }

            void DeleteLog()
            {

            }

            void UpdateLog()
            {

            }
        }

    }
}
