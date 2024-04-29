using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentsPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListByBlogComponentsPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            id = 2;
            var values = _commentService.TGetCommentsByBlog(id).Where(x=>x.Status==true).ToList();
            return View(values);
        }
    }
}
