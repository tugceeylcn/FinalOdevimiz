using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Street : BaseModel
    {
        public virtual District StreetDistrict { get; set; }
        public Guid StreetDistrictId { get; set; }
        public string StreetLatitude { get; set; }
        public string StreetLongtitude { get; set; }
        public string StreetName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
