using Odev.Services.DbServices;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ProductServices _productServices;
        private readonly CategoryServices _categoryServices;
        private readonly SettingServices _settingsServices;
        private readonly ColorServices _colorServices;
        private readonly ProductAttributeServices _productAttributeServices;
        private readonly AttributeServices _attributeServices;
        private readonly ProductImageServices _productImageServices;

        private readonly string ViewIndex = "Index";

        public ProductController()
        {
            _productServices = new ProductServices(_unitOfWork);
            _categoryServices = new CategoryServices(_unitOfWork);
            _settingsServices = new SettingServices(_unitOfWork);
            _colorServices = new ColorServices(_unitOfWork);
            _productAttributeServices = new ProductAttributeServices(_unitOfWork);
            _attributeServices = new AttributeServices(_unitOfWork);
            _productImageServices = new ProductImageServices(_unitOfWork);
        }

        public ActionResult List(Guid? categoryId, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 15;

            IPagedList result;
            if (categoryId == null || categoryId == Guid.Empty)
            {
                result = _productServices.GetAll().OrderBy(b => b.DisplayOrder).ToPagedList(pageNumber, pageSize);
            }
            else
            {
                result = _productServices.GetAllByFilter(categoryId.Value).OrderBy(b => b.DisplayOrder).ToPagedList(pageNumber, pageSize);
            }

            ViewBag.AllCategories = _categoryServices.GetAll().Where(x => x.TopCategoryId == null).ToList();
            ViewBag.AllColor = _colorServices.GetAll().ToList();
            ViewBag.Setting = _settingsServices.GetAll().FirstOrDefault();

            ViewBag.MaxProductPrice = _productServices.MaxProductPrice();
            ViewBag.MinProductPrice = _productServices.MinProductPrice();

            return View(ViewIndex, result);
        }

        public ActionResult Detail(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = _productServices.Get(id);
            if (viewModel == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var categoryList = _categoryServices.GetAllTopCategory().OrderBy(x => x.DisplayOrder).ToList();
            ViewBag.categories = categoryList.Where(x => x.Count > 0).ToList();
            ViewBag.IsPopularProducts = _productServices.GetAll().Where(x => x.IsPopular).OrderBy(x => x.DisplayOrder).Take(10).ToList();
            ViewBag.ProductImages = _productImageServices.GetAll().Where(x => x.IsActive && !x.IsDeleted).ToList();
            ViewBag.ProductAttribute = _productAttributeServices.GetAll().Where(x => x.IsActive && !x.IsDeleted && x.ProductId == id).ToList();

            return View(viewModel);
        }
    }
}