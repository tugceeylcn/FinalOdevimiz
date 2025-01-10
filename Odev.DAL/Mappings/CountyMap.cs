using Odev.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Mappings
{
    public class CountyMap : BaseMap<County>
    {
        public CountyMap()
        {
            ToTable("tblCounty");
        }
    }
}
