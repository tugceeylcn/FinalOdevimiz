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
    public class ProductController : BaseController
    {
        private readonly ProductServices _ProductServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;
        private readonly CategoryServices _categoryServices;
        private readonly ColorServices _colorServices;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        public ProductController()
        {
            _ProductServices = new ProductServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
            _categoryServices = new CategoryServices(_unitOfWork);
            _colorServices = new ColorServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.ProductTransactions)
                {
                    var viewModel = _ProductServices.GetAll();
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
                if (_userTypeViewModel.SubProductTransactions)
                {
                    ViewBag.Kategoriler = _categoryServices.GetAll().Where(x => x.TopCategoryId == null).OrderBy(x => x.DisplayOrder);
                    ViewBag.Renkler = _colorServices.GetAll().OrderBy(x => x.DisplayOrder);

                    int displayOrder = _ProductServices.NewDisplayOrder();

                    return View(ViewForm, new ProductViewModel { IsActive = true, DisplayOrder = displayOrder });
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
                if (_userTypeViewModel.SubProductTransactions)
                {
                    ViewBag.Kategoriler = _categoryServices.GetAll().Where(x => x.TopCategoryId == null).OrderBy(x => x.DisplayOrder);
                    ViewBag.Renkler = _colorServices.GetAll().OrderBy(x => x.DisplayOrder);

                    var viewModel = _ProductServices.Get(id);
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
            var serviceResult = _ProductServices.GetAll().ToList();
            return Json(serviceResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubProductTransactions)
                {
                    var result = _ProductServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _ProductServices.Update(result);
                    _ProductServices.Delete(id);
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
        public ActionResult Save(ProductViewModel viewModel, HttpPostedFileBase productImage)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubProductTransactions)
                {
                    var isValid = Validate(viewModel, new ProductValidator(), ModelState);
                    if (isValid)
                    {
                        if (productImage != null)
                        {
                            //var extension = Path.GetExtension(productImage.FileName);
                            //string fileName = Guid.NewGuid() + extension;
                            //var urlPath = Path.Combine(Server.MapPath(Globals.FileURL), fileName);
                            //productImage.SaveAs(urlPath);
                            //viewModel.ProductCoverImage = fileName;

                            var fileName = ImageUpload(productImage);
                            viewModel.ProductCoverImage = fileName;
                        }
                        if (viewModel.Id == Guid.Empty)
                        {
                            _ProductServices.Add(viewModel);
                        }
                        else
                        {
                            viewModel.UpdatedUserId = _user.UpdatedUserId;
                            _ProductServices.Update(viewModel);
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