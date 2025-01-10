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
    public class OrderItemServices : BaseServices
    {
        private readonly OdevRepository<OrderItem> _repository;
        public OrderItemServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<OrderItem>(unitOfWork);
        }

        public void Add(OrderItemViewModel viewModel)
        {
            _repository.Add(new OrderItem
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                EarndGiftClubPointAmount = viewModel.EarndGiftClubPointAmount,
                GiftCardDetails = viewModel.GiftCardDetails,
                OrderItemDiscount = viewModel.OrderItemDiscount,
                OrderItemFirstPriceInclTax = viewModel.OrderItemFirstPriceInclTax,
                OrderItemOrderId = viewModel.OrderItemOrderId,
                OrderItemOrderStatusId = viewModel.OrderItemOrderStatusId,
                OrderItemPriceInclTax = viewModel.OrderItemPriceInclTax,
                OrderItemQuantity = viewModel.OrderItemQuantity,
                OrderItemRefundAmount = viewModel.OrderItemRefundAmount,
                OrderItemSaleDiscount = viewModel.OrderItemSaleDiscount,
                OrderItemSaleInstallmentPriceInclTax = viewModel.OrderItemSaleInstallmentPriceInclTax,
                OrderItemSalePriceInclTax = viewModel.OrderItemSalePriceInclTax,
                OrderItemSaleRefundAmount = viewModel.OrderItemSaleRefundAmount,
                OrderItemShoppingCartItemId = viewModel.OrderItemShoppingCartItemId,
                OrderItemTaxRate = viewModel.OrderItemTaxRate,
                QuantityCancelled = viewModel.QuantityCancelled,
                QuantityReturned = viewModel.QuantityReturned,
                UsedGiftClubPointAmount = viewModel.UsedGiftClubPointAmount,
                ProductId = viewModel.ProductId,
                ProductImage = viewModel.ProductImage,
                ProductName = viewModel.ProductName,
                TransactionNumber = viewModel.TransactionNumber
            });
        }

        public OrderItemViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new OrderItemViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                EarndGiftClubPointAmount = result.EarndGiftClubPointAmount,
                GiftCardDetails = result.GiftCardDetails,
                OrderItemDiscount = result.OrderItemDiscount,
                OrderItemFirstPriceInclTax = result.OrderItemFirstPriceInclTax,
                OrderItemOrderId = result.OrderItemOrderId,
                OrderItemOrderStatusId = result.OrderItemOrderStatusId,
                OrderItemPriceInclTax = result.OrderItemPriceInclTax,
                OrderItemQuantity = result.OrderItemQuantity,
                OrderItemRefundAmount = result.OrderItemRefundAmount,
                OrderItemSaleDiscount = result.OrderItemSaleDiscount,
                OrderItemSaleInstallmentPriceInclTax = result.OrderItemSaleInstallmentPriceInclTax,
                OrderItemSalePriceInclTax = result.OrderItemSalePriceInclTax,
                OrderItemSaleRefundAmount = result.OrderItemSaleRefundAmount,
                OrderItemShoppingCartItemId = result.OrderItemShoppingCartItemId,
                OrderItemTaxRate = result.OrderItemTaxRate,
                QuantityCancelled = result.QuantityCancelled,
                QuantityReturned = result.QuantityReturned,
                UsedGiftClubPointAmount = result.UsedGiftClubPointAmount
            };
        }

        public IQueryable<OrderItemViewModel> GetAllByOrderId(Guid orderId)
        {
            return _repository.GetList()
                .Where(y => y.IsActive && !y.IsDeleted && y.OrderItemOrderId == orderId)
                .Select(x => new OrderItemViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    EarndGiftClubPointAmount = x.EarndGiftClubPointAmount,
                    GiftCardDetails = x.GiftCardDetails,
                    OrderItemDiscount = x.OrderItemDiscount,
                    OrderItemFirstPriceInclTax = x.OrderItemFirstPriceInclTax,
                    OrderItemOrderId = x.OrderItemOrderId,
                    OrderItemOrderStatusId = x.OrderItemOrderStatusId,
                    OrderItemPriceInclTax = x.OrderItemPriceInclTax,
                    OrderItemQuantity = x.OrderItemQuantity,
                    OrderItemRefundAmount = x.OrderItemRefundAmount,
                    OrderItemSaleDiscount = x.OrderItemSaleDiscount,
                    OrderItemSaleInstallmentPriceInclTax = x.OrderItemSaleInstallmentPriceInclTax,
                    OrderItemSalePriceInclTax = x.OrderItemSalePriceInclTax,
                    OrderItemSaleRefundAmount = x.OrderItemSaleRefundAmount,
                    OrderItemShoppingCartItemId = x.OrderItemShoppingCartItemId,
                    OrderItemTaxRate = x.OrderItemTaxRate,
                    QuantityCancelled = x.QuantityCancelled,
                    QuantityReturned = x.QuantityReturned,
                    UsedGiftClubPointAmount = x.UsedGiftClubPointAmount,
                    ProductName = x.ProductName,
                    ProductImage = x.ProductImage,
                    ProductId = x.ProductId,
                    TransactionNumber = x.TransactionNumber
                });
        }

        public IQueryable<OrderItemViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new OrderItemViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    EarndGiftClubPointAmount = x.EarndGiftClubPointAmount,
                    GiftCardDetails = x.GiftCardDetails,
                    OrderItemDiscount = x.OrderItemDiscount,
                    OrderItemFirstPriceInclTax = x.OrderItemFirstPriceInclTax,
                    OrderItemOrderId = x.OrderItemOrderId,
                    OrderItemOrderStatusId = x.OrderItemOrderStatusId,
                    OrderItemPriceInclTax = x.OrderItemPriceInclTax,
                    OrderItemQuantity = x.OrderItemQuantity,
                    OrderItemRefundAmount = x.OrderItemRefundAmount,
                    OrderItemSaleDiscount = x.OrderItemSaleDiscount,
                    OrderItemSaleInstallmentPriceInclTax = x.OrderItemSaleInstallmentPriceInclTax,
                    OrderItemSalePriceInclTax = x.OrderItemSalePriceInclTax,
                    OrderItemSaleRefundAmount = x.OrderItemSaleRefundAmount,
                    OrderItemShoppingCartItemId = x.OrderItemShoppingCartItemId,
                    OrderItemTaxRate = x.OrderItemTaxRate,
                    QuantityCancelled = x.QuantityCancelled,
                    QuantityReturned = x.QuantityReturned,
                    UsedGiftClubPointAmount = x.UsedGiftClubPointAmount,
                    ProductId = x.ProductId,
                    ProductImage = x.ProductImage,
                    ProductName = x.ProductName,
                    TransactionNumber = x.TransactionNumber
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(OrderItemViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.EarndGiftClubPointAmount = viewModel.EarndGiftClubPointAmount;
            result.GiftCardDetails = viewModel.GiftCardDetails;
            result.OrderItemDiscount = viewModel.OrderItemDiscount;
            result.OrderItemFirstPriceInclTax = viewModel.OrderItemFirstPriceInclTax;
            result.OrderItemOrderId = viewModel.OrderItemOrderId;
            result.OrderItemOrderStatusId = viewModel.OrderItemOrderStatusId;
            result.OrderItemPriceInclTax = viewModel.OrderItemPriceInclTax;
            result.OrderItemQuantity = viewModel.OrderItemQuantity;
            result.OrderItemRefundAmount = viewModel.OrderItemRefundAmount;
            result.OrderItemSaleDiscount = viewModel.OrderItemSaleDiscount;
            result.OrderItemSaleInstallmentPriceInclTax = viewModel.OrderItemSaleInstallmentPriceInclTax;
            result.OrderItemSalePriceInclTax = viewModel.OrderItemSalePriceInclTax;
            result.OrderItemSaleRefundAmount = viewModel.OrderItemSaleRefundAmount;
            result.OrderItemShoppingCartItemId = viewModel.OrderItemShoppingCartItemId;
            result.OrderItemTaxRate = viewModel.OrderItemTaxRate;
            result.QuantityCancelled = viewModel.QuantityCancelled;
            result.QuantityReturned = viewModel.QuantityReturned;
            result.UsedGiftClubPointAmount = viewModel.UsedGiftClubPointAmount;
            result.ProductId = viewModel.ProductId;
            result.ProductImage = viewModel.ProductImage;
            result.ProductName = viewModel.ProductName;
            result.TransactionNumber = viewModel.TransactionNumber;

            _repository.Update(result);
        }
    }
}
