using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    [Route("WriterPanel/[controller]/[action]")]
    public class NotificationController : Controller
    {
        NotificationService ns = new NotificationService(new EfNotificationRepository());
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var values = ns.TGetList();
            return View(values);
        }
    }
}
