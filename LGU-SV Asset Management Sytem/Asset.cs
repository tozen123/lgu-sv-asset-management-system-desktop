using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    class Asset : AssetBehaviour
    {
        // Integers
        private int assetId, assetSupervisorId, currentEmployeeId, supplierId, assetCategoryId, assetLastMaintenanceID;

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

        // Property for assetLastMaintenanceID
        public int AssetLastMaintenanceID
        {
            get { return assetLastMaintenanceID; }
            set { assetLastMaintenanceID = value; }
        }

        public Availability AssetAvailability { get; set; }
        public enum Availability
        {
            USED,
            AVAILABLE
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

        public CONDITION AssetCondition { get; set; }
        public enum CONDITION
        {
            WORKING,
            INOPERABLE
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


        public class AssetRepositoryControl
        {
            

        }

    }
}
