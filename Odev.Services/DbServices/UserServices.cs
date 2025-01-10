using Odev.DAL.Models;
using Odev.DAL.Repository;
using Odev.DAL.UnitOfWork;
using Odev.Domain.Helpers;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Services.DbServices
{
    public class UserServices : BaseServices
    {
        private readonly OdevRepository<Users> _repository;
        public UserServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<Users>(unitOfWork);
        }

        public void Add(UserViewModel viewModel)
        {
            _repository.Add(new Users
            {
                CreatedDateTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedUserId = Odev.Domain.Environments.Users.CreatedUserId,
                Language = viewModel.Language,
                Email = viewModel.Email,
                NameSurname = viewModel.NameSurname,
                Phone = viewModel.Phone,
                Pwd = viewModel.Pwd,
                UserTypeId = viewModel.UserTypeId
            });
        }

        public UserViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new UserViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                CreatedUserId = result.CreatedUserId,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                Email = result.Email,
                NameSurname = result.NameSurname,
                Phone = result.Phone,
                Pwd = result.Pwd,
                UserTypeId = result.UserTypeId
            };
        }

        public void Delete(Guid id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<UserViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    UpdatedUserId = x.UpdatedUserId,
                    UpdatedDateTime = x.UpdatedDateTime,
                    IsDeleted = x.IsDeleted,
                    IsActive = x.IsActive,
                    CreatedUserId = x.CreatedUserId,
                    CreatedDateTime = x.CreatedDateTime,
                    Language = x.Language,
                    Email = x.Email,
                    UserTypeId = x.UserTypeId,
                    Pwd = x.Pwd,
                    Phone = x.Phone,
                    NameSurname = x.NameSurname
                });
        }

        public void Update(UserViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.Email = viewModel.Email;
            result.UserTypeId = viewModel.UserTypeId;
            result.Pwd = viewModel.Pwd;
            result.Phone = viewModel.Phone;
            result.NameSurname = viewModel.NameSurname;

            _repository.Update(result);
        }
        public UserViewModel SignIn(UserViewModel viewModel)
        {
            var model = _repository.Get(x => x.IsActive && x.Email == viewModel.Email && x.Pwd == viewModel.Pwd);

            if (model == null)
            {
                return null;
            }

            return new UserViewModel
            {
                Id = model.Id,
                NameSurname = model.NameSurname,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                UserTypeId = model.UserTypeId,
            };
        }
    }
}
