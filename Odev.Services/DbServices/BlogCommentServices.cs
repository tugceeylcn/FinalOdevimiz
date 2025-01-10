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
    public class BlogCommentServices : BaseServices
    {
        private readonly OdevRepository<BlogComment> _repository;
        public BlogCommentServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<BlogComment>(unitOfWork);
        }

        public void Add(BlogCommentViewModel viewModel)
        {
            _repository.Add(new BlogComment
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                BlogId = viewModel.BlogId,
                CommentDetail = viewModel.CommentDetail,
                Email = viewModel.Email,
                FirstLastName = viewModel.FirstLastName,
                CustomerId = viewModel.CustomerId,
                Id = Guid.NewGuid()
            });
        }

        public BlogCommentViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new BlogCommentViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                FirstLastName = result.FirstLastName,
                Email = result.Email,
                CommentDetail = result.CommentDetail,
                BlogId = result.BlogId,
                CreatedUserId = result.CreatedUserId,
                CustomerId = result.CustomerId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<BlogCommentViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new BlogCommentViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    BlogId = x.BlogId,
                    CommentDetail = x.CommentDetail,
                    Email = x.Email,
                    FirstLastName = x.FirstLastName,
                    CustomerId = x.CustomerId
                });
        }

        public IQueryable<BlogCommentViewModel> GetAllByBlogId(Guid blogId)
        {
            return _repository.GetList()
                .Select(x => new BlogCommentViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    BlogId = x.BlogId,
                    CommentDetail = x.CommentDetail,
                    Email = x.Email,
                    FirstLastName = x.FirstLastName,
                    CustomerId = x.CustomerId
                }).Where(x => x.BlogId == blogId);
        }

        public IQueryable<BlogCommentViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new BlogCommentViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    IsActive = x.IsActive,
                    FirstLastName = x.FirstLastName,
                    Email = x.Email,
                    CommentDetail = x.CommentDetail,
                    BlogId = x.BlogId,
                    CreatedUserId = x.CreatedUserId,
                    CustomerId = x.CustomerId
                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(BlogCommentViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.IsActive = viewModel.IsActive;
            result.FirstLastName = viewModel.FirstLastName;
            result.Email = viewModel.Email;
            result.CommentDetail = viewModel.CommentDetail;
            result.BlogId = viewModel.BlogId;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.CustomerId = viewModel.CustomerId;

            _repository.Update(result);
        }
    }
}
