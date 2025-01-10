using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class UserTypeViewModel : BaseViewModel
    {
        [Display(Name = "Ad : ")]
        public string Title { get; set; }

        [Display(Name = "Genel Sayfa : ")]
        public bool GeneralPageTransactions { get; set; }

        [Display(Name = "Genel Sayfa (Ekle/Sil/Güncelle) : ")]
        public bool SubGeneralPageTransactions { get; set; }

        [Display(Name = "Kurumsal Kimlikler : ")]
        public bool IdentityTransactions { get; set; }

        [Display(Name = "Kurumsal Kimlik (Ekle/Sil/Güncelle) : ")]
        public bool SubIdentityTransactions { get; set; }

        [Display(Name = "Haberler : ")]
        public bool NewsTransactions { get; set; }

        [Display(Name = "Haber (Ekle/Sil/Güncelle) : ")]
        public bool SubNewsTransactions { get; set; }

        [Display(Name = "İletişim Ayarları : ")]
        public bool SiteSettingTransactions { get; set; }

        [Display(Name = "İletişim Ayarı (Ekle/Sil/Güncelle) : ")]
        public bool SubSiteSettingTransactions { get; set; }

        [Display(Name = "Sliderlar : ")]
        public bool SliderTransactions { get; set; }

        [Display(Name = "Slider (Ekle/Sil/Güncelle) : ")]
        public bool SubSliderTransactions { get; set; }

        [Display(Name = "Bülten Üyeleri : ")]
        public bool SubscribeMemberTransactions { get; set; }

        [Display(Name = "Bülten Üyesi (Sil) : ")]
        public bool SubSubscribeMemberTransactions { get; set; }

        [Display(Name = "Kullanıcılar : ")]
        public bool UsersTransactions { get; set; }

        [Display(Name = "Kullanıcı (Ekle/Sil/Güncelle) : ")]
        public bool SubUsersTransactions { get; set; }

        [Display(Name = "Kullanıcı Tipleri : ")]
        public bool UserTypeTransactions { get; set; }

        [Display(Name = "Kullanıcı Tipleri (Ekle/Sil/Güncelle) : ")]
        public bool SubUserTypeTransactions { get; set; }

        [Display(Name = "Şehir Ayarları : ")]
        public bool CityTransactions { get; set; }

        [Display(Name = "Şehir Ayarı (Ekle/Sil/Güncelle) : ")]
        public bool SubCityTransactions { get; set; }

        [Display(Name = "Kategoriler : ")]
        public bool CategoryTransactions { get; set; }

        [Display(Name = "Kategoriler (Ekle/Sil/Güncelle) : ")]
        public bool SubCategoryTransactions { get; set; }

        [Display(Name = "Çözüm Ortakları : ")]
        public bool SolutionPartnersTransactions { get; set; }

        [Display(Name = "Çözüm Ortakları (Ekle/Sil/Güncelle) : ")]
        public bool SubSolutionPartnersTransactions { get; set; }

        [Display(Name = "Blog : ")]
        public bool BlogTransactions { get; set; }

        [Display(Name = "Blog (Ekle/Sil/Güncelle) : ")]
        public bool SubBlogTransactions { get; set; }

        [Display(Name = "Site Ayarları : ")]
        public bool SettingTransactions { get; set; }

        [Display(Name = "Site Ayarı (Ekle/Sil/Güncelle) : ")]
        public bool SubSettingTransactions { get; set; }

        [Display(Name = "Renk Ayarları : ")]
        public bool ColorTransactions { get; set; }

        [Display(Name = "Renk Ayarı (Ekle/Sil/Güncelle) : ")]
        public bool SubColorTransactions { get; set; }

        [Display(Name = "Ürün Ayarları : ")]
        public bool ProductTransactions { get; set; }

        [Display(Name = "Ürün Ayarı (Ekle/Sil/Güncelle) : ")]
        public bool SubProductTransactions { get; set; }

        [Display(Name = "Blog Galeri : ")]
        public bool BlogGalleryTransactions { get; set; }

        [Display(Name = "Blog Galeri (Ekle/Sil/Güncelle) : ")]
        public bool SubBlogGalleryTransactions { get; set; }

        [Display(Name = "Sipariş İşlemleri : ")]
        public bool OrderTransactions { get; set; }

        [Display(Name = "Sipariş (Sil/Güncelle) : ")]
        public bool SubOrderTransactions { get; set; }
    }
}
