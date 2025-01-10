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
    public class SubscribeMemberServices : BaseServices
    {
        private readonly OdevRepository<SubscribeMember> _repository;
        public SubscribeMemberServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<SubscribeMember>(unitOfWork);
        }

        public void Add(SubscribeMemberViewModel viewModel)
        {
            _repository.Add(new SubscribeMember
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                Email = viewModel.Email,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid()
            });
        }

        public SubscribeMemberViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new SubscribeMemberViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                Email = result.Email,
                CreatedUserId = result.CreatedUserId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<SubscribeMemberViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SubscribeMemberViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    Email = x.Email,
                    CreatedUserId = x.CreatedUserId
                });
        }

        public void Update(SubscribeMemberViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.IsActive = viewModel.IsActive;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.Email = viewModel.Email;

            _repository.Update(result);
        }
    }
}
