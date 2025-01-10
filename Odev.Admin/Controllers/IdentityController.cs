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
    public class IdentityController : BaseController
    {
        private readonly IdentityServices _identityServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        public IdentityController()
        {
            _identityServices = new IdentityServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.IdentityTransactions)
                {
                    var viewModel = _identityServices.GetAll();
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
                if (_userTypeViewModel.SubIdentityTransactions)
                {
                    return View(ViewForm, new IdentityViewModel { IsActive = true });
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
                if (_userTypeViewModel.SubIdentityTransactions)
                {
                    var viewModel = _identityServices.Get(id);
                    return View(ViewForm, viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public JsonResult IdentityList()
        {
            var serviceResult = _identityServices.GetAll().ToList();
            return Json(serviceResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubIdentityTransactions)
                {
                    var result = _identityServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _identityServices.Update(result);
                    _identityServices.Delete(id);
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
        public ActionResult Save(IdentityViewModel viewModel, HttpPostedFileBase urlDocument, HttpPostedFileBase image)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubIdentityTransactions)
                {
                    var isValid = Validate(viewModel, new IdentityValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.UpdatedUserId = _user.UpdatedUserId;
                        if (urlDocument != null)
                        {
                            var extension = Path.GetExtension(urlDocument.FileName);
                            string fileName = Guid.NewGuid() + extension;
                            var urlPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                            urlDocument.SaveAs(urlPath);
                            viewModel.UrlDocument = fileName;
                        }
                        if (image != null)
                        {
                            var extension = Path.GetExtension(image.FileName);
                            string fileName = Guid.NewGuid() + extension;
                            var urlPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                            image.SaveAs(urlPath);
                            viewModel.Image = fileName;
                        }
                        if (viewModel.Id == Guid.Empty)
                        {
                            _identityServices.Add(viewModel);
                        }
                        else
                        {
                            _identityServices.Update(viewModel);
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