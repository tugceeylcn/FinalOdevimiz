using Odev.DAL.UnitOfWork;
using Odev.Domain.Enums;
using Odev.Domain.Helpers;
using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class BaseController : Controller
    {
        public CustomersViewModel _customer;
        public readonly OdevUnitOfWork _unitOfWork;

        public string lang = null;

        private readonly SiteSettingServices _siteSettingsServices;
        private readonly SolutionPartnersServices _solutionPartnersServices;
        private readonly CategoryServices _categoryServices;
        private readonly SettingServices _settingsServices;
        private readonly GeneralPageServices _generalPageServices;

        public BaseController()
        {
            _unitOfWork = new OdevUnitOfWork();
            _siteSettingsServices = new SiteSettingServices(_unitOfWork);
            _solutionPartnersServices = new SolutionPartnersServices(_unitOfWork);
            _categoryServices = new CategoryServices(_unitOfWork);
            _settingsServices = new SettingServices(_unitOfWork);
            _generalPageServices = new GeneralPageServices(_unitOfWork);

            ViewBag.about = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)1 && x.Page == (PageName)1).FirstOrDefault();
        }

        public CustomersViewModel SessionKontrol()
        {
            _customer = (CustomersViewModel)Session["customer"];
            return _customer;
        }

        public ActionResult ChangeLanguage(string lang)
        {
            new SiteLanguages().SetLanguage(lang);
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValidator"></typeparam>
        /// <param name="model">ViewModel -> ViewModel Gönder</param>
        /// <param name="validator">yazılan validator ı gönder </param>
        /// <param name="modelState">view den gelen bilgileri gönder</param>
        /// <returns></returns>
        public bool Validate<TModel, TValidator>(TModel model, TValidator validator, ModelStateDictionary modelState)
          where TValidator : AbstractValidator<TModel>
        {
            ValidationResult result = validator.Validate(model);

            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return result.IsValid;
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            ViewBag.solutionPartners = _solutionPartnersServices.GetAll().ToList();
            ViewBag.AllCategories = _categoryServices.GetAll().ToList();
            ViewBag.Setting = _settingsServices.GetAll().FirstOrDefault();

            HttpCookie httpCookie = Request.Cookies["culture"];
            if (httpCookie != null)
            {
                lang = httpCookie.Value;
                switch (lang)
                {
                    case "en":
                        ViewBag.SiteSetting = _siteSettingsServices.GetLang(2);
                        break;

                    default:
                        ViewBag.SiteSetting = _siteSettingsServices.GetLang(1);
                        break;
                }
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != null)
                {
                    lang = userLang;
                    switch (lang)
                    {
                        case "en":
                            ViewBag.SiteSetting = _siteSettingsServices.GetLang(2);
                            break;

                        default:
                            ViewBag.SiteSetting = _siteSettingsServices.GetLang(1);
                            break;
                    }
                }
                else
                {
                    lang = SiteLanguages.GetDefaultLanguage();
                    switch (lang)
                    {
                        case "en":
                            ViewBag.SiteSetting = _siteSettingsServices.GetLang(2);
                            break;

                        default:
                            ViewBag.SiteSetting = _siteSettingsServices.GetLang(1);
                            break;
                    }
                }
            }
            new SiteLanguages().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }

        public int SelectLanguage()
        {
            HttpCookie httpCookie = Request.Cookies["culture"];
            if (httpCookie != null)
            {
                lang = httpCookie.Value;
                switch (lang)
                {
                    case "en":
                        return 2;

                    default:
                        return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        public string GetClientIpAddress()
        {
            string ip = Request.UserHostAddress;

            // X-Forwarded-For başlığı varsa, gerçek istemci IP adresini elde etmek için kullanabilirsiniz
            string forwardedFor = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(forwardedFor))
            {
                string[] ipArray = forwardedFor.Split(',');
                if (ipArray.Length > 0)
                {
                    ip = ipArray[0].Trim();
                }
            }

            return ip;
        }
    }
}