using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Document : BaseModel
    {
        public string Url { get; set; }//Yol
        public string Title { get; set; }//Ad
        public DateTime DocumentDate { get; set; }//Tarihi
        public DocumentCategory DocumentCategory { get; set; }
    }
}
