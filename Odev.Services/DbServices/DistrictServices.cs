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
    public class DistrictServices : BaseServices
    {
        private readonly OdevRepository<District> _repository;
        public DistrictServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<District>(unitOfWork);
        }

        public void Add(DistrictViewModel viewModel)
        {
            _repository.Add(new District
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                DistrictLatitude = viewModel.DistrictLatitude,
                DistrictLongtitude = viewModel.DistrictLongtitude,
                DistrictName = viewModel.DistrictName,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                DisplayOrder = viewModel.DisplayOrder,
                Id = Guid.NewGuid(),
                DistrictCountyId = viewModel.DistrictCountyId
            });
        }

        public DistrictViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new DistrictViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                DistrictName = result.DistrictName,
                DistrictLongtitude = result.DistrictLongtitude,
                DistrictLatitude = result.DistrictLatitude,
                DisplayOrder = result.DisplayOrder,
                CreatedUserId = result.CreatedUserId,
                DistrictCountyId = result.DistrictCountyId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<DistrictViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new DistrictViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    DistrictLatitude = x.DistrictLatitude,
                    DistrictLongtitude = x.DistrictLongtitude,
                    DistrictName = x.DistrictName,
                    DisplayOrder = x.DisplayOrder,
                    CreatedUserId = x.CreatedUserId,
                    DistrictCountyId = x.DistrictCountyId
                });
        }

        public IQueryable<DistrictViewModel> GetAllByCountyId(Guid countyId)
        {
            return _repository.GetList()
                .Where(y => y.DistrictCountyId == countyId && y.IsActive && !y.IsDeleted)
                .Select(x => new DistrictViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    DisplayOrder = x.DisplayOrder,
                    CreatedUserId = x.CreatedUserId,
                    DistrictCountyId = x.DistrictCountyId,
                    DistrictLatitude = x.DistrictLatitude,
                    DistrictLongtitude = x.DistrictLongtitude,
                    DistrictName = x.DistrictName
                });
        }

        public IQueryable<DistrictViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new DistrictViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    DistrictName = x.DistrictName,
                    DistrictLongtitude = x.DistrictLongtitude,
                    DistrictLatitude = x.DistrictLatitude,
                    IsActive = x.IsActive,
                    DisplayOrder = x.DisplayOrder,
                    DistrictCountyId = x.DistrictCountyId

                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(DistrictViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.IsActive = viewModel.IsActive;
            result.DistrictCountyId = viewModel.DistrictCountyId;
            result.DistrictLatitude = viewModel.DistrictLatitude;
            result.DistrictLongtitude = viewModel.DistrictLongtitude;
            result.DistrictName = viewModel.DistrictName;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.DisplayOrder = viewModel.DisplayOrder;

            _repository.Update(result);
        }
    }
}
