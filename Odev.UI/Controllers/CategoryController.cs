using Odev.Services.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly CategoryServices _categoryServices;
        private readonly string ViewIndex = "Index";

        public CategoryController()
        {
            _categoryServices = new CategoryServices(_unitOfWork);
        }

        public ActionResult List()
        {
            var result = _categoryServices.GetAll().Where(x => x.TopCategoryId == null).ToList();
            return View(ViewIndex, result);
        }
    }
}