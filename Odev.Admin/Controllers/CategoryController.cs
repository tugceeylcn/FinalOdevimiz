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
    public class CategoryController : BaseController
    {
        private readonly CategoryServices _categoryServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        public CategoryController()
        {
            _categoryServices = new CategoryServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.CategoryTransactions)
                {
                    var viewModel = _categoryServices.GetAll();
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
                if (_userTypeViewModel.SubCategoryTransactions)
                {
                    ViewBag.Kategoriler = _categoryServices.GetAll().Where(x => x.TopCategoryId == null);

                    return View(ViewForm, new CategoryViewModel { IsActive = true });
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
                if (_userTypeViewModel.SubCategoryTransactions)
                {
                    var viewModel = _categoryServices.Get(id);
                    ViewBag.Kategoriler = _categoryServices.GetAll().Where(x => x.TopCategoryId == null);

                    return View(ViewForm, viewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Delete(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubCategoryTransactions)
                {
                    var result = _categoryServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _categoryServices.Update(result);
                    _categoryServices.Delete(id);
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

        public ActionResult Save(CategoryViewModel viewModel, HttpPostedFileBase logo)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubCategoryTransactions)
                {
                    var isValid = Validate(viewModel, new CategoryValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.UpdatedUserId = _user.UpdatedUserId;
                        if (logo != null)
                        {
                            var extension = Path.GetExtension(logo.FileName);
                            string fileName = Guid.NewGuid() + extension;
                            var urlPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                            logo.SaveAs(urlPath);
                            viewModel.CategoryImage = fileName;
                        }

                        if (viewModel.Id == Guid.Empty)
                        {
                            _categoryServices.Add(viewModel);
                        }
                        else
                        {
                            _categoryServices.Update(viewModel);
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