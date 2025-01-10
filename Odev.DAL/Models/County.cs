using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class County : BaseModel
    {
        public Guid CountyCityId { get; set; }
        public string CountyLatitude { get; set; }
        public string CountyLongtitude { get; set; }
        public string CountyName { get; set; }
        public int CountyCode { get; set; }

        public int DisplayOrder { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
