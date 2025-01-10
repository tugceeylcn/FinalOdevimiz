using Odev.Domain.Enums;
using Odev.Domain.Helpers;
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
    public class GeneralPageController : BaseController
    {
        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        private readonly GeneralPageServices _generalPageServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;

        public GeneralPageController()
        {
            _generalPageServices = new GeneralPageServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
        }

        public ActionResult Index(int Page)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.GeneralPageTransactions)
                {
                    var result = _generalPageServices.GetAll().Where(x => x.Page == (PageName)Page);
                    Session.Add("PageName", ((PageName)Page).GetDisplayName());
                    Session.Add("PageId", Page);
                    return View(ViewList, result);
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
                if (_userTypeViewModel.SubGeneralPageTransactions)
                {
                    return View(ViewForm, new GeneralPageViewModel { IsActive = true });
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
                if (_userTypeViewModel.SubGeneralPageTransactions)
                {
                    var viewModel = _generalPageServices.Get(id);
                    return View(ViewForm, viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public JsonResult ChosenMosqueList(int page)
        {
            var serviceResult = _generalPageServices.GetAll().Where(x => x.Page == (PageName)page).ToList();
            return Json(serviceResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubGeneralPageTransactions)
                {
                    var result = _generalPageServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _generalPageServices.Update(result);
                    _generalPageServices.Delete(id);
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

        [ValidateInput(false)]
        public ActionResult Save(GeneralPageViewModel viewModel, int? Page, HttpPostedFileBase image)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubGeneralPageTransactions)
                {
                    var isValid = Validate(viewModel, new GeneralPageValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.UpdatedUserId = _user.UpdatedUserId;
                        if (image != null)
                        {
                            //var extension = Path.GetExtension(image.FileName);
                            //string fileName = Guid.NewGuid() + extension;
                            //var urlPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                            //image.SaveAs(urlPath);
                            //viewModel.Image = fileName;

                            var fileName = ImageUpload(image);
                            viewModel.Image = fileName;
                        }
                        if (viewModel.Id == Guid.Empty)
                        {
                            _generalPageServices.Add(viewModel, (int)Page);
                        }
                        else
                        {
                            _generalPageServices.Update(viewModel);
                        }

                        _unitOfWork.SaveChanges();
                        return RedirectToAction("Index", new { Page = Session["PageId"] });
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