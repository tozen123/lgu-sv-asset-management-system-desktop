using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    class AssetManager: User
    {
        private int assetManagerId;

        // Property for assetManagerId
        public int AssetManagerID
        {
            get { return assetManagerId; }
            set { assetManagerId = value; }
        }

        private string assetManagerFName, assetManagerMName, assetManagerLName;

        // Property for assetManagerFName
        public string AssetManagerFName
        {
            get { return assetManagerFName; }
            set { assetManagerFName = value; }
        }

        // Property for assetManagerMName
        public string AssetManagerMName
        {
            get { return assetManagerMName; }
            set { assetManagerMName = value; }
        }

        // Property for assetManagerLName
        public string AssetManagerLName
        {
            get { return assetManagerLName; }
            set { assetManagerLName = value; }
        }

        private int assetManagerPhoneNum;

        // Property for assetManagerPhoneNum
        public int AssetManagerPhoneNum
        {
            get { return assetManagerPhoneNum; }
            set { assetManagerPhoneNum = value; }
        }
    }
}
