using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    class AssetAdministrator : User
    {
        private int assetSupervisorId;

        // Property for assetSupervisorId
        public int AssetSupervisorID
        {
            get { return assetSupervisorId; }
            set { assetSupervisorId = value; }
        }

        private string assetSupervisorFName, assetSupervisorMName, assetSupervisorLName;

        // Property for assetSupervisorFName
        public string AssetSupervisorFName
        {
            get { return assetSupervisorFName; }
            set { assetSupervisorFName = value; }
        }

        // Property for assetSupervisorMName
        public string AssetSupervisorMName
        {
            get { return assetSupervisorMName; }
            set { assetSupervisorMName = value; }
        }

        // Property for assetSupervisorLName
        public string AssetSupervisorLName
        {
            get { return assetSupervisorLName; }
            set { assetSupervisorLName = value; }
        }

        private int assetSupervisorPhoneNum;

        // Property for assetSupervisorPhoneNum
        public int AssetSupervisorPhoneNum
        {
            get { return assetSupervisorPhoneNum; }
            set { assetSupervisorPhoneNum = value; }
        }
    }
}
