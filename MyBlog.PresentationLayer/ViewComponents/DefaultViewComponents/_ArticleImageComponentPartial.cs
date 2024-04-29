using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _ArticleImageComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleImageComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetListAll().Take(6).ToList();
            return View(values);
        }
    }
}
