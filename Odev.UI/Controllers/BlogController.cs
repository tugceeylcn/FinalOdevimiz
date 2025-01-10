using Odev.Domain.ViewModels;
using Odev.Services.DbServices;
using PagedList;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odev.UI.Controllers
{
    public class BlogController : BaseController
    {
        private readonly BlogServices _blogServices;
        private readonly BlogCommentServices _blogCommentServices;
        private readonly BlogGalleryServices _blogGalleryServices;
        private readonly CategoryServices _categoryServices;

        public BlogController()
        {
            _blogServices = new BlogServices(_unitOfWork);
            _blogCommentServices = new BlogCommentServices(_unitOfWork);
            _categoryServices = new CategoryServices(_unitOfWork);
            _blogGalleryServices = new BlogGalleryServices(_unitOfWork);
        }

        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4; // Sayfa başına kaç öğe gösterileceğini belirleyin

            var viewModel = _blogServices.GetAll().OrderBy(b => b.DisplayOrder).ToPagedList(pageNumber, pageSize);
            foreach (var item in viewModel)
            {
                item.BlogContent = HttpUtility.HtmlDecode(item.BlogContent);
            }

            return View(viewModel);
        }

        public ActionResult List(Guid categoriId, int? page)
        {
            if (categoriId == null || categoriId == Guid.Empty)
            {
                return RedirectToAction("Index", "Blog");
            }

            int pageNumber = page ?? 1;
            int pageSize = 4; // Sayfa başına kaç öğe gösterileceğini belirleyin

            var viewModel = _blogServices.GetAllByCategoryId(categoriId).OrderBy(b => b.DisplayOrder).ToPagedList(pageNumber, pageSize);
            if (viewModel == null)
            {
                return RedirectToAction("Index", "Blog");
            }

            foreach (var item in viewModel)
            {
                item.BlogContent = HttpUtility.HtmlDecode(item.BlogContent);
            }

            return View(viewModel);
        }

        public ActionResult Detail(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = _blogServices.Get(id);
            if (viewModel == null)
            {
                return RedirectToAction("Index", "Home");
            }

            viewModel.BlogContent = HttpUtility.HtmlDecode(viewModel.BlogContent);

            var categoryList = _categoryServices.GetAllTopCategory().OrderBy(x => x.DisplayOrder).ToList();
            foreach (var item in categoryList)
            {
                item.Count = _blogServices.GetAllByCategoryId(item.Id).Count();
            }

            ViewBag.categories = categoryList.Where(x => x.Count > 0).ToList();
            ViewBag.Comments = _blogCommentServices.GetAllByBlogId(id).ToList();
            ViewBag.blogGalleries = _blogGalleryServices.GetAllByBlogId(id).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CommentSave(BlogCommentViewModel viewModel)
        {
            SessionKontrol();
            if (_customer != null)
            {
                viewModel.FirstLastName = $"{_customer.CustomerFirstName} {_customer.CustomerLastName}";
                viewModel.CustomerId = _customer.Id;
                viewModel.Email = _customer.CustomerEmail;
            }

            _blogCommentServices.Add(viewModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction($"Detail?id={viewModel.BlogId}", "Blog");
        }
    }
}