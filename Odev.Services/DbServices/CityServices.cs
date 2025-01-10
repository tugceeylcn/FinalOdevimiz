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
    public class CityServices : BaseServices
    {
        private readonly OdevRepository<City> _repository;
        public CityServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<City>(unitOfWork);
        }

        public void Add(CityViewModel viewModel)
        {
            _repository.Add(new City
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CityCode = viewModel.CityCode,
                CityCountryId = viewModel.CityCountryId,
                CityLatitude = viewModel.CityLatitude,
                CityLongtitude = viewModel.CityLongtitude,
                CityName = viewModel.CityName,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                DisplayOrder = viewModel.DisplayOrder,
                Id = Guid.NewGuid()
            });
        }

        public CityViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new CityViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CityName = result.CityName,
                CityLongtitude = result.CityLongtitude,
                CityLatitude = result.CityLatitude,
                CityCountryId = result.CityCountryId,
                CityCode = result.CityCode,
                DisplayOrder = result.DisplayOrder,
                CreatedUserId = result.CreatedUserId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<CityViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new CityViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CityCode = x.CityCode,
                    CityCountryId = x.CityCountryId,
                    CityLatitude = x.CityLatitude,
                    CityLongtitude = x.CityLongtitude,
                    CityName = x.CityName,
                    DisplayOrder = x.DisplayOrder,
                    CreatedUserId = x.CreatedUserId
                });
        }

        public IQueryable<CityViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new CityViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    CityName = x.CityName,
                    CityLongtitude = x.CityLongtitude,
                    CityLatitude = x.CityLatitude,
                    CityCountryId = x.CityCountryId,
                    CityCode = x.CityCode,
                    IsActive = x.IsActive,
                    DisplayOrder = x.DisplayOrder

                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(CityViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.IsActive = viewModel.IsActive;
            result.CityCode = viewModel.CityCode;
            result.CityCountryId = viewModel.CityCountryId;
            result.CityLatitude = viewModel.CityLatitude;
            result.CityLongtitude = viewModel.CityLongtitude;
            result.CityName = viewModel.CityName;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.DisplayOrder = viewModel.DisplayOrder;

            _repository.Update(result);
        }
    }
}
