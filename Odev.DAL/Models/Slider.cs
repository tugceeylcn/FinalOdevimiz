using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Slider : BaseModel
    {
        public string Image { get; set; }

        public string TextOne { get; set; }

        public string TextTwo { get; set; }

        public string TextThree { get; set; }

        public bool IsSale { get; set; }

        public int DisplayOrder { get; set; }

        public Guid ProductId { get; set; }
    }
}
