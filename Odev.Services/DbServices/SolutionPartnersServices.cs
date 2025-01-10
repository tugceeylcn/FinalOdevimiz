using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.Enums;
using Odev.Domain.Helpers;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Services.DbServices
{
    public class SolutionPartnersServices : BaseServices
    {
        private readonly OdevRepository<SolutionPartners> _repository;
        public SolutionPartnersServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<SolutionPartners>(unitOfWork);
        }

        public void Add(SolutionPartnersViewModel viewModel)
        {
            _repository.Add(new SolutionPartners
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                DisplayOrder = viewModel.DisplayOrder,
                PartnerImage = viewModel.PartnerImage,
                PartnerName = viewModel.PartnerName,
                Slug = viewModel.PartnerName.ToSeoUrl()
            });
        }

        public SolutionPartnersViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new SolutionPartnersViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                PartnerName = result.PartnerName,
                DisplayOrder = result.DisplayOrder,
                PartnerImage = result.PartnerImage,
                Slug = result.Slug
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<SolutionPartnersViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SolutionPartnersViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    PartnerImage = x.PartnerImage,
                    DisplayOrder = x.DisplayOrder,
                    PartnerName = x.PartnerName,
                    Slug = x.Slug
                });
        }

        public IQueryable<SolutionPartnersViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new SolutionPartnersViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    PartnerName = x.PartnerName,
                    DisplayOrder = x.DisplayOrder,
                    PartnerImage = x.PartnerImage,
                    Slug = x.Slug
                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(SolutionPartnersViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.PartnerName = viewModel.PartnerName;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.Slug = viewModel.PartnerName.ToSeoUrl();

            if (!string.IsNullOrEmpty(viewModel.PartnerImage))
            {
                result.PartnerImage = viewModel.PartnerImage;
            }

            _repository.Update(result);
        }
    }
}
