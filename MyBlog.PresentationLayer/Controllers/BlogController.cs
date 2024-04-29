using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Newtonsoft.Json;

namespace MyBlog.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ISubscribeService _subscribeService;
        public BlogController(IArticleService articleService, ISubscribeService subscribeService)
        {
            _articleService = articleService;
            _subscribeService = subscribeService;
        }

        public IActionResult BlogDetail(int id)
        {
            id = 2;
            var values = _articleService.TGetById(id);
            ViewBag.createdData = values.CreatedDate;
            ViewBag.title = values.Title;
            var values2 = _articleService.TGetArticleWithCategoryByArticleId(id);
            ViewBag.categoryName = values2.Category.CategoryName;
            ViewBag.detail = values.Detail;
            return View();
        }

        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            var values = JsonConvert.SerializeObject(subscribe);
            if (subscribe.SubscribeMail == null)
            {
                return NotFound();
            }
            
            _subscribeService.TInsert(subscribe);

            return Json(values);
        }
    }
}
