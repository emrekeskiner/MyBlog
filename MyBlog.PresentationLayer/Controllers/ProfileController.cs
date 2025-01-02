using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> UserProfile()
        {

            if (User.Identity.IsAuthenticated)
             {
                var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userId = userInfo.Id;
                ViewBag.fullName = userInfo.Name + " " + userInfo.Surname;
             }
          
            return View();
        }
    }
}
