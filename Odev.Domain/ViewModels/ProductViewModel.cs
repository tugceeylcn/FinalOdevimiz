using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        [Display(Name = "Ürün Adı : ")]
        public string ProductName { get; set; }

        [Display(Name = "Ürün Açıklama : ")]
        public string ProductDetail { get; set; }

        [Display(Name = "Kapak Resmi : ")]
        public string ProductCoverImage { get; set; }

        [Display(Name = "Eski Fiyat : ")]
        public decimal ProductFirstPrice { get; set; }

        [Display(Name = "Fiyat : ")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Renk Id : ")]
        public Guid ColorId { get; set; }

        [Display(Name = "Renk Adı : ")]
        public string ColorName { get; set; }

        [Display(Name = "Kategori Id : ")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Kategori Adı : ")]
        public string CategoryName { get; set; }

        [Display(Name = "SKU : ")]
        public string SkuId { get; set; }

        [Display(Name = "Etiketler : ")]
        public string ProductTickets { get; set; }

        [Display(Name = "Stok Sayısı : ")]
        public int ProductStock { get; set; }

        [Display(Name = "Toplam Sipariş Sayısı : ")]
        public int TotalSaleCount { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Popüler: ")]
        public bool IsPopular { get; set; }

        [Display(Name = "Slug : ")]
        public string Slug { get; set; }

        [Display(Name = "İlk Özellik : ")]
        public Guid AttributeFirst { get; set; }

        [Display(Name = "İkinci Özellik : ")]
        public Guid AttributeTwo { get; set; }
    }
}
