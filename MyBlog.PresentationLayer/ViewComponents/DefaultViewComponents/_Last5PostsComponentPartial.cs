using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _Last5PostsComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _Last5PostsComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            //var last5Posts=_articleService.TGetListAll().Take(5).ToList();  
            var last5Posts = _articleService.TGetArticlesWithCategory()
                .Take(5)
                .OrderByDescending(x=>x.ArticleId)
                .ToList();
            return View(last5Posts);
        }
    }
}
