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
    public class IdentityServices : BaseServices
    {
        private readonly OdevRepository<Identity> _repository;
        public IdentityServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Identity>(unitOfWork);
        }

        public void Add(IdentityViewModel viewModel)
        {
            _repository.Add(new Identity
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                UpdatedUserId = viewModel.UpdatedUserId,
                Language = viewModel.Language,
                Content = viewModel.Content,
                DocumentCategory = viewModel.DocumentCategory,
                Image = viewModel.Image,
                UrlDocument = viewModel.UrlDocument
            });
        }

        public IdentityViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new IdentityViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                UrlDocument = result.UrlDocument,
                Image = result.Image,
                DocumentCategory = result.DocumentCategory,
                Content = result.Content
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<IdentityViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new IdentityViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    Content = x.Content,
                    DocumentCategory = x.DocumentCategory,
                    Image = x.Image,
                    UrlDocument = x.UrlDocument
                });
        }

        public void Update(IdentityViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.Content = viewModel.Content;
            result.DocumentCategory = viewModel.DocumentCategory;

            if (viewModel.Image != null)
                result.Image = viewModel.Image;

            if (viewModel.UrlDocument != null)
                result.UrlDocument = viewModel.UrlDocument;

            _repository.Update(result);
        }
    }
}
