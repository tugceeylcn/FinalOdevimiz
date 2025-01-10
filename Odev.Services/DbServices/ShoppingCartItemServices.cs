using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.ViewModels;
using System;
using System.Linq;

namespace Odev.Services.DbServices
{
    public class ShoppingCartItemServices : BaseServices
    {
        private readonly OdevRepository<ShoppingCartItem> _repository;
        public ShoppingCartItemServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<ShoppingCartItem>(unitOfWork);
        }

        public void Add(ShoppingCartItemViewModel viewModel)
        {
            _repository.Add(new ShoppingCartItem
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                CampaignCodeKey = viewModel.CampaignCodeKey,
                ColorId = viewModel.ColorId,
                OrderItemDiscount = viewModel.OrderItemDiscount,
                OrderItemPriceInclTax = viewModel.OrderItemPriceInclTax,
                PictureImage = viewModel.PictureImage,
                ProductId = viewModel.ProductId,
                Quantity = viewModel.Quantity,
                ShoppingCartId = viewModel.ShoppingCartId,
                UsedGiftCardPointPriceAmount = viewModel.UsedGiftCardPointPriceAmount,
                ProductTitle = viewModel.ProductTitle,
                ProductSlug = viewModel.ProductSlug,
                ProductCategoryTitle = viewModel.ProductCategoryTitle
            });
        }

        public ShoppingCartItemViewModel Get(Guid id)
        {
            var result = _repository.Get(x => x.Id == id);

            return new ShoppingCartItemViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                CampaignCodeKey = result.CampaignCodeKey,
                ColorId = result.ColorId,
                OrderItemDiscount = result.OrderItemDiscount,
                OrderItemPriceInclTax = result.OrderItemPriceInclTax,
                PictureImage = result.PictureImage,
                ProductId = result.ProductId,
                Quantity = result.Quantity,
                ShoppingCartId = result.ShoppingCartId,
                UsedGiftCardPointPriceAmount = result.UsedGiftCardPointPriceAmount,
                ProductTitle = result.ProductTitle,
                ProductSlug = result.ProductSlug,
                ProductCategoryTitle = result.ProductCategoryTitle
            };
        }

        public ShoppingCartItemViewModel CheckShoppingCartItemByProduct(Guid productId, Guid colorId, Guid shoppingCartId)
        {
            var result = _repository.Get(x => x.ProductId == productId && x.ColorId == colorId && x.ShoppingCartId == shoppingCartId);

            if (result == null || result == default)
            {
                return default;
            }

            return new ShoppingCartItemViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                CampaignCodeKey = result.CampaignCodeKey,
                ColorId = result.ColorId,
                OrderItemDiscount = result.OrderItemDiscount,
                OrderItemPriceInclTax = result.OrderItemPriceInclTax,
                PictureImage = result.PictureImage,
                ProductId = result.ProductId,
                Quantity = result.Quantity,
                ShoppingCartId = result.ShoppingCartId,
                UsedGiftCardPointPriceAmount = result.UsedGiftCardPointPriceAmount,
                ProductTitle = result.ProductTitle,
                ProductSlug = result.ProductSlug,
                ProductCategoryTitle = result.ProductCategoryTitle
            };
        }

        public IQueryable<ShoppingCartItemViewModel> GetByShoppingCartId(Guid shoppingCartId)
        {
            return _repository.GetList()
                .Where(y => y.ShoppingCartId == shoppingCartId && y.IsActive && !y.IsDeleted)
                .Select(x => new ShoppingCartItemViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    CampaignCodeKey = x.CampaignCodeKey,
                    ColorId = x.ColorId,
                    OrderItemDiscount = x.OrderItemDiscount,
                    OrderItemPriceInclTax = x.OrderItemPriceInclTax,
                    PictureImage = x.PictureImage,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    ShoppingCartId = x.ShoppingCartId,
                    UsedGiftCardPointPriceAmount = x.UsedGiftCardPointPriceAmount,
                    ProductTitle = x.ProductTitle,
                    ProductSlug = x.ProductSlug,
                    ProductCategoryTitle = x.ProductCategoryTitle
                });
        }

        public IQueryable<ShoppingCartItemViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new ShoppingCartItemViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    CampaignCodeKey = x.CampaignCodeKey,
                    ColorId = x.ColorId,
                    OrderItemDiscount = x.OrderItemDiscount,
                    OrderItemPriceInclTax = x.OrderItemPriceInclTax,
                    PictureImage = x.PictureImage,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    ShoppingCartId = x.ShoppingCartId,
                    UsedGiftCardPointPriceAmount = x.UsedGiftCardPointPriceAmount,
                    ProductTitle = x.ProductTitle,
                    ProductSlug = x.ProductSlug,
                    ProductCategoryTitle = x.ProductCategoryTitle
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(ShoppingCartItemViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.CampaignCodeKey = viewModel.CampaignCodeKey;
            result.ColorId = viewModel.ColorId;
            result.OrderItemDiscount = viewModel.OrderItemDiscount;
            result.OrderItemPriceInclTax = viewModel.OrderItemPriceInclTax;
            result.PictureImage = viewModel.PictureImage;
            result.ProductId = viewModel.ProductId;
            result.Quantity = viewModel.Quantity;
            result.ShoppingCartId = viewModel.ShoppingCartId;
            result.UsedGiftCardPointPriceAmount = viewModel.UsedGiftCardPointPriceAmount;
            result.ProductSlug = viewModel.ProductSlug;
            result.ProductCategoryTitle = viewModel.ProductCategoryTitle;

            _repository.Update(result);
        }
    }
}
