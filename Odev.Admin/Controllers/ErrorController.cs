using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.Admin.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PageError()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult Page404()
        {
            ViewBag.Kaynak = "Sayfa Bulunamadı";

            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }

        public ActionResult Page403()
        {
            ViewBag.Kaynak = "Erişim İzniniz Bulunmamaktadır.";

            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }

        public ActionResult Page500()
        {
            ViewBag.Kaynak = "Sunucu Hatası";

            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
    }
}