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
    public class CountyServices : BaseServices
    {
        private readonly OdevRepository<County> _repository;
        public CountyServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<County>(unitOfWork);
        }

        public void Add(CountyViewModel viewModel)
        {
            _repository.Add(new County
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CountyCode = viewModel.CountyCode,
                CountyLatitude = viewModel.CountyLatitude,
                CountyLongtitude = viewModel.CountyLongtitude,
                CountyName = viewModel.CountyName,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                DisplayOrder = viewModel.DisplayOrder,
                Id = Guid.NewGuid(),
                CountyCityId = viewModel.CountyCityId
            });
        }

        public CountyViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new CountyViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CountyName = result.CountyName,
                CountyLongtitude = result.CountyLongtitude,
                CountyLatitude = result.CountyLatitude,
                CountyCode = result.CountyCode,
                DisplayOrder = result.DisplayOrder,
                CreatedUserId = result.CreatedUserId,
                CountyCityId = result.CountyCityId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<CountyViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new CountyViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CountyCode = x.CountyCode,
                    CountyLatitude = x.CountyLatitude,
                    CountyLongtitude = x.CountyLongtitude,
                    CountyName = x.CountyName,
                    DisplayOrder = x.DisplayOrder,
                    CreatedUserId = x.CreatedUserId,
                    CountyCityId = x.CountyCityId
                });
        }

        public IQueryable<CountyViewModel> GetAllByCityId(Guid cityId)
        {
            return _repository.GetList()
                .Where(y => y.CountyCityId == cityId && y.IsActive && !y.IsDeleted)
                .Select(x => new CountyViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CountyCode = x.CountyCode,
                    CountyLatitude = x.CountyLatitude,
                    CountyLongtitude = x.CountyLongtitude,
                    CountyName = x.CountyName,
                    DisplayOrder = x.DisplayOrder,
                    CreatedUserId = x.CreatedUserId,
                    CountyCityId = x.CountyCityId
                });
        }

        public IQueryable<CountyViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new CountyViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    CountyName = x.CountyName,
                    CountyLongtitude = x.CountyLongtitude,
                    CountyLatitude = x.CountyLatitude,
                    CountyCode = x.CountyCode,
                    IsActive = x.IsActive,
                    DisplayOrder = x.DisplayOrder,
                    CountyCityId = x.CountyCityId

                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(CountyViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.IsActive = viewModel.IsActive;
            result.CountyCode = viewModel.CountyCode;
            result.CountyCityId = viewModel.CountyCityId;
            result.CountyLatitude = viewModel.CountyLatitude;
            result.CountyLongtitude = viewModel.CountyLongtitude;
            result.CountyName = viewModel.CountyName;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.DisplayOrder = viewModel.DisplayOrder;

            _repository.Update(result);
        }
    }
}
