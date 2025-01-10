using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Odev.Domain.ViewModels;

namespace Odev.Domain.Helpers
{
    public static class MailHelpers
    {
        /// <summary>
        /// Verilen tüm mail ayarlarını kullanarak mail göndermeye yarar.
        /// </summary>
        /// <param name="receivermail">Alıcı Postası</param>
        /// <param name="subject">Konu</param>
        /// <param name="message">Mesaj</param>
        /// <param name="viewModel">Mail Ayarları</param>
        /// <returns>True veya False Dönecek</returns>
        public static bool Send(string receivermail, string subject, string message, MailSettingViewModel viewModel)
        {
            try
            {
                var sendermail = new MailAddress(viewModel.MailAddress, "");
                var smtp = new SmtpClient
                {
                    Host = viewModel.Host,
                    Port = viewModel.Port,
                    EnableSsl = viewModel.Ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(viewModel.MailAddress, viewModel.Password)
                };

                using (var mess = new MailMessage()
                {
                    From = sendermail,
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = message
                })
                {
                    mess.To.Add(receivermail);
                    if (viewModel.CCMail != null)
                    {
                        mess.CC.Add(viewModel.CCMail);
                    }
                    smtp.Send(mess);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}