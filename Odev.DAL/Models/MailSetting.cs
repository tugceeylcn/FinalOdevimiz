using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class MailSetting : BaseModel
    {
        #region -Properties

        public string Host { get; set; } //Host-Sunucu

        public int Port { get; set; } //Sunucu port

        public string MailAddress { get; set; }  //Gönderici mail adresi

        public string Password { get; set; } //Gönderici mail şifresi

        public bool Ssl { get; set; } //SSL

        public string CCMail { get; set; } //CCMail

        #endregion -Properties
    }
}
