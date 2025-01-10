using Odev.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Mappings
{
    public class SiteSettingMap : BaseMap<SiteSetting>
    {
        public SiteSettingMap()
        {
            ToTable("SiteSettings");

            Property(x => x.Logo)
                .HasMaxLength(350)
                .IsRequired();
        }
    }
}
