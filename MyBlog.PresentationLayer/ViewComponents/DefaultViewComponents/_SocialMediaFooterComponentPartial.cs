using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _SocialMediaFooterComponentPartial:ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public _SocialMediaFooterComponentPartial(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
           var socialMediaTrue= _socialMediaService.TGetListAll().Where(x => x.Status == true).ToList();
            return View(socialMediaTrue);
        }
    }
}
