using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class UsersViewModel : BaseViewModel
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
        public int UserTypeId { get; set; }

        #endregion


        #region -Navigation

        public UserTypeViewModel UserType { get; set; }

        #endregion
    }
}