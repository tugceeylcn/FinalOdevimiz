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
    public class ProductAttributeServices : BaseServices
    {
        private readonly OdevRepository<ProductAttribute> _repository;
        public ProductAttributeServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<ProductAttribute>(unitOfWork);
        }

        public void Add(ProductAttributeViewModel viewModel)
        {
            _repository.Add(new ProductAttribute
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                AttributeId = viewModel.AttributeId,
                ProductId = viewModel.ProductId,
                AttributeValue = viewModel.AttributeValue
            });
        }

        public ProductAttributeViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new ProductAttributeViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                AttributeValue = result.AttributeValue,
                AttributeId = result.AttributeId,
                ProductId = result.ProductId,
                AttributeName = result.Attribute.AttributeName,
                ProductName = result.Product.ProductName
            };
        }

        public IQueryable<ProductAttributeViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new ProductAttributeViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    AttributeId = x.AttributeId,
                    ProductId = x.ProductId,
                    AttributeValue = x.AttributeValue,
                    AttributeName = x.Attribute.AttributeName,
                    ProductName = x.Product.ProductName
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(ProductAttributeViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.AttributeId = viewModel.AttributeId;
            result.ProductId = viewModel.ProductId;
            result.AttributeValue = viewModel.AttributeValue;

            _repository.Update(result);
        }
    }
}
