using Odev.Domain.Enums;
using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly SliderServices _sliderServices;
        private readonly SubscribeMemberServices _subscribeMemberServices;
        private readonly CategoryServices _categoryServices;
        private readonly GeneralPageServices _generalPageServices;
        private readonly ProductServices _productServices;
        private readonly BlogServices _blogServices;
        private readonly BlogCommentServices _blogCommentServices;

        public HomeController()
        {
            _sliderServices = new SliderServices(_unitOfWork);
            _subscribeMemberServices = new SubscribeMemberServices(_unitOfWork);
            _categoryServices = new CategoryServices(_unitOfWork);
            _generalPageServices = new GeneralPageServices(_unitOfWork);
            _productServices = new ProductServices(_unitOfWork);
            _blogServices = new BlogServices(_unitOfWork);
            _blogCommentServices = new BlogCommentServices(_unitOfWork);
        }
        public async Task<ActionResult> Index()
        {
            var result = SelectLanguage();
            ViewBag.Slider = _sliderServices.ListLang(SelectLanguage()).OrderByDescending(x => x.Id);
            ViewBag.populerCategories = _categoryServices.GetAll().Where(x => x.IsPopular).ToList();
            ViewBag.about = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == (PageName)1).FirstOrDefault();
            ViewBag.BestSellingProducts = _productServices.GetAll().OrderBy(x => x.TotalSaleCount).ThenBy(x => x.DisplayOrder).Take(10).ToList();
            ViewBag.DiscountedProducts = _productServices.GetAll().Where(x => x.ProductFirstPrice != 0).OrderBy(x => x.DisplayOrder).Take(10).ToList();
            ViewBag.IsPopularProducts = _productServices.GetAll().Where(x => x.IsPopular).OrderBy(x => x.DisplayOrder).Take(50).ToList();


            ViewBag.BlogList = _blogServices.ListLang(SelectLanguage()).OrderByDescending(x => x.Id).ToList();
            ViewBag.about = _generalPageServices.GetAll().Where(x => x.Language == (LanguageSelection)result && x.Page == (PageName)1).FirstOrDefault();
            ViewBag.BlogCommentList = _blogCommentServices.ListLang(SelectLanguage()).OrderByDescending(x => x.Id).ToList();

            return View();
        }

        public ActionResult Views(Guid id)
        {
            var result = _sliderServices.Get(id);
            return View(result);
        }

        public ActionResult Subscribe(SubscribeMemberViewModel viewModel)
        {
            _subscribeMemberServices.Add(viewModel);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}