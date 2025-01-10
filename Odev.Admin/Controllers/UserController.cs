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
    public class UserController : BaseController
    {
        private readonly UserServices _userServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        public UserController()
        {
            _userServices = new UserServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.UsersTransactions)
                {
                    var viewModel = _userServices.GetAll();
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
                if (_userTypeViewModel.UsersTransactions)
                {
                    return View(ViewForm, new UserViewModel { IsActive = true });
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
                if (_userTypeViewModel.UsersTransactions)
                {
                    var viewModel = _userServices.Get(id);
                    viewModel.Pwd = null;
                    return View(ViewForm, viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public JsonResult UserList()
        {
            var serviceResult = _userServices.GetAll().ToList();
            return Json(serviceResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.UsersTransactions)
                {
                    var result = _userServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _userServices.Update(result);
                    _userServices.Delete(id);
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

        public ActionResult Save(UserViewModel viewModel)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.UsersTransactions)
                {
                    var isValid = Validate(viewModel, new UserValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.UpdatedUserId = _user.UpdatedUserId;
                        if (viewModel.Id == Guid.Empty)
                        {
                            _userServices.Add(viewModel);
                        }
                        else
                        {
                            _userServices.Update(viewModel);
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

        public ActionResult Profil()
        {
            SessionKontrol();
            if (_user != null)
            {
                var viewModel = _userServices.Get(_user.Id);
                return View("Profil", viewModel);
            }
            else
            {
                ViewBag.UserType = _userTypeServices.GetAll();
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult ProfilUpdate(UserViewModel viewModel)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userServices.Update(viewModel);

                _unitOfWork.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}