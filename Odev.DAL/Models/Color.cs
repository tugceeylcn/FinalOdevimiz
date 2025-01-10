using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Color : BaseModel
    {
        public string ColorName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
