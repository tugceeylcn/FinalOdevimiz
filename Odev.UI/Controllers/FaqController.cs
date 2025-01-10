using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class FaqController : BaseController
    {
        // GET: Faq
        public ActionResult Index()
        {
            return View();
        }
    }
}