using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Odev.DAL.Models
{
    public class Identity : BaseModel
    {
        [AllowHtml]
        public string Content { get; set; }//İçerik
        public string Image { get; set; }//Resim
        public string UrlDocument { get; set; }//Yol
        public DocumentCategory DocumentCategory { get; set; }
    }
}
