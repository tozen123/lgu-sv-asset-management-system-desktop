using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using LGU_SV_Asset_Management_Sytem.Other_Tools;

namespace LGU_SV_Asset_Management_Sytem.DialogBoxes
{
    public partial class ReportIssueDialogBox : Form
    {
        string _name;
        private ProgressDialog progressDialog;

        public ReportIssueDialogBox(string name)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            _name = name;
          
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            using(UploadImageDialogBox upload = new UploadImageDialogBox())
            {
                if (upload.ShowDialog() == DialogResult.OK)
                {
                    byte[] _imagedata = upload.imageByte;
                    if (_imagedata != null)
                    {
                        label7.Text = upload.path;
                        pictureBoxAttachments.Image = Utilities.ConvertByteArrayToImage(_imagedata);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
                progressDialog = new ProgressDialog();

                try
                {
                    // Get values from textboxes
                    string subject = $"LGU-SV:AMS IssueReport ({_name})";
                    string body = richTextBoxDesc.Text;

                    // Set up the SMTP client
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("team.amsdevs@gmail.com", "ysvo dbvg dqch pnwl"),
                        EnableSsl = true,
                    };

                    // Create and send the email
                    MailMessage mailMessage = new MailMessage("team.amsdevs@gmail.com", textBoxEmail.Text, subject, body);

                    if (string.IsNullOrEmpty(label7.Text))
                    {
                        if (label7.Text != "-")
                        {
                            Attachment attachment = new Attachment(label7.Text);
                            mailMessage.Attachments.Add(attachment);
                        }

                    }

                    progressDialog.Show();
                    await smtpClient.SendMailAsync(mailMessage);

                    await SimulateEmailSendingAsync(25, "Preparing to send email...");
                    await SimulateEmailSendingAsync(50, "Uploading attachments...");
                    await SimulateEmailSendingAsync(75, "Sending email...");
                    await SimulateEmailSendingAsync(100, "Complete");


                    MessagePrompt("Email sent successfully!");


                }
                catch (Exception ex)
                {
                    MessagePrompt($"Error Occured, while trying to send email. Please check your Internet Connection. {ex.Message}");
                }
                finally
                {
                    progressDialog.Close();
                }
                 
        }

        private void roundedButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessagePrompt(string message)
        {
            using (DialogBoxes.MessagePromptDialogBox prompt = new DialogBoxes.MessagePromptDialogBox())
            {
                prompt.SetMessage(message);
                prompt.ShowDialog();
                if(prompt.GetResult() == DialogResult.OK)
                {
                    this.Close();
                }
            }
            
        }
        private async Task SimulateEmailSendingAsync(int progress, string message)
        {
            await Task.Delay(1000);
            progressDialog.UpdateProgress(message, progress);
        }
    }
}
