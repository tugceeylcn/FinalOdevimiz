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
    public class AttributeServices : BaseServices
    {
        private readonly OdevRepository<DAL.Models.Attribute> _repository;
        public AttributeServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<DAL.Models.Attribute>(unitOfWork);
        }

        public void Add(AttributeViewModel viewModel)
        {
            _repository.Add(new DAL.Models.Attribute
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                AttributeName = viewModel.AttributeName,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                DisplayOrder = viewModel.DisplayOrder
            });
        }

        public AttributeViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new AttributeViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                AttributeName = result.AttributeName,
                CreatedUserId = result.CreatedUserId,
                DisplayOrder = result.DisplayOrder
            };
        }

        public IQueryable<AttributeViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new AttributeViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    AttributeName = x.AttributeName,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(AttributeViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.AttributeName = viewModel.AttributeName;

            _repository.Update(result);
        }
    }
}
