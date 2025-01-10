using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Users : BaseModel
    {

        #region -Property

        //Ad Soyad
        public string NameSurname { get; set; }

        //Email
        public string Email { get; set; }

        //Telefon
        public string Phone { get; set; }

        //Şifre
        public string Pwd { get; set; }

        //Kullanıcı Türü
        public Guid UserTypeId { get; set; }

        #endregion


        #region -Navigation

        public UserType UserType { get; set; }

        #endregion
    }
}