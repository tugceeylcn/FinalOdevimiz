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
    public class BlogServices : BaseServices
    {
        private readonly OdevRepository<Blog> _repository;
        public BlogServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Blog>(unitOfWork);
        }

        public void Add(BlogViewModel viewModel)
        {
            _repository.Add(new Blog
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                BlogImage = viewModel.BlogImage,
                Id = Guid.NewGuid(),
                DisplayOrder = viewModel.DisplayOrder,
                BlogContent = viewModel.BlogContent,
                BlogTicket = viewModel.BlogTicket,
                BlogTitle = viewModel.BlogTitle,
                CategoryId = viewModel.CategoryId,
                LikeCount = viewModel.LikeCount,
                ShortUrl = viewModel.ShortUrl,
                Slug = viewModel.BlogTitle.ToSeoUrl()
            });
        }

        public BlogViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new BlogViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                BlogImage = result.BlogImage,
                CreatedUserId = result.CreatedUserId,
                DisplayOrder = result.DisplayOrder,
                CategoryName = result.CategoryInfo?.CategoryName,
                CategoryId = result.CategoryId,
                BlogTitle = result.BlogTitle,
                BlogTicket = result.BlogTicket,
                BlogContent = result.BlogContent,
                Slug = result.Slug,
                ShortUrl = result.ShortUrl,
                LikeCount = result.LikeCount
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<BlogViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new BlogViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    BlogImage = x.BlogImage,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    BlogContent = x.BlogContent,
                    BlogTicket = x.BlogTicket,
                    BlogTitle = x.BlogTitle,
                    CategoryName = x.CategoryInfo.CategoryName,
                    CategoryId = x.CategoryId,
                    LikeCount = x.LikeCount,
                    ShortUrl = x.ShortUrl,
                    Slug = x.Slug
                });
        }

        public IQueryable<BlogViewModel> GetAllByCategoryId(Guid categoryId)
        {
            return _repository.GetList()
                .Select(x => new BlogViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    BlogImage = x.BlogImage,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    BlogContent = x.BlogContent,
                    BlogTicket = x.BlogTicket,
                    BlogTitle = x.BlogTitle,
                    CategoryName = x.CategoryInfo.CategoryName,
                    CategoryId = x.CategoryId,
                    Slug = x.Slug,
                    ShortUrl = x.ShortUrl,
                    LikeCount = x.LikeCount
                }).Where(x => x.CategoryId == categoryId);
        }

        public IQueryable<BlogViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new BlogViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    IsActive = x.IsActive,
                    BlogImage = x.BlogImage,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    BlogContent = x.BlogContent,
                    BlogTicket = x.BlogTicket,
                    BlogTitle = x.BlogTitle,
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryInfo.CategoryName,
                    LikeCount = x.LikeCount,
                    ShortUrl = x.ShortUrl,
                    Slug = x.Slug
                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(BlogViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.BlogContent = viewModel.BlogContent;
            result.BlogTicket = viewModel.BlogTicket;
            result.BlogTitle = viewModel.BlogTitle;
            result.CategoryId = viewModel.CategoryId;
            result.LikeCount = viewModel.LikeCount;
            result.ShortUrl = viewModel.ShortUrl;
            result.Slug = viewModel.BlogTitle.ToSeoUrl();

            if (!string.IsNullOrEmpty(viewModel.BlogImage))
            {
                result.BlogImage = viewModel.BlogImage;
            }

            _repository.Update(result);
        }
    }
}
