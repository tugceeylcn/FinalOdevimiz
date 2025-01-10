using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Cargo : BaseModel
    {
        public string CargoName { get; set; }

        public string CargoFirmLogo { get; set; }

        public string CargoIncTax { get; set; }

        public string CargoWebSite { get; set; }

        public string TrackingUrl { get; set; }
    }
}
