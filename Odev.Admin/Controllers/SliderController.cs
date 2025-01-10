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
    public class SliderController : BaseController
    {
        private readonly SliderServices _sliderServices;
        private readonly UserTypeServices _userTypeServices;
        private UserTypeViewModel _userTypeViewModel;

        private readonly string ViewList = "List";
        private readonly string ViewForm = "Form";

        public SliderController()
        {
            _sliderServices = new SliderServices(_unitOfWork);
            _userTypeServices = new UserTypeServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SliderTransactions)
                {
                    var viewModel = _sliderServices.GetAll();
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
                if (_userTypeViewModel.SubSliderTransactions)
                {
                    return View(ViewForm, new SliderViewModel { IsActive = true });
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
                if (_userTypeViewModel.SubSliderTransactions)
                {
                    var viewModel = _sliderServices.Get(id);
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
            var serviceResult = _sliderServices.GetAll().ToList();
            return Json(serviceResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Guid id)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubSliderTransactions)
                {
                    var result = _sliderServices.Get(id);
                    result.UpdatedUserId = _user.UpdatedUserId;
                    _sliderServices.Update(result);
                    _sliderServices.Delete(id);
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
        public ActionResult Save(SliderViewModel viewModel, HttpPostedFileBase image)
        {
            SessionKontrol();
            if (_user != null)
            {
                _userTypeViewModel = _userTypeServices.Get(_user.UserTypeId);
                if (_userTypeViewModel.SubSliderTransactions)
                {
                    var isValid = Validate(viewModel, new SliderValidator(), ModelState);
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
                            _sliderServices.Add(viewModel);
                        }
                        else
                        {
                            _sliderServices.Update(viewModel);
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