using Odev.DAL.UnitOfWork;
using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using System;
using System.Web;
using System.Web.Mvc;

namespace Odev.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly OdevUnitOfWork _unitOfWork;
        private readonly UserServices _userServices;

        public LoginController()
        {
            _unitOfWork = new OdevUnitOfWork();
            _userServices = new UserServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn(UserViewModel viewModel)
        {
            var user = _userServices.SignIn(viewModel);
            if (user == null)
            {
                TempData["Error"] = "Girmiş olduğunuz Email sistemde mevcut değil veya Email/Şifre hatalı !!!";
                return Redirect("/Login/");
            }
            else
            {
                Session.Add("user", user);
                Session.Timeout = 60;

                HttpCookie cookie = new HttpCookie("user");
                cookie.Values.Add("logintime", DateTime.Now.ToString());
                cookie.Expires = DateTime.Now.AddHours(60);
                Response.Cookies.Add(cookie);

                return Redirect("/Home/");
            }
        }

        public ActionResult SignOut()
        {
            Session.Abandon();
            return Redirect("/");
        }
    }
}