using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Blog")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
        }
        [Route("MyBlogList")]
        public async Task<IActionResult> MyBlogList() //giriş yapan yazara ait bloglar
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var blog = _articleService.TGetArticlesWithCategoryByWriter(user.Id).OrderByDescending(x => x.CreatedDate).ToList();
            return View(blog);
        }
        [Route("DeleteBlog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("MyBlogList", "Blog", new {area="Writer"});

        }

        [HttpGet]
        [Route("UpdateBlog/{id}")]
        public IActionResult UpdateBlog(int id)
        {
            List<SelectListItem> category = (from i in _categoryService.TGetListAll()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            var values = _articleService.TGetById(id);

            return View(values);
        }

        [HttpPost]
        [Route("UpdateBlog/{id}")]
        public IActionResult UpdateBlog(Article article)
        {
            _articleService.TUpdate(article);

            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
        }

        [HttpGet]
        [Route("CreateBlog")]
        public IActionResult CreateBlog()
        {
            List<SelectListItem> category = new List<SelectListItem>();
            category.Add(new SelectListItem
            {
                Text = "Kategori Seçiniz",
                Value = "",
                Selected = true
            });

            category.AddRange(from i in _categoryService.TGetListAll()
                              select new SelectListItem
                              {
                                  Text = i.CategoryName,
                                  Value = i.CategoryId.ToString()
                              });

            
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        [Route("CreateBlog")]
        public async Task<IActionResult> CreateBlog(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            article.CreatedDate = DateTime.Now;
            article.AppUserId = user.Id;

            _articleService.TInsert(article);
            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
        }
    }
}
