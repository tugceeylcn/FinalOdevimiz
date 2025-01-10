using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.ViewModels;
using System;
using System.Linq;

namespace Odev.Services.DbServices
{
    public class ShoppingCartServices : BaseServices
    {
        private readonly OdevRepository<ShoppingCart> _repository;
        public ShoppingCartServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<ShoppingCart>(unitOfWork);
        }

        public Guid Add(ShoppingCartViewModel viewModel)
        {
            var id = Guid.NewGuid();
            _repository.Add(new ShoppingCart
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = id,
                BasketTaxTotal = viewModel.BasketTaxTotal,
                CargoId = viewModel.CargoId,
                CustomerId = viewModel.CustomerId,
                GetCargoOnDeliveryInclTax = viewModel.GetCargoOnDeliveryInclTax,
                GetShoppingCartItemTotalQuantity = viewModel.GetShoppingCartItemTotalQuantity,
                IsCodeOrCopunEnabled = viewModel.IsCodeOrCopunEnabled,
                IsGiftCardEnabled = viewModel.IsGiftCardEnabled,
                OrderOrderTypeId = viewModel.OrderOrderTypeId,
                PaymentTypeId = viewModel.PaymentTypeId,
                UsedCodeOrCoupon = viewModel.UsedCodeOrCoupon,
                UsedGiftCardAmount = viewModel.UsedGiftCardAmount,
                AddressId = viewModel.AddressId,
                CargoCampaign = viewModel.CargoCampaign
            });

            return id;
        }

        public ShoppingCartViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id && x.IsActive && !x.IsDeleted);

            return new ShoppingCartViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                BasketTaxTotal = result.BasketTaxTotal,
                CargoId = result.CargoId,
                CustomerId = result.CustomerId,
                GetCargoOnDeliveryInclTax = result.GetCargoOnDeliveryInclTax,
                GetShoppingCartItemTotalQuantity = result.GetShoppingCartItemTotalQuantity,
                IsCodeOrCopunEnabled = result.IsCodeOrCopunEnabled,
                IsGiftCardEnabled = result.IsGiftCardEnabled,
                OrderOrderTypeId = result.OrderOrderTypeId,
                PaymentTypeId = result.PaymentTypeId,
                UsedCodeOrCoupon = result.UsedCodeOrCoupon,
                UsedGiftCardAmount = result.UsedGiftCardAmount,
                CargoName = result.Cargo.CargoName,
                AddressId = result.AddressId,
                CargoCampaign = result.CargoCampaign
            };
        }

        public ShoppingCartViewModel GetByCustomerId(Guid customerId)
        {
            var result = _repository.Get(x => x.CustomerId == customerId && x.IsActive && !x.IsDeleted);

            if (result == null)
            {
                return default;
            }

            return new ShoppingCartViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                BasketTaxTotal = result.BasketTaxTotal,
                CargoId = result.CargoId,
                CustomerId = result.CustomerId,
                GetCargoOnDeliveryInclTax = result.GetCargoOnDeliveryInclTax,
                GetShoppingCartItemTotalQuantity = result.GetShoppingCartItemTotalQuantity,
                IsCodeOrCopunEnabled = result.IsCodeOrCopunEnabled,
                IsGiftCardEnabled = result.IsGiftCardEnabled,
                OrderOrderTypeId = result.OrderOrderTypeId,
                PaymentTypeId = result.PaymentTypeId,
                UsedCodeOrCoupon = result.UsedCodeOrCoupon,
                UsedGiftCardAmount = result.UsedGiftCardAmount,
                CargoName = result.Cargo.CargoName,
                AddressId = result.AddressId,
                CargoCampaign = result.CargoCampaign
            };
        }

        public IQueryable<ShoppingCartViewModel> GetAll()
        {
            return _repository.GetList()
                .Where(x => x.IsActive && !x.IsDeleted)
                .Select(x => new ShoppingCartViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    BasketTaxTotal = x.BasketTaxTotal,
                    CargoId = x.CargoId,
                    CustomerId = x.CustomerId,
                    GetCargoOnDeliveryInclTax = x.GetCargoOnDeliveryInclTax,
                    GetShoppingCartItemTotalQuantity = x.GetShoppingCartItemTotalQuantity,
                    IsCodeOrCopunEnabled = x.IsCodeOrCopunEnabled,
                    IsGiftCardEnabled = x.IsGiftCardEnabled,
                    OrderOrderTypeId = x.OrderOrderTypeId,
                    PaymentTypeId = x.PaymentTypeId,
                    UsedCodeOrCoupon = x.UsedCodeOrCoupon,
                    UsedGiftCardAmount = x.UsedGiftCardAmount,
                    CargoName = x.Cargo.CargoName,
                    AddressId = x.AddressId,
                    CargoCampaign = x.CargoCampaign
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(ShoppingCartViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id && x.IsActive && !x.IsDeleted);

            if (result != null)
            {
                result.UpdatedDateTime = DateTime.Now;
                result.UpdatedUserId = viewModel.UpdatedUserId;
                result.Language = viewModel.Language;
                result.BasketTaxTotal = viewModel.BasketTaxTotal;
                result.CargoId = viewModel.CargoId;
                result.CustomerId = viewModel.CustomerId;
                result.GetCargoOnDeliveryInclTax = viewModel.GetCargoOnDeliveryInclTax;
                result.GetShoppingCartItemTotalQuantity = viewModel.GetShoppingCartItemTotalQuantity;
                result.IsCodeOrCopunEnabled = viewModel.IsCodeOrCopunEnabled;
                result.IsGiftCardEnabled = viewModel.IsGiftCardEnabled;
                result.OrderOrderTypeId = viewModel.OrderOrderTypeId;
                result.PaymentTypeId = viewModel.PaymentTypeId;
                result.UsedCodeOrCoupon = viewModel.UsedCodeOrCoupon;
                result.UsedGiftCardAmount = viewModel.UsedGiftCardAmount;
                result.AddressId = viewModel.AddressId;
                result.CargoCampaign = viewModel.CargoCampaign;

                _repository.Update(result);
            }
        }
    }
}
