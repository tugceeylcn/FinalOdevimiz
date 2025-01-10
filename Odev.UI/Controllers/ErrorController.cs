using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult PageError()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult Page404()
        {
            ViewBag.ErrorMessage = "Sayfa Bulunamadı";
            ViewBag.ErrorCode = "404";

            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }

        public ActionResult Page403()
        {
            ViewBag.ErrorMessage = "Erişim İzniniz Bulunmamaktadır.";
            ViewBag.ErrorCode = "403";

            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }

        public ActionResult Page500()
        {
            ViewBag.ErrorMessage = "Sunucu Hatası";
            ViewBag.ErrorCode = "500";

            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
    }
}