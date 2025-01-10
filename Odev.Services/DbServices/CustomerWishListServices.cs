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
    public class CustomerWishListServices : BaseServices
    {
        private readonly OdevRepository<CustomerWishList> _repository;

        public CustomerWishListServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<CustomerWishList>(unitOfWork);
        }

        public void Add(CustomerWishListViewModel viewModel)
        {
            _repository.Add(new CustomerWishList
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                CustomerId = viewModel.CustomerId,
                Id = Guid.NewGuid(),
                ProductId = viewModel.ProductId
            });
        }

        public CustomerWishListViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new CustomerWishListViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CustomerId = result.CustomerId,
                ProductId = result.ProductId,
                CreatedUserId = result.CreatedUserId,
                ProductCategoryName = result.Product.CategoryInfo.CategoryName,
                ProductImage = result.Product.ProductCoverImage,
                ProductName = result.Product.ProductName,
                ProductPrice = result.Product.ProductPrice
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<CustomerWishListViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new CustomerWishListViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CustomerId = x.CustomerId,
                    ProductId = x.ProductId,
                    CreatedUserId = x.CreatedUserId,
                    ProductCategoryName = x.Product.CategoryInfo.CategoryName,
                    ProductImage = x.Product.ProductCoverImage,
                    ProductName = x.Product.ProductName,
                    ProductPrice = x.Product.ProductPrice
                });
        }

        public IQueryable<CustomerWishListViewModel> GetAllByCustomerId(Guid customerId)
        {
            return _repository.GetList()
                .Where(x => x.CustomerId == customerId)
                .Select(x => new CustomerWishListViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CustomerId = x.CustomerId,
                    ProductId = x.ProductId,
                    CreatedUserId = x.CreatedUserId,
                    ProductCategoryName = x.Product.CategoryInfo.CategoryName,
                    ProductImage = x.Product.ProductCoverImage,
                    ProductName = x.Product.ProductName,
                    ProductPrice = x.Product.ProductPrice
                });
        }

        public void Update(CustomerWishListViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.IsActive = viewModel.IsActive;
            result.UpdatedUserId = viewModel.UpdatedUserId;

            _repository.Update(result);
        }
    }
}
