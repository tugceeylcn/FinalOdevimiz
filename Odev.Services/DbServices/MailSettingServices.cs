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
    public class MailSettingServices : BaseServices
    {
        private readonly OdevRepository<MailSetting> _repository;
        public MailSettingServices(OdevUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new OdevRepository<MailSetting>(unitOfWork);
        }
        public MailSettingViewModel Get(Guid Id)
        {
            var result = _repository.Get(x => x.Id == Id);

            return new MailSettingViewModel
            {
                CreatedDateTime = result.CreatedDateTime,
                IsActive = result.IsActive,
                IsDeleted = result.IsDeleted,
                UpdatedDateTime = result.UpdatedDateTime,
                UpdatedUserId = result.UpdatedUserId,
                Id = result.Id,
                Language = result.Language,
                CCMail = result.CCMail,
                Host = result.Host,
                MailAddress = result.MailAddress,
                Password = result.Password,
                Port = result.Port,
                Ssl = result.Ssl
            };
        }

        public void Update(MailSettingViewModel viewModel)
        {
            var result = _repository.Get(x => x.Id == viewModel.Id);

            result.UpdatedDateTime = DateTime.Now;
            result.IsDeleted = viewModel.IsDeleted;
            result.UpdatedUserId = viewModel.UpdatedUserId;
            result.Language = viewModel.Language;
            result.CCMail = viewModel.CCMail;
            result.Host = viewModel.Host;
            result.MailAddress = viewModel.MailAddress;
            result.Password = viewModel.Password;
            result.Port = viewModel.Port;
            result.Ssl = viewModel.Ssl;

            _repository.Update(result);
        }
    }
}
