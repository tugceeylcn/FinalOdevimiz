using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class SolutionPartners : BaseModel
    {
        public string PartnerName { get; set; }

        public string PartnerImage { get; set; }

        public int DisplayOrder { get; set; }

        public string Slug { get; set; }
    }
}
