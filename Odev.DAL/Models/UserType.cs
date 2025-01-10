using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class UserType : BaseModel
    {
        public string Title { get; set; }
        public bool GeneralPageTransactions { get; set; }
        public bool SubGeneralPageTransactions { get; set; }
        public bool IdentityTransactions { get; set; }
        public bool SubIdentityTransactions { get; set; }
        public bool NewsTransactions { get; set; }
        public bool SubNewsTransactions { get; set; }
        public bool SiteSettingTransactions { get; set; }
        public bool SubSiteSettingTransactions { get; set; }

        public bool SliderTransactions { get; set; }

        public bool SubSliderTransactions { get; set; }

        public bool SubscribeMemberTransactions { get; set; }

        public bool SubSubscribeMemberTransactions { get; set; }

        public bool UsersTransactions { get; set; }

        public bool SubUsersTransactions { get; set; }

        public bool UserTypeTransactions { get; set; }

        public bool SubUserTypeTransactions { get; set; }

        public bool CityTransactions { get; set; }

        public bool SubCityTransactions { get; set; }

        public bool CategoryTransactions { get; set; }

        public bool SubCategoryTransactions { get; set; }

        public bool SolutionPartnersTransactions { get; set; }

        public bool SubSolutionPartnersTransactions { get; set; }

        public bool BlogTransactions { get; set; }

        public bool SubBlogTransactions { get; set; }

        public bool SettingTransactions { get; set; }

        public bool SubSettingTransactions { get; set; }

        public bool ColorTransactions { get; set; }

        public bool SubColorTransactions { get; set; }

        public bool ProductTransactions { get; set; }

        public bool SubProductTransactions { get; set; }

        public bool BlogGalleryTransactions { get; set; }

        public bool SubBlogGalleryTransactions { get; set; }

        public bool OrderTransactions { get; set; }

        public bool SubOrderTransactions { get; set; }
    }
}
