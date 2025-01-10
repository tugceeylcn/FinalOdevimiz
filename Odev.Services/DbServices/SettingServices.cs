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
    public class SettingServices : BaseServices
    {
        private readonly OdevRepository<Setting> _repository;
        public SettingServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Setting>(unitOfWork);
        }

        public void Add(SettingViewModel viewModel)
        {
            _repository.Add(new Setting
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                CargoName = viewModel.CargoName,
                CargoPrice = viewModel.CargoPrice,
                CdnPath = viewModel.CdnPath,
                CompayTransferEnabled = viewModel.CompayTransferEnabled,
                DefaultLanguageId = viewModel.DefaultLanguageId,
                IyzicoApiKey = viewModel.IyzicoApiKey,
                IyzicoBaseUrl = viewModel.IyzicoBaseUrl,
                IyzicoSecretKey = viewModel.IyzicoSecretKey,
                MaxEstimatedDate = viewModel.MaxEstimatedDate,
                MinEstimatedDate = viewModel.MinEstimatedDate,
                PaymentCreditCardEnabled = viewModel.PaymentCreditCardEnabled,
                PaymentInstallmentEnabled = viewModel.PaymentInstallmentEnabled,
                PaymentOnDeliveryEnabled = viewModel.PaymentOnDeliveryEnabled,
                Currency = viewModel.Currency,
                CargoCampaign = viewModel.CargoCampaign,
                SmsGatewayApiKey = viewModel.SmsGatewayApiKey,
                SmsGatewaySecretKey = viewModel.SmsGatewaySecretKey,
                SmsGatewayBaseUrl = viewModel.SmsGatewayBaseUrl,
                SmsSenderName = viewModel.SmsSenderName,
                CargoTrackingUrl = viewModel.CargoTrackingUrl
            });
        }

        public SettingViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new SettingViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                CargoName = result.CargoName,
                CargoPrice = result.CargoPrice,
                PaymentOnDeliveryEnabled = result.PaymentOnDeliveryEnabled,
                PaymentInstallmentEnabled = result.PaymentInstallmentEnabled,
                PaymentCreditCardEnabled = result.PaymentCreditCardEnabled,
                MinEstimatedDate = result.MinEstimatedDate,
                MaxEstimatedDate = result.MaxEstimatedDate,
                IyzicoSecretKey = result.IyzicoSecretKey,
                CdnPath = result.CdnPath,
                CompayTransferEnabled = result.CompayTransferEnabled,
                DefaultLanguageId = result.DefaultLanguageId,
                IyzicoApiKey = result.IyzicoApiKey,
                IyzicoBaseUrl = result.IyzicoBaseUrl,
                Currency = result.Currency,
                CargoCampaign = result.CargoCampaign,
                SmsGatewayApiKey = result.SmsGatewayApiKey,
                SmsGatewayBaseUrl = result.SmsGatewayBaseUrl,
                SmsGatewaySecretKey = result.SmsGatewaySecretKey,
                SmsSenderName = result.SmsSenderName,
                CargoTrackingUrl = result.CargoTrackingUrl
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<SettingViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SettingViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    IyzicoBaseUrl = x.IyzicoBaseUrl,
                    IyzicoApiKey = x.IyzicoApiKey,
                    IyzicoSecretKey = x.IyzicoSecretKey,
                    DefaultLanguageId = x.DefaultLanguageId,
                    CompayTransferEnabled = x.CompayTransferEnabled,
                    CdnPath = x.CdnPath,
                    MaxEstimatedDate = x.MaxEstimatedDate,
                    MinEstimatedDate = x.MinEstimatedDate,
                    CargoName = x.CargoName,
                    CargoPrice = x.CargoPrice,
                    PaymentCreditCardEnabled = x.PaymentCreditCardEnabled,
                    PaymentInstallmentEnabled = x.PaymentInstallmentEnabled,
                    PaymentOnDeliveryEnabled = x.PaymentOnDeliveryEnabled,
                    Currency = x.Currency,
                    CargoCampaign = x.CargoCampaign,
                    SmsGatewayApiKey = x.SmsGatewayApiKey,
                    SmsGatewayBaseUrl = x.SmsGatewayBaseUrl,
                    SmsSenderName = x.SmsSenderName,
                    SmsGatewaySecretKey = x.SmsGatewaySecretKey,
                    CargoTrackingUrl = x.CargoTrackingUrl
                });
        }

        public void Update(SettingViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.IyzicoBaseUrl = viewModel.IyzicoBaseUrl;
            result.IyzicoApiKey = viewModel.IyzicoApiKey;
            result.IyzicoSecretKey = viewModel.IyzicoSecretKey;
            result.DefaultLanguageId = viewModel.DefaultLanguageId;
            result.CompayTransferEnabled = viewModel.CompayTransferEnabled;
            result.CdnPath = viewModel.CdnPath;
            result.MaxEstimatedDate = viewModel.MaxEstimatedDate;
            result.MinEstimatedDate = viewModel.MinEstimatedDate;
            result.CargoName = viewModel.CargoName;
            result.CargoPrice = viewModel.CargoPrice;
            result.PaymentCreditCardEnabled = viewModel.PaymentCreditCardEnabled;
            result.PaymentInstallmentEnabled = viewModel.PaymentInstallmentEnabled;
            result.PaymentOnDeliveryEnabled = viewModel.PaymentOnDeliveryEnabled;
            result.Currency = viewModel.Currency;
            result.CargoCampaign = viewModel.CargoCampaign;
            result.SmsGatewayApiKey = viewModel.SmsGatewayApiKey;
            result.SmsGatewayBaseUrl = viewModel.SmsGatewayBaseUrl;
            result.SmsSenderName = viewModel.SmsSenderName;
            result.SmsGatewaySecretKey = viewModel.SmsGatewaySecretKey;
            result.CargoTrackingUrl = viewModel.CargoTrackingUrl;

            _repository.Update(result);
        }
    }
}
