﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IActionResult> MyBlogList() //giriş yapan yazara ait bloglar
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var blog = _articleService.TGetArticlesByWriter(user.Id);
            return View(blog);
        }
    }
}
