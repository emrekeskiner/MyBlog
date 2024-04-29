using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Writer.Models;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers;

[Area("Writer")]
[Route("Writer/Profile")]
public class ProfileController : Controller
{

    private readonly UserManager<AppUser> _userManager;

    public ProfileController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    [Route("WriterProfile")]
    public async Task<IActionResult> WriterProfile()
    {
        var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.userId = userInfo.Id;
        ViewBag.fullName = userInfo.Name + " " + userInfo.Surname;
        return View();
    }


    [HttpGet]
    [Route("EditProfile")]
    public async Task<IActionResult> EditProfile()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        UserEditViewModel model = new();
        model.Name= values.Name;
        model.Email= values.Email;
        model.Surname  = values.Surname;
        model.PhoneNumber  = values.PhoneNumber;
        model.ImageUrl  = values.ImageUrl;
        model.City  = values.City;
        model.Username  = values.UserName;



        return View(model);
    }

    [HttpPost]
    [Route("EditProfile")]
    public async Task<IActionResult> EditProfile(UserEditViewModel model)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);

        if(model.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(model.Image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource+"/wwwroot/images/"+imageName;
            var stream= new FileStream(saveLocation, FileMode.Create);
            await model.Image.CopyToAsync(stream);
            user.ImageUrl = imageName;
        }


        user.Name = model.Name;
        user.Email = model.Email;
        user.Surname = model.Surname;
        user.PhoneNumber = model.PhoneNumber;
        user.City = model.City;
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return RedirectToAction("MyBloglist","Blog", new {Area="Writer"});
        }

       return View();
    }
}
