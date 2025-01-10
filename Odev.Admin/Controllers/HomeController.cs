using Odev.Services.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly CustomerServices _customerServices;
        private readonly OrderServices _orderServices;
        private readonly BlogServices _blogServices;
        private readonly CustomerNewsletterServices _customerNewsletterServices;

        public HomeController()
        {
            _customerServices = new CustomerServices(_unitOfWork);
            _orderServices = new OrderServices(_unitOfWork);
            _blogServices = new BlogServices(_unitOfWork);
            _customerNewsletterServices = new CustomerNewsletterServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_user != null)
            {
                ViewBag.CustomerCount = _customerServices.GetAll().Count();
                ViewBag.OrderCount = _orderServices.GetAll().Count();
                ViewBag.BlogCount = _blogServices.GetAll().Count();
                ViewBag.CustomerNewsletterCount = _customerNewsletterServices.GetAll().Count();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}