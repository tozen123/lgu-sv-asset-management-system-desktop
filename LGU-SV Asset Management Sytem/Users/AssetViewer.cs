using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    class AssetViewer : User
    {
        private int assetViewerId;
        // Property for assetViewerId
        public int AssetViewerId
        {
            get { return assetViewerId; }
            set { assetViewerId = value; }
        }

        private string assetViewerFName, assetViewerMName, assetViewerLName, assetViewerAddress;
       
        // Property for assetViewerFName
        public string AssetViewerFName
        {
            get { return assetViewerFName; }
            set { assetViewerFName = value; }
        }

        // Property for assetViewerMName
        public string AssetViewerMName
        {
            get { return assetViewerMName; }
            set { assetViewerMName = value; }
        }

        // Property for assetViewerLName
        public string AssetViewerLName
        {
            get { return assetViewerLName; }
            set { assetViewerLName = value; }
        }

        // Property for assetViewerAddress
        public string AssetViewerAddress
        {
            get { return assetViewerAddress; }
            set { assetViewerAddress = value; }
        }

        private int assetViewerPhoneNum;

        // Property for assetViewerPhoneNum
        public int AssetViewerPhoneNum
        {
            get { return assetViewerPhoneNum; }
            set { assetViewerPhoneNum = value; }
        }
    }
}
