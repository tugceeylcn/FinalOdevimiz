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
    public class NewsServices : BaseServices
    {
        private readonly OdevRepository<News> _repository;
        public NewsServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<News>(unitOfWork);
        }

        public void Add(NewsViewModel viewModel)
        {
            _repository.Add(new News
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                UpdatedUserId = viewModel.UpdatedUserId,
                Language = viewModel.Language,
                Title = viewModel.Title,
                NewsDate = viewModel.NewsDate,
                PictureUrl = viewModel.PictureUrl,
                SubTitle = viewModel.SubTitle,
                Text = viewModel.Text,
                Slug = viewModel.Title.ToSeoUrl(),
                DisplayOrder = viewModel.DisplayOrder
            });
        }

        public NewsViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new NewsViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Title = result.Title,
                Language = result.Language,
                Text = result.Text,
                SubTitle = result.SubTitle,
                PictureUrl = result.PictureUrl,
                NewsDate = result.NewsDate,
                DisplayOrder = result.DisplayOrder,
                Slug = result.Slug,
                CreatedUserId = result.CreatedUserId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<NewsViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new NewsViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    Title = x.Title,
                    NewsDate = x.NewsDate,
                    PictureUrl = x.PictureUrl,
                    SubTitle = x.SubTitle,
                    Text = x.Text,
                    CreatedUserId = x.CreatedUserId,
                    Slug = x.Slug,
                    DisplayOrder = x.DisplayOrder
                });
        }

        public IQueryable<NewsViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new NewsViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    PictureUrl = x.PictureUrl,
                    Text = x.Text,
                    NewsDate = x.NewsDate,
                    UpdatedUserId = x.UpdatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    Slug = x.Slug,
                    CreatedUserId = x.CreatedUserId
                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(NewsViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Title = viewModel.Title;
            result.Language = viewModel.Language;
            result.NewsDate = viewModel.NewsDate;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.Slug = viewModel.Title.ToSeoUrl();

            if (viewModel.PictureUrl != null)
                result.PictureUrl = viewModel.PictureUrl;

            result.SubTitle = viewModel.SubTitle;
            result.Text = viewModel.Text;

            _repository.Update(result);
        }
    }
}
