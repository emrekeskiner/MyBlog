using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.ViewComponents.AdminViewComponents
{
    public class _AdminNavbarUserPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminNavbarUserPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = user.FullName;
            ViewBag.userImage = "/userimage/"+user.ImageUrl;

            return View();
        }
    
    }
}
