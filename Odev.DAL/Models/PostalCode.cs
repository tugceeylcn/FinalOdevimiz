using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class PostalCode : BaseModel
    {
        public int? RegionId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountyId { get; set; }
        public Guid? DistrictId { get; set; }
        public string PostCode { get; set; }
        public string MaxPostCode { get; set; }

        public int DisplayOrder { get; set; }
    }
}
