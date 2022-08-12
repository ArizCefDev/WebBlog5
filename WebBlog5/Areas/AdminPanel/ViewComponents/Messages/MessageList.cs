using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.AdminPanel.ViewComponents.Messages
{
    public class MessageList : ViewComponent
    {
        ContactService cs = new ContactService(new EfContactRepository());
        public IViewComponentResult Invoke()
        {
            var values = cs.TGetList();
            return View(values);
        }
    }
}
