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
    public class ProductServices : BaseServices
    {
        private readonly OdevRepository<Product> _repository;
        public ProductServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Product>(unitOfWork);
        }

        public void Add(ProductViewModel viewModel)
        {
            _repository.Add(new Product
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                ProductName = viewModel.ProductName,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                DisplayOrder = viewModel.DisplayOrder,
                CategoryId = viewModel.CategoryId,
                ColorId = viewModel.ColorId,
                ProductCoverImage = viewModel.ProductCoverImage,
                ProductDetail = viewModel.ProductDetail,
                ProductFirstPrice = viewModel.ProductFirstPrice,
                ProductPrice = Convert.ToDecimal(viewModel.ProductPrice),
                ProductStock = viewModel.ProductStock,
                ProductTickets = viewModel.ProductTickets,
                SkuId = viewModel.SkuId,
                TotalSaleCount = viewModel.TotalSaleCount,
                IsPopular = viewModel.IsPopular,
                Slug = viewModel.ProductName.ToSeoUrl(),
                AttributeFirst = viewModel.AttributeFirst,
                AttributeTwo = viewModel.AttributeTwo
            });
        }

        public ProductViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new ProductViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                ProductName = result.ProductName,
                CreatedUserId = result.CreatedUserId,
                DisplayOrder = result.DisplayOrder,
                TotalSaleCount = result.TotalSaleCount,
                SkuId = result.SkuId,
                ProductTickets = result.ProductTickets,
                ProductStock = result.ProductStock,
                ProductPrice = result.ProductPrice,
                ProductFirstPrice = result.ProductFirstPrice,
                ProductDetail = result.ProductDetail,
                CategoryId = result.CategoryId,
                ColorId = result.ColorId,
                ProductCoverImage = result.ProductCoverImage,
                CategoryName = result.CategoryInfo.CategoryName,
                ColorName = result.ColorInfo?.ColorName,
                IsPopular = result.IsPopular,
                Slug = result.Slug,
                AttributeFirst = result.AttributeFirst,
                AttributeTwo = result.AttributeTwo
            };
        }

        public IQueryable<ProductViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    ProductName = x.ProductName,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    CategoryId = x.CategoryId,
                    ProductCoverImage = x.ProductCoverImage,
                    ColorId = x.ColorId,
                    ProductDetail = x.ProductDetail,
                    ProductFirstPrice = x.ProductFirstPrice,
                    ProductPrice = x.ProductPrice,
                    ProductStock = x.ProductStock,
                    ProductTickets = x.ProductTickets,
                    SkuId = x.SkuId,
                    TotalSaleCount = x.TotalSaleCount,
                    CategoryName = x.CategoryInfo.CategoryName,
                    ColorName = x.ColorInfo.ColorName,
                    IsPopular = x.IsPopular,
                    Slug = x.Slug,
                    AttributeFirst = x.AttributeFirst,
                    AttributeTwo = x.AttributeTwo
                });
        }

        public IQueryable<ProductViewModel> GetAllByFilter(Guid categoryId)
        {
            return _repository.GetList()
                .Where(x => x.CategoryId == categoryId)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    ProductName = x.ProductName,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    CategoryId = x.CategoryId,
                    ProductCoverImage = x.ProductCoverImage,
                    ColorId = x.ColorId,
                    ProductDetail = x.ProductDetail,
                    ProductFirstPrice = x.ProductFirstPrice,
                    ProductPrice = x.ProductPrice,
                    ProductStock = x.ProductStock,
                    ProductTickets = x.ProductTickets,
                    SkuId = x.SkuId,
                    TotalSaleCount = x.TotalSaleCount,
                    CategoryName = x.CategoryInfo.CategoryName,
                    ColorName = x.ColorInfo.ColorName,
                    IsPopular = x.IsPopular,
                    Slug = x.Slug,
                    AttributeFirst = x.AttributeFirst,
                    AttributeTwo = x.AttributeTwo
                });
        }

        public IQueryable<ProductViewModel> GetAllByProductName(string productText)
        {
            return _repository.GetList()
                .Where(x => x.ProductName.ToLower().Contains(productText.ToLower()))
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    ProductName = x.ProductName,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    CategoryId = x.CategoryId,
                    ProductCoverImage = x.ProductCoverImage,
                    ColorId = x.ColorId,
                    ProductDetail = x.ProductDetail,
                    ProductFirstPrice = x.ProductFirstPrice,
                    ProductPrice = x.ProductPrice,
                    ProductStock = x.ProductStock,
                    ProductTickets = x.ProductTickets,
                    SkuId = x.SkuId,
                    TotalSaleCount = x.TotalSaleCount,
                    CategoryName = x.CategoryInfo.CategoryName,
                    ColorName = x.ColorInfo.ColorName,
                    IsPopular = x.IsPopular,
                    Slug = x.Slug,
                    AttributeFirst = x.AttributeFirst,
                    AttributeTwo = x.AttributeTwo
                });
        }

        public int NewDisplayOrder()
        {
            return _repository.GetList().Where(x => x.IsActive && !x.IsDeleted).Max(x => x.DisplayOrder) + 1;
        }

        public decimal MinProductPrice()
        {
            return _repository.GetList().Where(x => x.IsActive && !x.IsDeleted).Min(x => x.ProductPrice);
        }

        public decimal MaxProductPrice()
        {
            return _repository.GetList().Where(x => x.IsActive && !x.IsDeleted).Max(x => x.ProductPrice);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(ProductViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.ProductName = viewModel.ProductName;
            result.CategoryId = viewModel.CategoryId;
            result.ColorId = viewModel.ColorId;
            result.ProductDetail = viewModel.ProductDetail;
            result.ProductFirstPrice = viewModel.ProductFirstPrice;
            result.ProductPrice = Convert.ToDecimal(viewModel.ProductPrice);
            result.ProductStock = viewModel.ProductStock;
            result.ProductTickets = viewModel.ProductTickets;
            result.SkuId = viewModel.SkuId;
            result.TotalSaleCount = viewModel.TotalSaleCount;
            result.IsPopular = viewModel.IsPopular;
            result.Slug = viewModel.Slug.ToSeoUrl();
            result.AttributeFirst = viewModel.AttributeFirst;
            result.AttributeTwo = viewModel.AttributeTwo;

            if (viewModel.ProductCoverImage != null)
                result.ProductCoverImage = viewModel.ProductCoverImage;

            _repository.Update(result);
        }
    }
}
