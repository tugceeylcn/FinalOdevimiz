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
    public class DocumentServices : BaseServices
    {
        private readonly OdevRepository<Document> _repository;
        public DocumentServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Document>(unitOfWork);
        }

        public void Add(DocumentViewModel viewModel)
        {
            _repository.Add(new Document
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
                UpdatedUserId = viewModel.UpdatedUserId,
                Language = viewModel.Language,
                Title = viewModel.Title,
                DocumentCategory = viewModel.DocumentCategory,
                DocumentDate = viewModel.DocumentDate,
                Url = viewModel.Url
            });
        }

        public DocumentViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new DocumentViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Title = result.Title,
                Language = result.Language,
                Url = result.Url,
                DocumentDate = result.DocumentDate,
                DocumentCategory = result.DocumentCategory
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<DocumentViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new DocumentViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    UpdatedUserId = x.UpdatedUserId,
                    Language = x.Language,
                    Title = x.Title,
                    DocumentCategory = x.DocumentCategory,
                    DocumentDate = x.DocumentDate,
                    Url = x.Url
                });
        }

        public IQueryable<DocumentViewModel> ListLang(int? lang)
        {
            return _repository.GetList()
                .Select(x => new DocumentViewModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    UpdatedDateTime = x.UpdatedDateTime,
                    CreatedDateTime = x.CreatedDateTime,
                    IsDeleted = x.IsDeleted,
                    Language = x.Language,
                    Title = x.Title,
                    Url = x.Url,
                    DocumentCategory = x.DocumentCategory,
                    DocumentDate = x.DocumentDate,
                    UpdatedUserId = x.UpdatedUserId

                }).Where(x => x.Language == (LanguageSelection)lang && x.IsActive == true);
        }

        public void Update(DocumentViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Title = viewModel.Title;
            result.Language = viewModel.Language;

            if (viewModel.Url != null)
                result.Url = viewModel.Url;

            result.DocumentDate = viewModel.DocumentDate;
            result.DocumentCategory = viewModel.DocumentCategory;

            _repository.Update(result);
        }
    }
}
