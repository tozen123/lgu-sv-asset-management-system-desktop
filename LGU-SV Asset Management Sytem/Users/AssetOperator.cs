using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int assetOperatorPhoneNum;

        // Property for assetOperatorPhoneNum
        public int AssetOperatorPhoneNum
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
    }
}
