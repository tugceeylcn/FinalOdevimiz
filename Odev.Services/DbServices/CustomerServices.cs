using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.Helpers;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Services.DbServices
{
    public class CustomerServices : BaseServices
    {
        private readonly OdevRepository<Customers> _repository;
        public CustomerServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Customers>(unitOfWork);
        }

        public void Add(CustomersViewModel viewModel)
        {
            _repository.Add(new Customers
            {
                CreatedDateTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Language = viewModel.Language,
                CustomerEmail = viewModel.CustomerEmail,
                CustomerBirthDate = viewModel.CustomerBirthDate,
                CustomerEmailIsValidated = viewModel.CustomerEmailIsValidated,
                CustomerEmailValidatedDate = viewModel.CustomerEmailValidatedDate,
                CustomerFirstName = viewModel.CustomerFirstName,
                CustomerFirstOrderDate = viewModel.CustomerFirstOrderDate,
                CustomerGenderId = viewModel.CustomerGenderId,
                CustomerIdentityNumber = viewModel.CustomerIdentityNumber,
                CustomerLastBillingAddressId = viewModel.CustomerLastBillingAddressId,
                CustomerLastIpAddress = viewModel.CustomerLastIpAddress,
                CustomerLastName = viewModel.CustomerLastName,
                CustomerLastShippingAddressId = viewModel.CustomerLastShippingAddressId,
                CustomerOrderTotal = viewModel.CustomerOrderTotal,
                CustomerPassword = viewModel.CustomerPassword,
                CustomerPasswordSalt = viewModel.CustomerPasswordSalt,
                CustomerPhone = viewModel.CustomerPhone,
                CustomerRegisterDate = viewModel.CustomerRegisterDate,
                CustomerTypeId = viewModel.CustomerTypeId,
                LastChangePasswordDate = viewModel.LastChangePasswordDate,
                CustomerPhoneIsValidated = viewModel.CustomerPhoneIsValidated,
                CustomerPhoneValidatedDate = viewModel.CustomerPhoneValidatedDate,
                Id = Guid.NewGuid()
            });
        }

        public CustomersViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new CustomersViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                CreatedUserId = result.CreatedUserId,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CustomerEmail = result.CustomerEmail,
                CustomerBirthDate = result.CustomerBirthDate,
                CustomerEmailIsValidated = result.CustomerEmailIsValidated,
                CustomerEmailValidatedDate = result.CustomerEmailValidatedDate,
                CustomerFirstName = result.CustomerFirstName,
                CustomerFirstOrderDate = result.CustomerFirstOrderDate,
                CustomerGenderId = result.CustomerGenderId,
                CustomerIdentityNumber = result.CustomerIdentityNumber,
                CustomerLastBillingAddressId = result.CustomerLastBillingAddressId,
                CustomerLastIpAddress = result.CustomerLastIpAddress,
                CustomerLastName = result.CustomerLastName,
                CustomerLastShippingAddressId = result.CustomerLastShippingAddressId,
                CustomerOrderTotal = result.CustomerOrderTotal,
                CustomerPassword = result.CustomerPassword,
                CustomerPasswordSalt = result.CustomerPasswordSalt,
                CustomerPhone = result.CustomerPhone,
                CustomerRegisterDate = result.CustomerRegisterDate,
                CustomerTypeId = result.CustomerTypeId,
                LastChangePasswordDate = result.LastChangePasswordDate,
                CustomerPhoneIsValidated = result.CustomerPhoneIsValidated,
                CustomerPhoneValidatedDate = result.CustomerPhoneValidatedDate
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<CustomersViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new CustomersViewModel
                {
                    Id = x.Id,
                    UpdatedUserId = x.UpdatedUserId,
                    UpdatedDateTime = x.UpdatedDateTime,
                    IsDeleted = x.IsDeleted,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    CreatedDateTime = x.CreatedDateTime,
                    Language = x.Language,
                    CustomerEmail = x.CustomerEmail,
                    CustomerBirthDate = x.CustomerBirthDate,
                    CustomerEmailIsValidated = x.CustomerEmailIsValidated,
                    CustomerEmailValidatedDate = x.CustomerEmailValidatedDate,
                    CustomerFirstName = x.CustomerFirstName,
                    CustomerFirstOrderDate = x.CustomerFirstOrderDate,
                    CustomerGenderId = x.CustomerGenderId,
                    CustomerIdentityNumber = x.CustomerIdentityNumber,
                    CustomerLastBillingAddressId = x.CustomerLastBillingAddressId,
                    CustomerLastIpAddress = x.CustomerLastIpAddress,
                    CustomerLastName = x.CustomerLastName,
                    CustomerLastShippingAddressId = x.CustomerLastShippingAddressId,
                    CustomerOrderTotal = x.CustomerOrderTotal,
                    CustomerPassword = x.CustomerPassword,
                    CustomerPasswordSalt = x.CustomerPasswordSalt,
                    CustomerPhone = x.CustomerPhone,
                    CustomerRegisterDate = x.CustomerRegisterDate,
                    CustomerTypeId = x.CustomerTypeId,
                    LastChangePasswordDate = x.LastChangePasswordDate,
                    CustomerPhoneValidatedDate = x.CustomerPhoneValidatedDate,
                    CustomerPhoneIsValidated = x.CustomerPhoneIsValidated
                });
        }

        public void Update(CustomersViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.CustomerEmail = viewModel.CustomerEmail;
            result.CustomerBirthDate = viewModel.CustomerBirthDate;
            result.CustomerEmailIsValidated = viewModel.CustomerEmailIsValidated;
            result.CustomerEmailValidatedDate = viewModel.CustomerEmailValidatedDate;
            result.CustomerFirstName = viewModel.CustomerFirstName;
            result.CustomerFirstOrderDate = viewModel.CustomerFirstOrderDate;
            result.CustomerGenderId = viewModel.CustomerGenderId;
            result.CustomerIdentityNumber = viewModel.CustomerIdentityNumber;
            result.CustomerLastBillingAddressId = viewModel.CustomerLastBillingAddressId;
            result.CustomerLastIpAddress = viewModel.CustomerLastIpAddress;
            result.CustomerLastName = viewModel.CustomerLastName;
            result.CustomerLastShippingAddressId = viewModel.CustomerLastShippingAddressId;
            result.CustomerOrderTotal = viewModel.CustomerOrderTotal;
            result.CustomerPassword = viewModel.CustomerPassword;
            result.CustomerPasswordSalt = viewModel.CustomerPasswordSalt;
            result.CustomerPhone = viewModel.CustomerPhone;
            result.CustomerRegisterDate = viewModel.CustomerRegisterDate;
            result.CustomerTypeId = viewModel.CustomerTypeId;
            result.LastChangePasswordDate = viewModel.LastChangePasswordDate;
            result.CustomerPhoneValidatedDate = viewModel.CustomerPhoneValidatedDate;
            result.CustomerPhoneIsValidated = viewModel.CustomerPhoneIsValidated;

            _repository.Update(result);
        }
        public CustomersViewModel SignIn(CustomersViewModel viewModel)
        {
            var model = _repository.Get(x => x.IsActive && x.CustomerEmail == viewModel.CustomerEmail && x.CustomerPassword == viewModel.CustomerPassword);

            if (model == null)
            {
                return null;
            }

            return new CustomersViewModel
            {
                Id = model.Id,
                CustomerFirstName = model.CustomerFirstName,
                CustomerLastName = model.CustomerLastName,
                CustomerEmail = model.CustomerEmail,
                CustomerPhone = model.CustomerPhone,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
            };
        }
    }
}
