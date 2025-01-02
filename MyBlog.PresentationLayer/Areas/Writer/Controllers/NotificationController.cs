using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll()
                .Where(x => x.Status == true)
                .OrderByDescending(y => y.NotificationId)
                .ToList();

            return View(values);
        }

        public IActionResult NotificationDetail(int id)
        {
            var values = _notificationService.TGetById(id);
            
            return View(values);
        }
    }
}
