using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGU_SV_Asset_Management_Sytem.Panels.GenerateReports
{   
  
    public partial class MainGenerateReports : UserControl
    {
        private DatabaseConnection databaseConnection;

        public MainGenerateReports()
        {
            InitializeComponent();
            databaseConnection = new DatabaseConnection();
            PopulateCategoryComboBox();
           

            panelFilterHandler.Visible = false;


        }
       
        public void PopulateCategoryComboBox()
        {
            string query = "SELECT CONCAT(assetCategoryId, '-', assetCategoryName) AS cat FROM AssetCategory"; ;


            Dictionary<string, object> parameters = new Dictionary<string, object>();

            DataTable resultTable = databaseConnection.ReadFromDatabase(query, parameters);

            List<string> categories = new List<string>();

           
            foreach (DataRow row in resultTable.Rows)
            {
                string category = row["cat"].ToString();
                Console.WriteLine(category);
                categories.Add(category);
            }

            databaseConnection.CloseConnection();

            for (int i = 0; i < categories.Count; i++)
            {
                CheckBox checkBox = new CheckBox();

                checkBox.Name = categories[i].Split('-')[1].Trim();
                checkBox.Text = categories[i].Split('-')[1].Trim();
                checkBox.Font = new System.Drawing.Font("Poppins", 8, System.Drawing.FontStyle.Regular);

                Console.WriteLine($"Added CheckBox with Name: {checkBox.Text}");
                flowLayoutPanel1.Controls.Add(checkBox);
            }

        }
        private bool isToggled = false;
        private void roundedButtonFilter_Click(object sender, EventArgs e)
        {
            
            isToggled = !isToggled;

            
            if (isToggled)
            {
                panelFilterHandler.Visible = true;
                panelFilterHandler.BringToFront();
            }
            else
            {
                panelFilterHandler.Visible = false;
                panelFilterHandler.SendToBack();
            }
        }

        private void roundedButtonSaveAsPanel_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(panelMainReport.Width, panelMainReport.Height);
            panelMainReport.DrawToBitmap(bitmap, new Rectangle(0, 0, panelMainReport.Width, panelMainReport.Height));


            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save As Image";
                saveFileDialog.ShowDialog();

            
                if (saveFileDialog.FileName != "")
                {
                    
                    string fileExtension = Path.GetExtension(saveFileDialog.FileName);

              
                    switch (fileExtension.ToLower())
                    {
                        case ".png":
                            bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                            break;
                        case ".jpg":
                            bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                            break;
                        case ".bmp":
                            bitmap.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                            break;
                        default:
                         
                            break;
                    }
                }
            }


            bitmap.Dispose();
        }

        private void roundedButtonPrintPanel_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(panelMainReport.Width, panelMainReport.Height);
            panelMainReport.DrawToBitmap(bitmap, new Rectangle(0, 0, panelMainReport.Width, panelMainReport.Height));
            e.Graphics.DrawImage(bitmap, e.PageBounds);
        }

        private void checkBoxNonServiceable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNonServiceable.Checked)
            {

                checkBoxServiceable.Checked = false;
            }
        }

        private void checkBoxServiceable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxServiceable.Checked)
            {
              
                checkBoxNonServiceable.Checked = false;
            }
        }
    }
}
