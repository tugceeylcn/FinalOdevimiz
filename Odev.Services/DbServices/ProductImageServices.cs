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
    public class ProductImageServices : BaseServices
    {
        private readonly OdevRepository<ProductImage> _repository;
        public ProductImageServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<ProductImage>(unitOfWork);
        }

        public void Add(ProductImageViewModel viewModel)
        {
            _repository.Add(new ProductImage
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                DisplayOrder = viewModel.DisplayOrder,
                ImageUrl = viewModel.ImageUrl,
                ProductId = viewModel.ProductId
            });
        }

        public ProductImageViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new ProductImageViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                DisplayOrder = result.DisplayOrder,
                ImageUrl = result.ImageUrl,
                ProductId = result.ProductId
            };
        }

        public IQueryable<ProductImageViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new ProductImageViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    ProductId = x.ProductId,
                    ImageUrl = x.ImageUrl
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(ProductImageViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.ProductId = viewModel.ProductId;

            if (!string.IsNullOrEmpty(viewModel.ImageUrl))
            {
                result.ImageUrl = viewModel.ImageUrl;
            }

            _repository.Update(result);
        }
    }
}
