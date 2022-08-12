using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CommentController : Controller
    {
        CommentService cs = new CommentService(new EfCommentRepository());
        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index()
        {
            var values = cs.TGetList();
            return View(values);
        }


        public IActionResult DeleteComment(int id)
        {
            var values = cs.TGetById(id);
            cs.TDelete(values);
            return RedirectToAction("Index", "Comment");
        }
    }
}
