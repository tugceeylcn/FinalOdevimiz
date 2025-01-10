using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.Enums;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Services.DbServices
{
    public class AddressServices : BaseServices
    {
        private readonly OdevRepository<Address> _repository;
        public AddressServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Address>(unitOfWork);
        }

        public void Add(AddressViewModel viewModel)
        {
            _repository.Add(new Address
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                UpdatedUserId = viewModel.UpdatedUserId,
                Language = viewModel.Language,
                AddressCityId = viewModel.AddressCityId,
                AddressCountryId = viewModel.AddressCountryId,
                AddressCountryRegionId = viewModel.AddressCountryRegionId,
                AddressCountyId = viewModel.AddressCountyId,
                AddressCustomerId = viewModel.AddressCustomerId,
                AddressDistrictId = viewModel.AddressDistrictId,
                AddressFirstName = viewModel.AddressFirstName,
                AddressIdentityNumber = viewModel.AddressIdentityNumber,
                AddressInvoiceFirmName = viewModel.AddressInvoiceFirmName,
                AddressInvoiceTaxNumber = viewModel.AddressInvoiceTaxNumber,
                AddressInvoiceTaxOffice = viewModel.AddressInvoiceTaxOffice,
                AddressInvoiceTypeId = viewModel.AddressInvoiceTypeId,
                AddressLastName = viewModel.AddressLastName,
                AddressMobilePhone = viewModel.AddressMobilePhone,
                AddressName = viewModel.AddressName,
                AddressPhone = viewModel.AddressPhone,
                AddressPostalCode = viewModel.AddressPostalCode,
                AddressStreetId = viewModel.AddressStreetId,
                AddressStreetText = viewModel.AddressStreetText,
                AddressText = viewModel.AddressText,
                AddressTypeId = viewModel.AddressTypeId,
                Id = Guid.NewGuid(),
                ZipCode = viewModel.ZipCode
            });
        }

        public AddressViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new AddressViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                AddressTypeId = result.AddressTypeId,
                AddressText = result.AddressText,
                AddressStreetText = result.AddressStreetText,
                AddressStreetId = result.AddressStreetId,
                AddressPostalCode = result.AddressPostalCode,
                AddressPhone = result.AddressPhone,
                AddressCityId = result.AddressCityId,
                AddressCountryId = result.AddressCountryId,
                AddressCountryRegionId = result.AddressCountryRegionId,
                AddressCountyId = result.AddressCountyId,
                AddressCustomerId = result.AddressCustomerId,
                AddressDistrictId = result.AddressDistrictId,
                AddressFirstName = result.AddressFirstName,
                AddressIdentityNumber = result.AddressIdentityNumber,
                AddressInvoiceFirmName = result.AddressInvoiceFirmName,
                AddressInvoiceTaxNumber = result.AddressInvoiceTaxNumber,
                AddressInvoiceTaxOffice = result.AddressInvoiceTaxOffice,
                AddressInvoiceTypeId = result.AddressInvoiceTypeId,
                AddressLastName = result.AddressLastName,
                AddressMobilePhone = result.AddressMobilePhone,
                AddressName = result.AddressName,
                AddressCityName = result.City.CityName,
                AddressCountryName = result.Country.CountryName,
                AddressCountyName = result.County.CountyName,
                AddressDistrictName = result.District.DistrictName,
                ZipCode = result.ZipCode,
                CreatedUserId = result.CreatedUserId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<AddressViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new AddressViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    CreatedUserId = x.CreatedUserId,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    AddressName = x.AddressName,
                    AddressMobilePhone = x.AddressMobilePhone,
                    AddressLastName = x.AddressLastName,
                    AddressInvoiceTypeId = x.AddressInvoiceTypeId,
                    AddressInvoiceTaxOffice = x.AddressInvoiceTaxOffice,
                    AddressInvoiceTaxNumber = x.AddressInvoiceTaxNumber,
                    AddressInvoiceFirmName = x.AddressInvoiceFirmName,
                    AddressIdentityNumber = x.AddressIdentityNumber,
                    AddressCityId = x.AddressCityId,
                    AddressCountryId = x.AddressCountryId,
                    AddressCountryRegionId = x.AddressCountryRegionId,
                    AddressCountyId = x.AddressCountyId,
                    AddressCustomerId = x.AddressCustomerId,
                    AddressDistrictId = x.AddressDistrictId,
                    AddressFirstName = x.AddressFirstName,
                    AddressPhone = x.AddressPhone,
                    AddressPostalCode = x.AddressPostalCode,
                    AddressStreetId = x.AddressStreetId,
                    AddressStreetText = x.AddressStreetText,
                    AddressText = x.AddressText,
                    IsActive = x.IsActive,
                    AddressTypeId = x.AddressTypeId,
                    ZipCode = x.ZipCode,
                    AddressDistrictName = x.District.DistrictName,
                    AddressCountyName = x.County.CountyName,
                    AddressCityName = x.City.CityName,
                    AddressCountryName = x.Country.CountryName
                });
        }

        public IQueryable<AddressViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new AddressViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    CreatedUserId = x.CreatedUserId,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    AddressName = x.AddressName,
                    AddressMobilePhone = x.AddressMobilePhone,
                    AddressLastName = x.AddressLastName,
                    AddressInvoiceTypeId = x.AddressInvoiceTypeId,
                    AddressInvoiceTaxOffice = x.AddressInvoiceTaxOffice,
                    AddressInvoiceTaxNumber = x.AddressInvoiceTaxNumber,
                    AddressInvoiceFirmName = x.AddressInvoiceFirmName,
                    AddressIdentityNumber = x.AddressIdentityNumber,
                    AddressCityId = x.AddressCityId,
                    AddressCountryId = x.AddressCountryId,
                    AddressCountryRegionId = x.AddressCountryRegionId,
                    AddressCountyId = x.AddressCountyId,
                    AddressCustomerId = x.AddressCustomerId,
                    AddressDistrictId = x.AddressDistrictId,
                    AddressFirstName = x.AddressFirstName,
                    AddressPhone = x.AddressPhone,
                    AddressPostalCode = x.AddressPostalCode,
                    AddressStreetId = x.AddressStreetId,
                    AddressStreetText = x.AddressStreetText,
                    AddressText = x.AddressText,
                    IsActive = x.IsActive,
                    AddressTypeId = x.AddressTypeId,
                    AddressCityName = x.City.CityName,
                    AddressCountryName = x.Country.CountryName,
                    AddressCountyName = x.County.CountyName,
                    AddressDistrictName = x.District.DistrictName,
                    ZipCode = x.ZipCode

                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(AddressViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.AddressCityId = viewModel.AddressCityId;
            result.AddressCountryId = viewModel.AddressCountryId;
            result.AddressCountryRegionId = viewModel.AddressCountryRegionId;
            result.AddressCountyId = viewModel.AddressCountyId;
            result.AddressCustomerId = viewModel.AddressCustomerId;
            result.AddressDistrictId = viewModel.AddressDistrictId;
            result.AddressFirstName = viewModel.AddressFirstName;
            result.AddressIdentityNumber = viewModel.AddressIdentityNumber;
            result.AddressInvoiceFirmName = viewModel.AddressInvoiceFirmName;
            result.AddressInvoiceTaxNumber = viewModel.AddressInvoiceTaxNumber;
            result.AddressInvoiceTaxOffice = viewModel.AddressInvoiceTaxOffice;
            result.AddressInvoiceTypeId = viewModel.AddressInvoiceTypeId;
            result.AddressLastName = viewModel.AddressLastName;
            result.AddressMobilePhone = viewModel.AddressMobilePhone;
            result.AddressName = viewModel.AddressName;
            result.AddressPhone = viewModel.AddressPhone;
            result.AddressPostalCode = viewModel.AddressPostalCode;
            result.AddressStreetId = viewModel.AddressStreetId;
            result.AddressStreetText = viewModel.AddressStreetText;
            result.AddressText = viewModel.AddressText;
            result.AddressTypeId = viewModel.AddressTypeId;
            result.IsActive = viewModel.IsActive;
            result.ZipCode = viewModel.ZipCode;

            _repository.Update(result);
        }
    }
}
