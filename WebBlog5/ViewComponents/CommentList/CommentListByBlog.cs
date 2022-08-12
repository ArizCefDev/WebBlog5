using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.ViewComponents.CommentList
{
    public class CommentListByBlog : ViewComponent
    {
        CommentService cs = new CommentService(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            var values = cs.TGetList();
            return View(values);
        }
    }
}
