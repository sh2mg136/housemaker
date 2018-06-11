using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace themesite.Helpers
{
    public class EmailHelper
    {

        public SendMailResponse SendEmail(string toAddress, string fromAddress, string subject, string message)
        {

            SendMailResponse response = new SendMailResponse()
            {
                HasError = false,
                ErrorMessage = string.Empty
            };

            string userName = WebConfigurationManager.AppSettings["PFUserName"];

            using (var mail = new MailMessage())
            {
                const string email = "admin@redexsrv.ru";
                const string password = "Mwoo33#8";

                var loginInfo = new NetworkCredential(email, password);

                mail.From = new MailAddress(fromAddress);
                mail.To.Add(new MailAddress(toAddress));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                try
                {
                    using (var smtpClient = new SmtpClient("redexsrv.ru", 25))
                    {
                        smtpClient.EnableSsl = false;
                        smtpClient.UseDefaultCredentials = true;
                        // smtpClient.Credentials = loginInfo;
                        smtpClient.Send(mail);
                    }
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    response.HasError = true;
                    response.ErrorMessage = string.Empty;

                    foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
                    {

                        var status = t.StatusCode;
                        if (status == SmtpStatusCode.MailboxBusy ||
                            status == SmtpStatusCode.MailboxUnavailable)
                        {
                            // Response.Write("Delivery failed - retrying in 5 seconds.");
                            System.Threading.Thread.Sleep(5000);
                            //resend
                            //smtpClient.Send(message);
                        }
                        else
                        {
                            // Response.Write("Failed to deliver message to {0}", t.FailedRecipient);
                        }

                        response.ErrorMessage += string.Format("Failed to deliver message to {0} <br />", t.FailedRecipient);

                    }
                }
                catch (SmtpException se)
                {
                    response.HasError = true;
                    response.ErrorMessage = se.Message;
                    // handle exception here
                    // Response.Write(Se.ToString());
                }
                catch (Exception ex)
                {
                    response.HasError = true;
                    response.ErrorMessage = ex.Message;
                    // Response.Write(ex.ToString());
                }
                finally
                {
                    mail.Dispose();
                }
            }

            return response;
        }


        public class SendMailResponse
        {
            public bool HasError { get; set; }
            public string ErrorMessage { get; set; }
        }

    }
}