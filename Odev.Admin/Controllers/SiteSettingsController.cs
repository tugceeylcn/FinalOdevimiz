using Odev.Domain.Environments;
using Odev.Domain.Validations;
using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.Admin.Controllers
{
    public class SiteSettingsController : BaseController
    {
        private readonly SiteSettingServices _siteSettingsServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        public SiteSettingsController()
        {
            _siteSettingsServices = new SiteSettingServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SiteSettingTransactions)
                {
                    var viewModel = _siteSettingsServices.GetAll();
                    return View(ViewList, viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult New()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubSiteSettingTransactions)
                {
                    return View(ViewForm, new SiteSettingViewModel { IsActive = true });
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Edit(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubSiteSettingTransactions)
                {
                    var viewModel = _siteSettingsServices.Get(id);
                    return View(ViewForm, viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public JsonResult SitesettingList()
        {
            var serviceResult = _siteSettingsServices.GetAll().ToList();
            return Json(serviceResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubSiteSettingTransactions)
                {
                    var result = _siteSettingsServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _siteSettingsServices.Update(result);
                    _siteSettingsServices.Delete(id);
                    _unitOfWork.SaveChanges();

                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Save(SiteSettingViewModel viewModel, HttpPostedFileBase logo)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubSiteSettingTransactions)
                {
                    var isValid = Validate(viewModel, new SiteSettingValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.UpdatedUserId = _user.UpdatedUserId;
                        if (logo != null)
                        {
                            var extension = Path.GetExtension(logo.FileName);
                            string fileName = Guid.NewGuid() + extension;
                            var urlPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                            logo.SaveAs(urlPath);
                            viewModel.Logo = fileName;
                        }

                        if (viewModel.Id == Guid.Empty)
                        {
                            _siteSettingsServices.Add(viewModel);
                        }
                        else
                        {
                            _siteSettingsServices.Update(viewModel);
                        }

                        _unitOfWork.SaveChanges();
                        return RedirectToAction("Index");
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