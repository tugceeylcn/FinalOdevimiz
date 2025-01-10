using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class User : BaseModel
    {
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastname { get; set; }
        public DateTime? UserLastvisitDate { get; set; }
        public string UserPassword { get; set; }
        public string UserPasswordSalt { get; set; }
    }
}
