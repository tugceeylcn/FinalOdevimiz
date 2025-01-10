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
    public class CategoryServices : BaseServices
    {
        private readonly OdevRepository<Category> _repository;
        public CategoryServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Category>(unitOfWork);
        }

        public void Add(CategoryViewModel viewModel)
        {
            _repository.Add(new Category
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                CategoryName = viewModel.CategoryName,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                CategoryImage = viewModel.CategoryImage,
                Id = Guid.NewGuid(),
                TopCategoryId = viewModel.TopCategoryId,
                DisplayOrder = viewModel.DisplayOrder,
                IsPopular = viewModel.IsPopular,
                Slug = viewModel.CategoryName.ToSeoUrl()
            });
        }

        public CategoryViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new CategoryViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CategoryName = result.CategoryName,
                CategoryImage = result.CategoryImage,
                CreatedUserId = result.CreatedUserId,
                TopCategoryId = result.TopCategoryId,
                UstKategoriAd = result.TopCategory?.CategoryName,
                DisplayOrder = result.DisplayOrder,
                IsPopular = result.IsPopular,
                Slug = result.Slug,
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<CategoryViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CategoryName = x.CategoryName,
                    CategoryImage = x.CategoryImage,
                    CreatedUserId = x.CreatedUserId,
                    TopCategoryId = x.TopCategoryId,
                    UstKategoriAd = x.TopCategory.CategoryName,
                    IsPopular = x.IsPopular,
                    DisplayOrder = x.DisplayOrder,
                    Slug = x.Slug
                });
        }

        public IQueryable<CategoryViewModel> GetAllTopCategory()
        {
            return _repository.GetList()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    CategoryName = x.CategoryName,
                    CategoryImage = x.CategoryImage,
                    CreatedUserId = x.CreatedUserId,
                    TopCategoryId = x.TopCategoryId,
                    UstKategoriAd = x.TopCategory.CategoryName,
                    IsPopular = x.IsPopular,
                    DisplayOrder = x.DisplayOrder,
                    Slug = x.Slug
                }).Where(x => x.TopCategoryId == null);
        }

        public IQueryable<CategoryViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    UpdatedUserId = x.UpdatedUserId,
                    CategoryName = x.CategoryName,
                    IsActive = x.IsActive,
                    CategoryImage = x.CategoryImage,
                    CreatedUserId = x.CreatedUserId,
                    TopCategoryId = x.TopCategoryId,
                    UstKategoriAd = x.TopCategory.CategoryName,
                    DisplayOrder = x.DisplayOrder,
                    IsPopular = x.IsPopular,
                    Slug = x.Slug
                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(CategoryViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.CategoryName = viewModel.CategoryName;
            result.CategoryImage = viewModel.CategoryImage;
            result.TopCategoryId = viewModel.TopCategoryId;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.IsPopular = viewModel.IsPopular;
            result.Slug = viewModel.CategoryName.ToSeoUrl();

            _repository.Update(result);
        }
    }
}
