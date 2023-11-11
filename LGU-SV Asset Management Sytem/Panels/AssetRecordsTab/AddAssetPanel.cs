using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.AssetRecordsTab
{
    
    public partial class AddAssetPanel : UserControl
    {
        public enum AssetType
        {
            New,
            Existing
        }

        public AssetType assetType;

        public AddAssetPanel(AssetType _assetType)
        {
            InitializeComponent();

            assetType = _assetType;

            Init();
        }
        private void Init()
        {
            switch (assetType)
            {
                case AssetType.New:
                    buttonAdd.Text = "Add New Asset";

                    break;
                case AssetType.Existing:
                    buttonAdd.Text = "Add Existing Asset";

                    break;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
