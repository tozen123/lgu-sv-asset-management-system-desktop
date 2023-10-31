using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    class Asset: AssetBehaviour
    {
        // Integers
        private int assetId, assetManagerId, currentOperatorId, supplierId, assetCategoryId, assetLastMaintenanceID;

        // Property for assetId
        public int AssetId
        {
            get { return assetId; }
            set { assetId = value; }
        }

        // Property for assetManagerId
        public int AssetManagerId
        {
            get { return assetManagerId; }
            set { assetManagerId = value; }
        }

        // Property for currentOperatorId
        public int CurrentOperatorId
        {
            get { return currentOperatorId; }
            set { currentOperatorId = value; }
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

        // Property for assetLastMaintenanceID
        public int AssetLastMaintenanceID
        {
            get { return assetLastMaintenanceID; }
            set { assetLastMaintenanceID = value; }
        }

        public STATUS AssetStatus { get; set; }
        public enum STATUS
        {
            USED,
            AVAILABLE
        }

        private string assetName, assetLocation, qrCode;

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
            get { return qrCode; }
            set { qrCode = value; }
        }

        public CONDITION AssetCondition { get; set; }
        public enum CONDITION
        {
            WORKING,
            INOPERABLE
        }

        private Boolean isArchive;

        // Property for isArchive
        public bool IsArchive
        {
            get { return isArchive; }
            set { isArchive = value; }
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
    }
}
