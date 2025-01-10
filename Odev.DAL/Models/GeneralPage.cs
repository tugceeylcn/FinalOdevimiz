using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class GeneralPage : BaseModel
    {
        public string Title { get; set; }// Başlık
        public string Content { get; set; }//İçerik
        public string Image { get; set; }//Resim

        public PageName Page { get; set; }
    }
}
