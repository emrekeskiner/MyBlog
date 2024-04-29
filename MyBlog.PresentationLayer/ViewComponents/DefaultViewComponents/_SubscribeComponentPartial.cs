using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Newtonsoft.Json;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _SubscribeComponentPartial:ViewComponent
    {
        private readonly ISubscribeService _subscribeService;

        public _SubscribeComponentPartial(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
