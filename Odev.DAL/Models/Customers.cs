using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Customers : BaseModel
    {
        private ICollection<Order> customerOrders;

        #region - Properties

        public DateTime? CustomerBirthDate { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public Guid CustomerGenderId { get; set; }

        public string CustomerIdentityNumber { get; set; }

        public Guid? CustomerLastBillingAddressId { get; set; }

        public Guid? CustomerLastShippingAddressId { get; set; }

        public string CustomerLastIpAddress { get; set; }

        public string CustomerPassword { get; set; }

        public string CustomerPasswordSalt { get; set; }

        public string CustomerPhone { get; set; }

        public DateTime? CustomerRegisterDate { get; set; }

        public DateTime? LastChangePasswordDate { get; set; }

        public Guid? CustomerTypeId { get; set; }

        public DateTime? CustomerFirstOrderDate { get; set; }

        public bool CustomerEmailIsValidated { get; set; }

        public DateTime? CustomerEmailValidatedDate { get; set; }

        public decimal? CustomerOrderTotal { get; set; }

        public bool CustomerPhoneIsValidated { get; set; }

        public DateTime? CustomerPhoneValidatedDate { get; set; }

        public virtual ICollection<Order> CustomerOrders
        {
            get
            {
                return this.customerOrders ?? (this.customerOrders = new Collection<Order>());
            }

            set
            {
                this.customerOrders = value;
            }
        }

        #endregion
    }
}
