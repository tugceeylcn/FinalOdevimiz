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
    public class BlogGalleryController : BaseController
    {
        private readonly BlogGalleryServices _blogGalleryServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;
        private readonly BlogServices _blogServices;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        public BlogGalleryController()
        {
            _blogGalleryServices = new BlogGalleryServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
            _blogServices = new BlogServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.BlogGalleryTransactions)
                {
                    var viewModel = _blogGalleryServices.GetAll();
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
                if (_userTypeViewModel.SubBlogGalleryTransactions)
                {
                    ViewBag.BlogList = _blogServices.GetAll();

                    return View(ViewForm, new BlogGalleryViewModel { IsActive = true });
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
                    var viewModel = _blogGalleryServices.Get(id);
                    ViewBag.BlogList = _blogServices.GetAll();

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
                    var result = _blogGalleryServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _blogGalleryServices.Update(result);
                    _blogGalleryServices.Delete(id);
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
        public ActionResult Save(BlogGalleryViewModel viewModel, HttpPostedFileBase logo)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubBlogTransactions)
                {
                    var isValid = Validate(viewModel, new BlogGalleryValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.UpdatedUserId = _user.UpdatedUserId;
                        if (logo != null)
                        {
                            //var extension = Path.GetExtension(logo.FileName);
                            //string fileName = Guid.NewGuid() + extension;
                            //var urlPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                            //logo.SaveAs(urlPath);
                            //viewModel.Image = fileName;

                            var fileName = ImageUpload(logo);
                            viewModel.Image = fileName;
                        }

                        if (viewModel.Id == Guid.Empty)
                        {
                            _blogGalleryServices.Add(viewModel);
                        }
                        else
                        {
                            _blogGalleryServices.Update(viewModel);
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