using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Writer.ViewComponents.AdminViewComponents
{
    public class _AdminNavbarNotificationsPartial : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public _AdminNavbarNotificationsPartial(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationService.TGetListAll()
                .Where(x => x.Status == true)
                .OrderByDescending(y => y.NotificationId)
                .Take(3)
                .ToList();
            return View(values);
        }
    
    }
}
