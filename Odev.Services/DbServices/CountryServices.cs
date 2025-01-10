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
    class CountryServices : BaseServices
    {
        private readonly OdevRepository<Country> _repository;
        public CountryServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Country>(unitOfWork);
        }

        public void Add(CountryViewModel viewModel)
        {
            _repository.Add(new Country
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                UpdatedUserId = viewModel.UpdatedUserId,
                Language = viewModel.Language,
                CountryCode = viewModel.CountryCode,
                CountryFlagImageFileName = viewModel.CountryFlagImageFileName,
                CountryLatitude = viewModel.CountryLatitude,
                CountryLongitude = viewModel.CountryLongitude,
                CountryName = viewModel.CountryName,
                CountryPhoneCodePrefix = viewModel.CountryPhoneCodePrefix,
                CountryRegexMobilePhone = viewModel.CountryRegexMobilePhone,
                CountryRegexPostalCode = viewModel.CountryRegexPostalCode
            });
        }

        public CountryViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new CountryViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CountryRegexPostalCode = result.CountryRegexPostalCode,
                CountryRegexMobilePhone = result.CountryRegexMobilePhone,
                CountryPhoneCodePrefix = result.CountryPhoneCodePrefix,
                CountryName = result.CountryName,
                CountryLongitude = result.CountryLongitude,
                CountryLatitude = result.CountryLatitude,
                CountryCode = result.CountryCode,
                CountryFlagImageFileName = result.CountryFlagImageFileName,
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<CountryViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new CountryViewModel
                {
                    Id = x.Id,
                    CreatedUserId = x.CreatedUserId,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CountryFlagImageFileName = x.CountryFlagImageFileName,
                    CountryCode = x.CountryCode,
                    CountryLatitude = x.CountryLatitude,
                    CountryLongitude = x.CountryLongitude,
                    CountryName = x.CountryName,
                    CountryPhoneCodePrefix = x.CountryPhoneCodePrefix,
                    CountryRegexMobilePhone = x.CountryRegexMobilePhone,
                    CountryRegexPostalCode = x.CountryRegexPostalCode
                });
        }

        public IQueryable<CountryViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new CountryViewModel
                {
                    Id = x.Id,
                    CreatedUserId = x.CreatedUserId,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    CountryRegexPostalCode = x.CountryRegexPostalCode,
                    CountryRegexMobilePhone = x.CountryRegexMobilePhone,
                    CountryPhoneCodePrefix = x.CountryPhoneCodePrefix,
                    CountryName = x.CountryName,
                    CountryLongitude = x.CountryLongitude,
                    CountryLatitude = x.CountryLatitude,
                    CountryCode = x.CountryCode,
                    CountryFlagImageFileName = x.CountryFlagImageFileName,
                    IsActive = x.IsActive

                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(CountryViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.IsActive = viewModel.IsActive;
            result.CountryCode = viewModel.CountryCode;
            result.CountryFlagImageFileName = viewModel.CountryFlagImageFileName;
            result.CountryLatitude = viewModel.CountryLatitude;
            result.CountryLongitude = viewModel.CountryLongitude;
            result.CountryName = viewModel.CountryName;
            result.CountryPhoneCodePrefix = viewModel.CountryPhoneCodePrefix;
            result.CountryRegexMobilePhone = viewModel.CountryRegexMobilePhone;
            result.CountryRegexPostalCode = viewModel.CountryRegexPostalCode;

            _repository.Update(result);
        }
    }
}
