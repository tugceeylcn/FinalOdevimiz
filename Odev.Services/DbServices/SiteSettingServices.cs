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
    public class SiteSettingServices : BaseServices
    {
        private readonly OdevRepository<SiteSetting> _repository;
        public SiteSettingServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<SiteSetting>(unitOfWork);
        }

        public void Add(SiteSettingViewModel viewModel)
        {
            _repository.Add(new SiteSetting
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                Adres = viewModel.Adres,
                Logo = viewModel.Logo,
                Email = viewModel.Email,
                Facebook = viewModel.Facebook,
                Fax = viewModel.Fax,
                Instagram = viewModel.Instagram,
                Phone = viewModel.Phone,
                Twitter = viewModel.Twitter,
                Youtube = viewModel.Youtube,
                Id = Guid.NewGuid(),
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Maps = viewModel.Maps
            });
        }

        public SiteSettingViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new SiteSettingViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                Adres = result.Adres,
                Logo = result.Logo,
                Email = result.Email,
                Facebook = result.Facebook,
                Fax = result.Fax,
                Instagram = result.Instagram,
                Phone = result.Phone,
                Twitter = result.Twitter,
                Youtube = result.Youtube,
                CreatedUserId = result.CreatedUserId,
                Maps = result.Maps
            };
        }

        public SiteSettingViewModel GetLang(int lang)
        {
            var x = _repository.Get(a => a.Language == (LanguageSelection)lang);
            return new SiteSettingViewModel
            {
                Email = x.Email,
                Adres = x.Adres,
                Phone = x.Phone,
                Fax = x.Fax,
                Logo = x.Logo,
                Facebook = x.Facebook,
                Twitter = x.Twitter,
                Instagram = x.Instagram,
                Youtube = x.Youtube,
                Id = x.Id,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive,
                UpdatedDateTime = x.UpdatedDateTime,
                CreatedDateTime = x.CreatedDateTime,
                Language = x.Language,
                UpdatedUserId = x.UpdatedUserId,
                CreatedUserId = x.CreatedUserId,
                Maps = x.Maps
            };
        }

        public IQueryable<SiteSettingViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SiteSettingViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    Adres = x.Adres,
                    Email = x.Email,
                    Youtube = x.Youtube,
                    Twitter = x.Twitter,
                    Phone = x.Phone,
                    Instagram = x.Instagram,
                    Facebook = x.Facebook,
                    Fax = x.Fax,
                    Logo = x.Logo,
                    CreatedUserId = x.CreatedUserId,
                    Maps = x.Maps
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(SiteSettingViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.Adres = viewModel.Adres;
            result.Email = viewModel.Email;
            result.Youtube = viewModel.Youtube;
            result.Twitter = viewModel.Twitter;
            result.Phone = viewModel.Phone;
            result.Instagram = viewModel.Instagram;
            result.Facebook = viewModel.Facebook;
            result.Fax = viewModel.Fax;
            result.Maps = viewModel.Maps;

            if (viewModel.Logo != null)
                result.Logo = viewModel.Logo;

            _repository.Update(result);
        }
    }
}
