using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Enums
{
    public enum PageName : byte
    {
        [Display(Name = "Hakkımızda")]
        About = 1,

        [Display(Name = "İletişim")]
        Contact = 2,

        [Display(Name = "Yardım")]
        Help = 3,

        [Display(Name = "Sıkça Sorulan Sorular")]
        FrequentlyAskedQuestions = 4,

        [Display(Name = "Kariyer")]
        Career = 5,

        [Display(Name = "Mesafeli Satış Sözleşmesi")]
        DistanceSellingAgreement = 6,

        [Display(Name = "KVKK Aydınlatma Metni")]
        Kvkk = 7,

        [Display(Name = "İptal ve İade Koşulları")]
        CancelReturn = 8,

        [Display(Name = "Çerez Politikası")]
        CookiePolicy = 9,

        [Display(Name = "Üyelik Sözleşmesi")]
        MembershipAgreement = 10,

        [Display(Name = "Vizyon")]
        Vision = 11,

        [Display(Name = "Misyon")]
        Mission = 12,

        [Display(Name = "Gizlilik Politikası")]
        PrivacyPolicy = 13
    }
}
