using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.MaintenancePanel
{
    public partial class AssetMaintenanceLogPanel : UserControl
    {
        Panel panelHandlerParent;
        Asset asset;
        User currentUser;
        public AssetMaintenanceLogPanel(Panel _panelHandler, Asset _asset, User _currentUser)
        {
            InitializeComponent();
            panelHandlerParent = _panelHandler;
            asset = _asset;
            currentUser = _currentUser;

            Console.WriteLine("AssetMaintenanceLogPanel: " + currentUser.GetStringAccessLevel());

            InitializeRecords();
            SetData();
        }

        public void InitializeRecords()
        {

        }

        private void SetData()
        {
            labelAssetIdWithName.Text = "Maintenance Logs: " + asset.AssetId + "-" + asset.AssetName;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ClearPanel(panelHandlerParent);
        }

        private void ClearPanel(Panel panelToClear)
        {
            panelToClear.Controls.Clear();
            panelToClear.SendToBack();
            panelToClear.Visible = false;
        }

        private void SwitchMiniPanelHandler(Control panelToSwitch)
        {
            if(panelLogMiniHandler.Controls.Count > 0)
            {
                ClearPanel(panelLogMiniHandler);
            }

            panelLogMiniHandler.Controls.Add(panelToSwitch);
            panelLogMiniHandler.BringToFront();
            panelLogMiniHandler.Visible = true;
        }

        private void buttonNewLog_Click(object sender, EventArgs e)
        {
            AddNewMaintenanceLogPanel addNewMaintenanceLogPanel = new AddNewMaintenanceLogPanel(panelLogMiniHandler, asset);
            SwitchMiniPanelHandler(addNewMaintenanceLogPanel);
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            AddAssetSchedulePanel addAssetSchedulePanel = new AddAssetSchedulePanel(panelLogMiniHandler, asset);
            SwitchMiniPanelHandler(addAssetSchedulePanel);
        }
    }
}
