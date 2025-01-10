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
    public class ColorServices : BaseServices
    {
        private readonly OdevRepository<Color> _repository;
        public ColorServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Color>(unitOfWork);
        }

        public void Add(ColorViewModel viewModel)
        {
            _repository.Add(new Color
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                Language = viewModel.Language,
                ColorName = viewModel.ColorName,
                CreatedUserId = Domain.Environments.Users.CreatedUserId,
                Id = Guid.NewGuid(),
                DisplayOrder = viewModel.DisplayOrder
            });
        }

        public ColorViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new ColorViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                ColorName = result.ColorName,
                CreatedUserId = result.CreatedUserId,
                DisplayOrder = result.DisplayOrder
            };
        }

        public IQueryable<ColorViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new ColorViewModel
                {
                    Id = x.Id,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    IsActive = x.IsActive,
                    ColorName = x.ColorName,
                    CreatedUserId = x.CreatedUserId,
                    DisplayOrder = x.DisplayOrder
                });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public void Update(ColorViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.DisplayOrder = viewModel.DisplayOrder;
            result.ColorName = viewModel.ColorName;

            _repository.Update(result);
        }
    }
}
