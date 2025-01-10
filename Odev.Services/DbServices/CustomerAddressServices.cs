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
    public class CustomerAddressServices : BaseServices
    {
        private readonly OdevRepository<CustomerAddress> _repository;
        public CustomerAddressServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<CustomerAddress>(unitOfWork);
        }

        public void Add(CustomerAddressViewModel viewModel)
        {
            _repository.Add(new CustomerAddress
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                AddressName = viewModel.AddressName,
                AddressText = viewModel.AddressText,
                AddressTypeId = viewModel.AddressTypeId,
                CityId = viewModel.CityId,
                CountryId = Guid.Parse("7CEBFF92-67D6-4E28-A738-26242AB21E54"),
                CountyId = viewModel.CountyId,
                CustomerId = viewModel.CustomerId,
                DistrictId = viewModel.DistrictId,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                MobilePhone = viewModel.MobilePhone,
                ZipCode = viewModel.ZipCode
            });
        }

        public CustomerAddressViewModel Get(Guid Id)
        {
            var result = _repository.GetAll(x => x.Id == Id);

            return new CustomerAddressViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                MobilePhone = result.MobilePhone,
                LastName = result.LastName,
                DistrictName = result.District.DistrictName,
                FirstName = result.FirstName,
                DistrictId = result.DistrictId,
                CustomerId = result.CustomerId,
                CountyId = result.CountyId,
                CountryId = result.CountryId,
                AddressName = result.AddressName,
                AddressText = result.AddressText,
                AddressTypeId = result.AddressTypeId,
                CityId = result.CityId,
                CityName = result.City.CityName,
                CountryName = result.Country.CountryName,
                CountyName = result.County.CountyName,
                ZipCode = result.ZipCode
            };
        }

        public IQueryable<CustomerAddressViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new CustomerAddressViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    MobilePhone = x.MobilePhone,
                    LastName = x.LastName,
                    DistrictName = x.District.DistrictName,
                    FirstName = x.FirstName,
                    DistrictId = x.DistrictId,
                    CustomerId = x.CustomerId,
                    CountyId = x.CountyId,
                    CountryId = x.CountryId,
                    AddressName = x.AddressName,
                    AddressText = x.AddressText,
                    AddressTypeId = x.AddressTypeId,
                    CityId = x.CityId,
                    CityName = x.City.CityName,
                    CountryName = x.Country.CountryName,
                    CountyName = x.County.CountyName,
                    ZipCode = x.ZipCode
                });
        }

        public IQueryable<CustomerAddressViewModel> GetAllByCustomerId(Guid customerId)
        {
            return _repository.GetList()
                .Where(y => y.CustomerId == customerId)
                .Select(x => new CustomerAddressViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    MobilePhone = x.MobilePhone,
                    LastName = x.LastName,
                    DistrictName = x.District.DistrictName,
                    FirstName = x.FirstName,
                    DistrictId = x.DistrictId,
                    CustomerId = x.CustomerId,
                    CountyId = x.CountyId,
                    CountryId = x.CountryId,
                    AddressName = x.AddressName,
                    AddressText = x.AddressText,
                    AddressTypeId = x.AddressTypeId,
                    CityId = x.CityId,
                    CityName = x.City.CityName,
                    CountryName = x.Country.CountryName,
                    CountyName = x.County.CountyName,
                    ZipCode = x.ZipCode
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(CustomerAddressViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.AddressName = viewModel.AddressName;
            result.AddressText = viewModel.AddressText;
            result.AddressTypeId = viewModel.AddressTypeId;
            result.CityId = viewModel.CityId;
            result.CountyId = viewModel.CountyId;
            result.CustomerId = viewModel.CustomerId;
            result.DistrictId = viewModel.DistrictId;
            result.FirstName = viewModel.FirstName;
            result.LastName = viewModel.LastName;
            result.MobilePhone = viewModel.MobilePhone;
            result.ZipCode = viewModel.ZipCode;

            _repository.Update(result);
        }
    }
}
