using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
namespace LGU_SV_Asset_Management_Sytem
{
    public static class Utilities
    {
        public static byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        public static void ClearTextFieldsHandler(Control[] fields)
        {
            foreach (Control control in fields)
            {
                control.Text = "";
            }
        }

        public static void SetButtonsState(Control[] buttons, bool state)
        {
            foreach (Control control in buttons)
            {
                control.Enabled = state;
            }
        }

        public static void SetControlsVisibilityState(Control[] buttons, bool state)
        {
            foreach (Control control in buttons)
            {
                control.Visible = state;
            }
        }

        public static void PanelChanger(Control panelControl, Control panelToAdd)
        {
            panelControl.Controls.Clear();
            panelControl.Controls.Add(panelToAdd);
            panelControl.BringToFront();
            panelControl.Visible = true;
        }
    }
}
