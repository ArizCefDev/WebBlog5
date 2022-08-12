using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlog5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Route("AdminPanel/[controller]/[action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.ct = c.Categories.Count();
            ViewBag.bg = c.Blogs.Count();
            ViewBag.nt = c.Notifications.Count();
            ViewBag.cmt = c.Comments.Count();
            ViewBag.cnt = c.Contacts.Count();
            ViewBag.wr = c.Writers.Count();
            return View();
        }
    }
}
