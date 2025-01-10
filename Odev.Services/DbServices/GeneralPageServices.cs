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
    public class GeneralPageServices : BaseServices
    {
        private readonly OdevRepository<GeneralPage> _repository;
        public GeneralPageServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<GeneralPage>(unitOfWork);
        }

        public void Add(GeneralPageViewModel viewModel, int page)
        {
            _repository.Add(new GeneralPage
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                UpdatedUserId = viewModel.UpdatedUserId,
                Language = viewModel.Language,
                Content = viewModel.Content,
                Image = viewModel.Image,
                Title = viewModel.Title,
                Page = (PageName)page,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid()
            });
        }

        public GeneralPageViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new GeneralPageViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Title = result.Title,
                Image = result.Image,
                Content = result.Content,
                Language = result.Language,
                Page = result.Page,
                CreatedUserId = result.CreatedUserId
            };
        }

        public GeneralPageViewModel GetLang(int? lang)
        {
            var x = _repository.Get(a => a.Language == (LanguageSelection)lang);
            return new GeneralPageViewModel
            {

                Id = x.Id,
                IsActive = x.IsActive,
                UpdatedDateTime = x.UpdatedDateTime,
                CreatedDateTime = x.CreatedDateTime,
                IsDeleted = x.IsDeleted,
                Language = x.Language,
                Title = x.Title,
                Content = x.Content,
                Image = x.Image,
                Page = x.Page,
                UpdatedUserId = x.UpdatedUserId,
                CreatedUserId = x.CreatedUserId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<GeneralPageViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new GeneralPageViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    Content = x.Content,
                    Image = x.Image,
                    Title = x.Title,
                    Page = x.Page,
                    CreatedUserId = x.CreatedUserId
                });
        }

        public IQueryable<GeneralPageViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new GeneralPageViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    Content = x.Content,
                    Image = x.Image,
                    Title = x.Title,
                    Page = x.Page,
                    CreatedUserId = x.CreatedUserId
                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(GeneralPageViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Title = viewModel.Title;
            result.Language = viewModel.Language;
            result.Content = viewModel.Content;

            if (viewModel.Image != null)
                result.Image = viewModel.Image;

            _repository.Update(result);
        }
    }
}
