using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.WriterPanel.ViewComponents.Notification
{
    public class NotificationList : ViewComponent
    {
        NotificationService ns = new NotificationService(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = ns.TGetList();
            return View(values);
        }
    }
}
