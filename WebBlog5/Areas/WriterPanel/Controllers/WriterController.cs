
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    [Route("WriterPanel/[controller]/[action]")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyBlogDetails()
        {
            return View();
        }
    }
}
