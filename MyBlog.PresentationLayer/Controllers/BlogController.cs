using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Net;

namespace MyBlog.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ISubscribeService _subscribeService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        public BlogController(IArticleService articleService, ISubscribeService subscribeService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _subscribeService = subscribeService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            id = 2;
            var values = _articleService.TGetById(id);
            ViewBag.Id = values.ArticleId;
            ViewBag.createdData = values.CreatedDate;
            ViewBag.title = values.Title;
            var userName =await _userManager.FindByIdAsync(values.AppUserId.ToString());
            ViewBag.userName = userName.FullName;
            var values2 = _articleService.TGetArticleWithCategoryByArticleId(id);
            var values3 = _commentService.TGetCommentsByBlog(id).Where(x=>x.Status==true).Count();
            ViewBag.commentCount = values3;
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

        public async Task<IActionResult> AddComment(Comment comment)
        {

            var values = JsonConvert.SerializeObject(comment);
            
            if (string.IsNullOrEmpty(comment.Description))
            {
                return BadRequest(new { error = "Mesaj boş olamaz" });
            }
           


            if (User.Identity.IsAuthenticated)
            {
                var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);
                comment.UserId = userInfo.Id;
                comment.NameSurname = userInfo.Name + " " + userInfo.Surname;

            }
             if (string.IsNullOrEmpty(comment.NameSurname))
            {
                return BadRequest(new { error = "Ad Soyad boş olamaz" });
            }

           _commentService.TInsert(comment);

            return Ok(new { message = "Yorum başarıyla eklendi." });
        }
    }
}
