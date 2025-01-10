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
    public class SliderServices : BaseServices
    {
        private readonly OdevRepository<Slider> _repository;
        public SliderServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Slider>(unitOfWork);
        }

        public void Add(SliderViewModel viewModel)
        {
            _repository.Add(new Slider
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                Image = viewModel.Image,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                DisplayOrder = viewModel.DisplayOrder,
                Id = Guid.NewGuid(),
                IsSale = viewModel.IsSale,
                TextOne = viewModel.TextOne,
                TextThree = viewModel.TextThree,
                TextTwo = viewModel.TextTwo,
                ProductId = viewModel.ProductId
            });
        }

        public SliderViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new SliderViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                Image = result.Image,
                DisplayOrder = result.DisplayOrder,
                CreatedUserId = result.CreatedUserId,
                TextTwo = result.TextTwo,
                TextThree = result.TextThree,
                TextOne = result.TextOne,
                IsSale = result.IsSale,
                ProductId = result.ProductId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<SliderViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SliderViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    Image = x.Image,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    IsSale = x.IsSale,
                    TextOne = x.TextOne,
                    TextThree = x.TextThree,
                    TextTwo = x.TextTwo,
                    ProductId = x.ProductId
                });
        }

        public IQueryable<SliderViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new SliderViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    Image = x.Image,
                    UpdatedUserId = x.UpdatedUserId,
                    DisplayOrder = x.DisplayOrder,
                    CreatedUserId = x.CreatedUserId,
                    TextTwo = x.TextTwo,
                    TextThree = x.TextThree,
                    TextOne = x.TextOne,
                    IsSale = x.IsSale,
                    ProductId = x.ProductId
                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(SliderViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.TextOne = viewModel.TextOne;
            result.TextTwo = viewModel.TextTwo;
            result.TextThree = viewModel.TextThree;
            result.IsSale = viewModel.IsSale;
            result.ProductId = viewModel.ProductId;

            if (viewModel.Image != null)
                result.Image = viewModel.Image;

            _repository.Update(result);
        }
    }
}
