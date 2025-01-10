using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Odev.DAL.Models
{
    public class News : BaseModel
    {
        public string Title { get; set; }// Başlık

        public string SubTitle { get; set; }//Alt Başlık

        [AllowHtml]
        public string Text { get; set; }//Metin

        public string PictureUrl { get; set; }//Resim Yolu

        public string Slug { get; set; }

        public DateTime NewsDate { get; set; }//Haber Tarihi

        public int DisplayOrder { get; set; }
    }
}
