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
    public class StreetServices : BaseServices
    {
        private readonly OdevRepository<Street> _repository;
        public StreetServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Street>(unitOfWork);
        }

        public void Add(StreetViewModel viewModel)
        {
            _repository.Add(new Street
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                UpdatedUserId = viewModel.UpdatedUserId,
                Language = viewModel.Language,
                StreetName = viewModel.StreetName,
                StreetLongtitude = viewModel.StreetLongtitude,
                StreetLatitude = viewModel.StreetLatitude,
                StreetDistrictId = viewModel.StreetDistrictId,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = viewModel.Id
            });
        }

        public StreetViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new StreetViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                StreetName = result.StreetName,
                StreetDistrictId = result.StreetDistrictId,
                StreetLatitude = result.StreetLatitude,
                StreetLongtitude = result.StreetLongtitude
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<StreetViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new StreetViewModel
                {
                    Id = x.Id,
                    CreatedUserId = x.CreatedUserId,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    StreetName = x.StreetName,
                    StreetLongtitude = x.StreetLongtitude,
                    StreetLatitude = x.StreetLatitude,
                    StreetDistrictId = x.StreetDistrictId,
                    IsActive = x.IsActive
                });
        }

        public IQueryable<StreetViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new StreetViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    CreatedUserId = x.CreatedUserId,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    StreetDistrictId = x.StreetDistrictId,
                    StreetLatitude = x.StreetLatitude,
                    StreetLongtitude = x.StreetLongtitude,
                    StreetName = x.StreetName,
                    IsActive = x.IsActive

                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(StreetViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.StreetName = viewModel.StreetName;
            result.StreetLongtitude = viewModel.StreetLongtitude;
            result.StreetLatitude = viewModel.StreetLatitude;
            result.StreetDistrictId = viewModel.StreetDistrictId;
            result.IsActive = viewModel.IsActive;
            result.Id = viewModel.Id;

            _repository.Update(result);
        }
    }
}
