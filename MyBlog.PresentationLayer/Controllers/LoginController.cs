using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult UseLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UseLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserProfile", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı Adı veya Şifre");
                }

            }
            return View();
        }
    }
}
