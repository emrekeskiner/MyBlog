using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult UseRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UseRegister(RegisterViewModel registerViewModel)
        {
            AppUser appUser = new AppUser()
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                Surname = registerViewModel.Surname,
                UserName = registerViewModel.Username
            };

            if (registerViewModel.Password != registerViewModel.ConfirmPassword)
            {
                return View();
            }

            var result = await _userManager.CreateAsync(appUser,registerViewModel.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }else {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
