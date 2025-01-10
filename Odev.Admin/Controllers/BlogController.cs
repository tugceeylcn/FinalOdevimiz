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
    public class BlogController : BaseController
    {
        private readonly BlogServices _BlogServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;
        private readonly CategoryServices _categoryServices;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        public BlogController()
        {
            _BlogServices = new BlogServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
            _categoryServices = new CategoryServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.BlogTransactions)
                {
                    var viewModel = _BlogServices.GetAll();
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
                if (_userTypeViewModel.SubBlogTransactions)
                {
                    ViewBag.Kategoriler = _categoryServices.GetAll().Where(x => x.TopCategoryId == null);

                    return View(ViewForm, new BlogViewModel { IsActive = true });
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
                if (_userTypeViewModel.SubBlogTransactions)
                {
                    var viewModel = _BlogServices.Get(id);
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
                if (_userTypeViewModel.SubBlogTransactions)
                {
                    var result = _BlogServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _BlogServices.Update(result);
                    _BlogServices.Delete(id);
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
        public ActionResult Save(BlogViewModel viewModel, HttpPostedFileBase logo)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubBlogTransactions)
                {
                    var isValid = Validate(viewModel, new BlogValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.UpdatedUserId = _user.UpdatedUserId;
                        if (logo != null)
                        {
                            //var extension = Path.GetExtension(logo.FileName);
                            //string fileName = Guid.NewGuid() + extension;
                            //var urlPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                            //logo.SaveAs(urlPath);
                            //viewModel.BlogImage = fileName;

                            var fileName = ImageUpload(logo);
                            viewModel.BlogImage = fileName;
                        }

                        if (viewModel.Id == Guid.Empty)
                        {
                            _BlogServices.Add(viewModel);
                        }
                        else
                        {
                            _BlogServices.Update(viewModel);
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