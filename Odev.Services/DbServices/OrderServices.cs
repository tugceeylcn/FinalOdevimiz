using AutoMapper;
using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.ViewModels;
using Odev.Services.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Odev.Services.DbServices
{
    public class OrderServices : BaseServices
    {
        private readonly OdevRepository<Order> _repository;
        public OrderServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Order>(unitOfWork);
        }

        public void Add(OrderViewModel viewModel)
        {
            _repository.Add(new Order
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = viewModel.Id,
                OrderShippingAddressId = viewModel.OrderShippingAddressId,
                CargoFirmName = viewModel.CargoFirmName,
                CargoOnDeliveryInclTax = viewModel.CargoOnDeliveryInclTax,
                CargoShippingInclTax = viewModel.CargoShippingInclTax,
                GiftCardMessage = viewModel.GiftCardMessage,
                GiftWrappingDetail = viewModel.GiftWrappingDetail,
                GiftWrappingInclTax = viewModel.GiftWrappingInclTax,
                IsThreeDSecurePayment = viewModel.IsThreeDSecurePayment,
                OrderAffiliateId = viewModel.OrderAffiliateId,
                OrderBillingAddressId = viewModel.OrderBillingAddressId,
                OrderCustomerId = viewModel.OrderCustomerId,
                OrderCargoId = viewModel.OrderCargoId,
                OrderCustomerIp = viewModel.OrderCustomerIp,
                OrderErrorMessage = viewModel.OrderErrorMessage,
                OrderInstallmentCount = viewModel.OrderInstallmentCount,
                OrderMaskedCardNumber = viewModel.OrderMaskedCardNumber,
                OrderOrderPaymentStatusId = viewModel.OrderOrderPaymentStatusId,
                OrderOrderStatusId = viewModel.OrderOrderStatusId,
                OrderRefundedAmount = viewModel.OrderRefundedAmount,
                OrderTotal = viewModel.OrderTotal,
                OrderTotalDiscount = viewModel.OrderTotalDiscount,
                OrderUsedGiftCardAmount = viewModel.OrderUsedGiftCardAmount,
                OrderShoppingCartId = viewModel.OrderShoppingCartId,
                DeliveryDate = viewModel.DeliveryDate,
                RefundAmountDate = viewModel.RefundAmountDate,
                EstimatedDate = viewModel.EstimatedDate,
                TrackingNumber = viewModel.TrackingNumber,
                InvoiceUrl = viewModel.InvoiceUrl,
                CustomerFullName = viewModel.CustomerFullName,
                CustomerEmail = viewModel.CustomerEmail,
                CargoCampaign = viewModel.CargoCampaign,
                TransactionNumber = viewModel.TransactionNumber,
                ConversationId = viewModel.ConversationId
            });
        }

        public OrderViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new OrderViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                OrderShippingAddressId = result.OrderShippingAddressId,
                CargoFirmName = result.CargoFirmName,
                CargoOnDeliveryInclTax = result.CargoOnDeliveryInclTax,
                CargoShippingInclTax = result.CargoShippingInclTax,
                GiftCardMessage = result.GiftCardMessage,
                GiftWrappingDetail = result.GiftWrappingDetail,
                GiftWrappingInclTax = result.GiftWrappingInclTax,
                IsThreeDSecurePayment = result.IsThreeDSecurePayment,
                OrderAffiliateId = result.OrderAffiliateId,
                OrderBillingAddressId = result.OrderBillingAddressId,
                OrderCustomerId = result.OrderCustomerId,
                OrderCargoId = result.OrderCargoId,
                OrderCustomerIp = result.OrderCustomerIp,
                OrderErrorMessage = result.OrderErrorMessage,
                OrderIndex = result.OrderIndex,
                OrderInstallmentCount = result.OrderInstallmentCount,
                OrderMaskedCardNumber = result.OrderMaskedCardNumber,
                OrderOrderPaymentStatusId = result.OrderOrderPaymentStatusId,
                OrderOrderStatusId = result.OrderOrderStatusId,
                OrderRefundedAmount = result.OrderRefundedAmount,
                OrderTotal = result.OrderTotal,
                OrderTotalDiscount = result.OrderTotalDiscount,
                OrderUsedGiftCardAmount = result.OrderUsedGiftCardAmount,
                OrderShoppingCartId = result.OrderShoppingCartId,
                DeliveryDate = result.DeliveryDate,
                RefundAmountDate = result.RefundAmountDate,
                EstimatedDate = result.EstimatedDate,
                TrackingNumber = result.TrackingNumber,
                InvoiceUrl = result.InvoiceUrl,
                OrderBillingAddress = new CustomerAddressViewModel
                {
                    FirstName = result.BillingAddress.FirstName,
                    LastName = result.BillingAddress.LastName
                },
                OrderShippingAddress = new CustomerAddressViewModel
                {
                    FirstName = result.ShippingAddress.FirstName,
                    LastName = result.ShippingAddress.LastName
                },
                CustomerEmail = result.CustomerEmail,
                CustomerFullName = result.CustomerFullName,
                CargoCampaign = result.CargoCampaign,
                TransactionNumber = result.TransactionNumber,
                ConversationId = result.ConversationId
            };
        }

        public IQueryable<OrderViewModel> GetAll()
        {
            var orders = _repository.GetList()
                .Where(x => x.IsActive && !x.IsDeleted)
                .Select(x => new OrderViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    OrderShippingAddressId = x.OrderShippingAddressId,
                    CargoFirmName = x.CargoFirmName,
                    CargoOnDeliveryInclTax = x.CargoOnDeliveryInclTax,
                    CargoShippingInclTax = x.CargoShippingInclTax,
                    GiftCardMessage = x.GiftCardMessage,
                    GiftWrappingDetail = x.GiftWrappingDetail,
                    GiftWrappingInclTax = x.GiftWrappingInclTax,
                    IsThreeDSecurePayment = x.IsThreeDSecurePayment,
                    OrderAffiliateId = x.OrderAffiliateId,
                    OrderBillingAddressId = x.OrderBillingAddressId,
                    OrderCustomerId = x.OrderCustomerId,
                    OrderCargoId = x.OrderCargoId,
                    OrderCustomerIp = x.OrderCustomerIp,
                    OrderErrorMessage = x.OrderErrorMessage,
                    OrderIndex = x.OrderIndex,
                    OrderInstallmentCount = x.OrderInstallmentCount,
                    OrderMaskedCardNumber = x.OrderMaskedCardNumber,
                    OrderOrderPaymentStatusId = x.OrderOrderPaymentStatusId,
                    OrderOrderStatusId = x.OrderOrderStatusId,
                    OrderRefundedAmount = x.OrderRefundedAmount,
                    OrderTotal = x.OrderTotal,
                    OrderTotalDiscount = x.OrderTotalDiscount,
                    OrderUsedGiftCardAmount = x.OrderUsedGiftCardAmount,
                    OrderShoppingCartId = x.OrderShoppingCartId,
                    DeliveryDate = x.DeliveryDate,
                    RefundAmountDate = x.RefundAmountDate,
                    EstimatedDate = x.EstimatedDate,
                    TrackingNumber = x.TrackingNumber,
                    InvoiceUrl = x.InvoiceUrl,
                    CustomerFullName = x.CustomerFullName,
                    CustomerEmail = x.CustomerEmail,
                    CargoCampaign = x.CargoCampaign,
                    TransactionNumber = x.CargoFirmName,
                    ConversationId = x.ConversationId
                });

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var orderViewModels = mapper.Map<List<OrderViewModel>>(orders);

            return orderViewModels.AsQueryable();
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(OrderViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.OrderShippingAddressId = viewModel.OrderShippingAddressId;
            result.CargoFirmName = viewModel.CargoFirmName;
            result.CargoOnDeliveryInclTax = viewModel.CargoOnDeliveryInclTax;
            result.CargoShippingInclTax = viewModel.CargoShippingInclTax;
            result.GiftCardMessage = viewModel.GiftCardMessage;
            result.GiftWrappingDetail = viewModel.GiftWrappingDetail;
            result.GiftWrappingInclTax = viewModel.GiftWrappingInclTax;
            result.IsThreeDSecurePayment = viewModel.IsThreeDSecurePayment;
            result.OrderAffiliateId = viewModel.OrderAffiliateId;
            result.OrderBillingAddressId = viewModel.OrderBillingAddressId;
            result.OrderCustomerId = viewModel.OrderCustomerId;
            result.OrderCargoId = viewModel.OrderCargoId;
            result.OrderCustomerIp = viewModel.OrderCustomerIp;
            result.OrderErrorMessage = viewModel.OrderErrorMessage;
            result.OrderIndex = viewModel.OrderIndex;
            result.OrderInstallmentCount = viewModel.OrderInstallmentCount;
            result.OrderMaskedCardNumber = viewModel.OrderMaskedCardNumber;
            result.OrderOrderPaymentStatusId = viewModel.OrderOrderPaymentStatusId;
            result.OrderOrderStatusId = viewModel.OrderOrderStatusId;
            result.OrderRefundedAmount = viewModel.OrderRefundedAmount;
            result.OrderTotal = viewModel.OrderTotal;
            result.OrderTotalDiscount = viewModel.OrderTotalDiscount;
            result.OrderUsedGiftCardAmount = viewModel.OrderUsedGiftCardAmount;
            result.OrderShoppingCartId = viewModel.OrderShoppingCartId;
            result.TrackingNumber = viewModel.TrackingNumber;
            result.InvoiceUrl = viewModel.InvoiceUrl;
            result.CustomerFullName = viewModel.CustomerFullName;
            result.CustomerEmail = viewModel.CustomerEmail;
            result.CargoCampaign = viewModel.CargoCampaign;
            result.TransactionNumber = viewModel.TransactionNumber;
            result.ConversationId = viewModel.ConversationId;

            _repository.Update(result);
        }

        public void UpdateDeliveryDate(Guid id)
        {
            var result = _repository.Get(x => x.Id == id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = Domain.Environments.Users.CreatedUserId;
            result.OrderOrderStatusId = Domain.Enums.OrderStatusEnum.Delivered;
            result.DeliveryDate = DateTime.Now;

            _repository.Update(result);
        }

        public void UpdateOrderStatusShipped(Guid id, string trackingNumber)
        {
            var result = _repository.Get(x => x.Id == id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = Domain.Environments.Users.CreatedUserId;
            result.TrackingNumber = trackingNumber;
            result.OrderOrderStatusId = Domain.Enums.OrderStatusEnum.Shipped;

            _repository.Update(result);
        }

        public void UpdateOrderStatusPacked(Guid id)
        {
            var result = _repository.Get(x => x.Id == id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = Domain.Environments.Users.CreatedUserId;
            result.OrderOrderStatusId = Domain.Enums.OrderStatusEnum.Packaged;

            _repository.Update(result);
        }

        public void UpdateOrderStatusCancel(Guid id)
        {
            var result = _repository.Get(x => x.Id == id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = Domain.Environments.Users.CreatedUserId;
            result.OrderOrderStatusId = Domain.Enums.OrderStatusEnum.Cancel;

            _repository.Update(result);
        }
    }
}
