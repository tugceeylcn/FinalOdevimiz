using Odev.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Mappings
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseModel
    {
    }
}
