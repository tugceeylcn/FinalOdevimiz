using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class SiteSetting : BaseModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Adres { get; set; }
        public string Logo { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Maps { get; set; }
    }
}
