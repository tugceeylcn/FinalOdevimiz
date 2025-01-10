using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Services.DbServices
{
    public class BlogGalleryServices : BaseServices
    {
        private readonly OdevRepository<BlogGallery> _repository;
        public BlogGalleryServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<BlogGallery>(unitOfWork);
        }

        public void Add(BlogGalleryViewModel viewModel)
        {
            _repository.Add(new BlogGallery
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                BlogId = viewModel.BlogId,
                ImageTitle = viewModel.ImageTitle,
                Image = viewModel.Image,
                DisplayOrder = viewModel.DisplayOrder
            });
        }

        public BlogGalleryViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new BlogGalleryViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CreatedUserId = result.CreatedUserId,
                ImageTitle = result.ImageTitle,
                BlogTitle = result.Blog.BlogTitle,
                BlogId = result.BlogId,
                Image = result.Image,
                DisplayOrder = result.DisplayOrder
            };
        }

        public IQueryable<BlogGalleryViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new BlogGalleryViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    ImageTitle = x.ImageTitle,
                    BlogTitle = x.Blog.BlogTitle,
                    BlogId = x.BlogId,
                    Image = x.Image,
                    DisplayOrder = x.DisplayOrder
                });
        }

        public IQueryable<BlogGalleryViewModel> GetAllByBlogId(Guid id)
        {
            return _repository.GetList()
                .Where(y => y.BlogId == id)
                .Select(x => new BlogGalleryViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    ImageTitle = x.ImageTitle,
                    BlogTitle = x.Blog.BlogTitle,
                    BlogId = x.BlogId,
                    Image = x.Image,
                    DisplayOrder = x.DisplayOrder
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(BlogGalleryViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.ImageTitle = viewModel.ImageTitle;
            result.BlogId = viewModel.BlogId;
            result.DisplayOrder = viewModel.DisplayOrder;

            if (!string.IsNullOrEmpty(viewModel.Image))
            {
                result.Image = viewModel.Image;
            }

            _repository.Update(result);
        }
    }
}
