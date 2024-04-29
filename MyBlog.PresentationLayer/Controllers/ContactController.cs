using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Newtonsoft.Json;

namespace MyBlog.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IContactMessageService _contactMessageService;

        public ContactController(IAboutService aboutService, IContactMessageService contactMessageService)
        {
            _aboutService = aboutService;
            _contactMessageService = contactMessageService;
        }

        public IActionResult ContactPage()
        {
            var values = _aboutService.TGetListAll().FirstOrDefault();
            return View(values);
        }

        
        public IActionResult ContactMessageSend(ContactMessage contactMessage)
        {
            var values = JsonConvert.SerializeObject(contactMessage);

            if (contactMessage.NameSurname == null && contactMessage.Mail == null)
            {
                return NotFound(values);
            }
            _contactMessageService.TInsert(contactMessage);
            return Json(values);
        }
    }
}
