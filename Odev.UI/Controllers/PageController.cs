using Odev.Domain.Enums;
using Odev.Services.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class PageController : BaseController
    {
        private readonly GeneralPageServices _generalPageServices;
        private readonly string ViewDetail = "Detail";

        public PageController()
        {
            _generalPageServices = new GeneralPageServices(_unitOfWork);
        }

        public ActionResult FrequentlyAskedQuestions()
        {
            var result = SelectLanguage();
            var viewModel = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == PageName.FrequentlyAskedQuestions).FirstOrDefault();

            return View(ViewDetail, viewModel);
        }

        public ActionResult Career()
        {
            var result = SelectLanguage();
            var viewModel = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == PageName.Career).FirstOrDefault();

            return View(ViewDetail, viewModel);
        }

        public ActionResult DistanceSellingAgreement()
        {
            var result = SelectLanguage();
            var viewModel = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == PageName.DistanceSellingAgreement).FirstOrDefault();

            return View(ViewDetail, viewModel);
        }

        public ActionResult Kvkk()
        {
            var result = SelectLanguage();
            var viewModel = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == PageName.Kvkk).FirstOrDefault();

            return View(ViewDetail, viewModel);
        }

        public ActionResult CancelReturn()
        {
            var result = SelectLanguage();
            var viewModel = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == PageName.CancelReturn).FirstOrDefault();

            return View(ViewDetail, viewModel);
        }

        public ActionResult CookiePolicy()
        {
            var result = SelectLanguage();
            var viewModel = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == PageName.CookiePolicy).FirstOrDefault();

            return View(ViewDetail, viewModel);
        }

        public ActionResult MembershipAgreement()
        {
            var result = SelectLanguage();
            var viewModel = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == PageName.MembershipAgreement).FirstOrDefault();

            return View(ViewDetail, viewModel);
        }

        public ActionResult PrivacyPolicy()
        {
            var result = SelectLanguage();
            var viewModel = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == PageName.PrivacyPolicy).FirstOrDefault();

            return View(ViewDetail, viewModel);
        }
    }
}