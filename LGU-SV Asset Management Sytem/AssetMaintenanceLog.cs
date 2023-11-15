using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGU_SV_Asset_Management_Sytem
{
    class AssetMaintenanceLog
    {
        string maintenanceLogId;
        string assetId;
        string assetOperatorId;

        DateTime maintenanceDate;

        string maintenanceDescription;
        string maintenanceStatus;

        decimal maintenanceCost;

        public class AssetMaintenanceLogRepositoryControl
        {
            void GenerateEmptyLog()
            {

            }
        }

    }
}
