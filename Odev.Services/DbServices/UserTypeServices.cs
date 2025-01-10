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
    public class UserTypeServices : BaseServices
    {
        private readonly OdevRepository<UserType> _repository;
        public UserTypeServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<UserType>(unitOfWork);
        }

        public void Add(UserTypeViewModel viewModel)
        {
            _repository.Add(new UserType
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Language = viewModel.Language,
                IdentityTransactions = viewModel.IdentityTransactions,
                NewsTransactions = viewModel.NewsTransactions,
                SiteSettingTransactions = viewModel.SiteSettingTransactions,
                SliderTransactions = viewModel.SliderTransactions,
                SubIdentityTransactions = viewModel.SubIdentityTransactions,
                SubNewsTransactions = viewModel.SubNewsTransactions,
                SubscribeMemberTransactions = viewModel.SubscribeMemberTransactions,
                SubSiteSettingTransactions = viewModel.SubSiteSettingTransactions,
                SubSliderTransactions = viewModel.SubSliderTransactions,
                SubSubscribeMemberTransactions = viewModel.SubSubscribeMemberTransactions,
                SubUsersTransactions = viewModel.SubUsersTransactions,
                UsersTransactions = viewModel.UsersTransactions,
                UserTypeTransactions = viewModel.UserTypeTransactions,
                SubUserTypeTransactions = viewModel.SubUserTypeTransactions,
                GeneralPageTransactions = viewModel.GeneralPageTransactions,
                SubGeneralPageTransactions = viewModel.SubGeneralPageTransactions,
                CityTransactions = viewModel.CityTransactions,
                SubCityTransactions = viewModel.SubCityTransactions,
                Title = viewModel.Title,
                Id = Guid.NewGuid(),
                CategoryTransactions = viewModel.CategoryTransactions,
                SubCategoryTransactions = viewModel.SubCategoryTransactions,
                BlogTransactions = viewModel.BlogTransactions,
                SolutionPartnersTransactions = viewModel.SolutionPartnersTransactions,
                SubBlogTransactions = viewModel.SubBlogTransactions,
                SubSolutionPartnersTransactions = viewModel.SubSolutionPartnersTransactions,
                SettingTransactions = viewModel.SettingTransactions,
                SubSettingTransactions = viewModel.SubSettingTransactions,
                ColorTransactions = viewModel.ColorTransactions,
                SubColorTransactions = viewModel.SubColorTransactions,
                ProductTransactions = viewModel.ProductTransactions,
                SubProductTransactions = viewModel.SubProductTransactions,
                BlogGalleryTransactions = viewModel.BlogGalleryTransactions,
                SubBlogGalleryTransactions = viewModel.SubBlogGalleryTransactions,
                OrderTransactions = viewModel.OrderTransactions,
                SubOrderTransactions = viewModel.SubOrderTransactions,
            });
        }

        public UserTypeViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new UserTypeViewModel
            {
                Id = result.Id,
                Language = result.Language,
                IdentityTransactions = result.IdentityTransactions,
                NewsTransactions = result.NewsTransactions,
                SiteSettingTransactions = result.SiteSettingTransactions,
                SliderTransactions = result.SliderTransactions,
                SubIdentityTransactions = result.SubIdentityTransactions,
                SubNewsTransactions = result.SubNewsTransactions,
                SubscribeMemberTransactions = result.SubscribeMemberTransactions,
                SubSiteSettingTransactions = result.SubSiteSettingTransactions,
                SubSliderTransactions = result.SubSliderTransactions,
                SubSubscribeMemberTransactions = result.SubSubscribeMemberTransactions,
                SubUsersTransactions = result.SubUsersTransactions,
                UsersTransactions = result.UsersTransactions,
                UserTypeTransactions = result.UserTypeTransactions,
                SubUserTypeTransactions = result.SubUserTypeTransactions,
                GeneralPageTransactions = result.GeneralPageTransactions,
                SubGeneralPageTransactions = result.SubGeneralPageTransactions,
                CityTransactions = result.CityTransactions,
                SubCityTransactions = result.SubCityTransactions,
                Title = result.Title,
                IsDeleted = result.IsDeleted,
                CreatedDateTime = result.CreatedDateTime,
                CreatedUserId = result.CreatedUserId,
                IsActive = result.IsActive,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                CategoryTransactions = result.CategoryTransactions,
                SubCategoryTransactions = result.SubCategoryTransactions,
                SubSolutionPartnersTransactions = result.SubSolutionPartnersTransactions,
                SubBlogTransactions = result.SubBlogTransactions,
                SolutionPartnersTransactions = result.SolutionPartnersTransactions,
                BlogTransactions = result.BlogTransactions,
                SubSettingTransactions = result.SubSettingTransactions,
                SettingTransactions = result.SettingTransactions,
                SubColorTransactions = result.SubColorTransactions,
                ColorTransactions = result.ColorTransactions,
                SubProductTransactions = result.SubProductTransactions,
                ProductTransactions = result.ProductTransactions,
                SubBlogGalleryTransactions = result.SubBlogGalleryTransactions,
                BlogGalleryTransactions = result.BlogGalleryTransactions,
                OrderTransactions = result.OrderTransactions,
                SubOrderTransactions = result.SubOrderTransactions,
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<UserTypeViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new UserTypeViewModel
                {
                    Id = x.Id,
                    UpdatedUserId = x.UpdatedUserId,
                    UpdatedDateTime = x.UpdatedDateTime,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    IdentityTransactions = x.IdentityTransactions,
                    NewsTransactions = x.NewsTransactions,
                    SiteSettingTransactions = x.SiteSettingTransactions,
                    SliderTransactions = x.SliderTransactions,
                    SubIdentityTransactions = x.SubIdentityTransactions,
                    SubNewsTransactions = x.SubNewsTransactions,
                    SubscribeMemberTransactions = x.SubscribeMemberTransactions,
                    SubSiteSettingTransactions = x.SubSiteSettingTransactions,
                    SubSliderTransactions = x.SubSliderTransactions,
                    SubSubscribeMemberTransactions = x.SubSubscribeMemberTransactions,
                    SubUsersTransactions = x.SubUsersTransactions,
                    UsersTransactions = x.UsersTransactions,
                    UserTypeTransactions = x.UserTypeTransactions,
                    SubUserTypeTransactions = x.SubUserTypeTransactions,
                    GeneralPageTransactions = x.GeneralPageTransactions,
                    SubGeneralPageTransactions = x.SubGeneralPageTransactions,
                    CityTransactions = x.CityTransactions,
                    SubCityTransactions = x.SubCityTransactions,
                    Title = x.Title,
                    SubCategoryTransactions = x.SubCategoryTransactions,
                    CategoryTransactions = x.CategoryTransactions,
                    BlogTransactions = x.BlogTransactions,
                    SolutionPartnersTransactions = x.SolutionPartnersTransactions,
                    SubBlogTransactions = x.SubBlogTransactions,
                    SubSolutionPartnersTransactions = x.SubSolutionPartnersTransactions,
                    SettingTransactions = x.SettingTransactions,
                    SubSettingTransactions = x.SubSettingTransactions,
                    ColorTransactions = x.ColorTransactions,
                    SubColorTransactions = x.SubColorTransactions,
                    ProductTransactions = x.ProductTransactions,
                    SubProductTransactions = x.SubProductTransactions,
                    BlogGalleryTransactions = x.BlogGalleryTransactions,
                    SubBlogGalleryTransactions = x.SubBlogGalleryTransactions,
                    OrderTransactions = x.OrderTransactions,
                    SubOrderTransactions = x.SubOrderTransactions,
                });
        }

        public void Update(UserTypeViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.IdentityTransactions = viewModel.IdentityTransactions;
            result.NewsTransactions = viewModel.NewsTransactions;
            result.SiteSettingTransactions = viewModel.SiteSettingTransactions;
            result.SliderTransactions = viewModel.SliderTransactions;
            result.SubIdentityTransactions = viewModel.SubIdentityTransactions;
            result.SubNewsTransactions = viewModel.SubNewsTransactions;
            result.SubscribeMemberTransactions = viewModel.SubscribeMemberTransactions;
            result.SubSiteSettingTransactions = viewModel.SubSiteSettingTransactions;
            result.SubSliderTransactions = viewModel.SubSliderTransactions;
            result.SubSubscribeMemberTransactions = viewModel.SubSubscribeMemberTransactions;
            result.SubUsersTransactions = viewModel.SubUsersTransactions;
            result.UsersTransactions = viewModel.UsersTransactions;
            result.UserTypeTransactions = viewModel.UserTypeTransactions;
            result.SubUserTypeTransactions = viewModel.SubUserTypeTransactions;
            result.GeneralPageTransactions = viewModel.GeneralPageTransactions;
            result.SubGeneralPageTransactions = viewModel.SubGeneralPageTransactions;
            result.CityTransactions = viewModel.CityTransactions;
            result.SubCityTransactions = viewModel.SubCityTransactions;
            result.CategoryTransactions = viewModel.CategoryTransactions;
            result.SubCategoryTransactions = viewModel.SubCategoryTransactions;
            result.Title = viewModel.Title;
            result.BlogTransactions = viewModel.BlogTransactions;
            result.SolutionPartnersTransactions = viewModel.SolutionPartnersTransactions;
            result.SubBlogTransactions = viewModel.SubBlogTransactions;
            result.SubSolutionPartnersTransactions = viewModel.SubSolutionPartnersTransactions;
            result.SettingTransactions = viewModel.SettingTransactions;
            result.SubSettingTransactions = viewModel.SubSettingTransactions;
            result.SubColorTransactions = viewModel.SubColorTransactions;
            result.ColorTransactions = viewModel.ColorTransactions;
            result.SubProductTransactions = viewModel.SubProductTransactions;
            result.ProductTransactions = viewModel.ProductTransactions;
            result.BlogGalleryTransactions = viewModel.BlogGalleryTransactions;
            result.SubBlogGalleryTransactions = viewModel.SubBlogGalleryTransactions;
            result.OrderTransactions = viewModel.OrderTransactions;
            result.SubOrderTransactions = viewModel.SubOrderTransactions;

            _repository.Update(result);
        }
    }
}
