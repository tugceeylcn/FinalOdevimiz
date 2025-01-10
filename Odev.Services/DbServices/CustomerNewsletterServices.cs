using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Services.DbServices
{
    public class CustomerNewsletterServices : BaseServices
    {
        private readonly OdevRepository<CustomerNewsletter> _repository;
        public CustomerNewsletterServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<CustomerNewsletter>(unitOfWork);
        }

        public void Add(CustomerNewsletterViewModel viewModel)
        {
            _repository.Add(new CustomerNewsletter
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                CallEnabled = viewModel.CallEnabled,
                EmailEnabled = viewModel.EmailEnabled,
                SmsEnabled = viewModel.SmsEnabled,
                CustomerId = viewModel.CustomerId
            });
        }

        public CustomerNewsletterViewModel Get(Guid customerId)
        {
            var result = _repository.Get(x => x.CustomerId == customerId);

            if (result == null)
            {
                return default(CustomerNewsletterViewModel);
            }

            return new CustomerNewsletterViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                SmsEnabled = result.SmsEnabled,
                EmailEnabled = result.EmailEnabled,
                CallEnabled = result.CallEnabled,
                CustomerId = result.CustomerId
            };
        }

        public IQueryable<CustomerNewsletterViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new CustomerNewsletterViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    CallEnabled = x.CallEnabled,
                    EmailEnabled = x.EmailEnabled,
                    SmsEnabled = x.SmsEnabled,
                    CustomerId = x.CustomerId
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(CustomerNewsletterViewModel viewModel)
        {
            var result = _repository.Get(x => x.CustomerId == viewModel.CustomerId);

            if (result == null)
            {
                viewModel.Id = Guid.NewGuid();
                viewModel.IsActive = true;
                viewModel.IsDeleted = false;
                viewModel.CreatedUserId = Domain.Environments.Users.CreatedUserId;
                viewModel.CreatedDateTime = DateTime.Now;
                viewModel.Language = viewModel.Language;
                this.Add(viewModel);

                return;
            }

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.CallEnabled = viewModel.CallEnabled;
            result.EmailEnabled = viewModel.EmailEnabled;
            result.SmsEnabled = viewModel.SmsEnabled;
            result.CustomerId = viewModel.CustomerId;

            _repository.Update(result);
        }
    }
}