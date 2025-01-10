using Odev.Domain.Validations;
using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.Admin.Controllers
{
    public class SettingController : BaseController
    {
        private readonly SettingServices _SettingsServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;

        private readonly string ViewForm = "Form";

        public SettingController()
        {
            _SettingsServices = new SettingServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
        }

        public ActionResult Edit(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubSettingTransactions)
                {
                    var viewModel = _SettingsServices.Get(id);
                    return View(ViewForm, viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Save(SettingViewModel viewModel)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubSettingTransactions)
                {
                    var isValid = Validate(viewModel, new SettingValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == Guid.Empty)
                        {
                            _SettingsServices.Add(viewModel);
                        }
                        else
                        {
                            viewModel.UpdatedUserId = _user.UpdatedUserId;
                            _SettingsServices.Update(viewModel);
                        }

                        _unitOfWork.SaveChanges();
                        return RedirectToAction("/Edit?id=125DD2CE-8941-4EE7-A04D-E6B002724D36");
                    }
                    else
                    {
                        return View(ViewForm, viewModel);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}