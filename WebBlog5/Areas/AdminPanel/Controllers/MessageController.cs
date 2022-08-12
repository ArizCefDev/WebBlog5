using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    
    public class MessageController : Controller
    {
        ContactService cs = new ContactService(new EfContactRepository());
        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index()
        {
            var values = cs.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageUpdate(int id)
        {
            ContactService cs = new ContactService(new EfContactRepository());
            var values = cs.TGetById(id);
            Contact ct = new Contact()
            {
                ID = values.ID,
                UserName = values.UserName,
                Mail = values.Mail,
                Subject = values.Subject,
                Message = values.Message,
            };
            return View(ct);
        }

        [Route("AdminPanel/[controller]/[action]")]
        [HttpPost]
        public IActionResult MessageUpdate(Contact p)
        {
            ContactService cs = new ContactService(new EfContactRepository());
            var values = cs.TGetById(p.ID);
            values.UserName = p.UserName;
            values.Mail = p.Mail;
            values.Subject = p.Subject;
            values.Message = p.Message;
            values.Status = true;
            cs.TUpdate(values);
            return RedirectToAction("Index", "Message");
        }

        public IActionResult MessageDelete(int id)
        {
            var values = cs.TGetById(id);
            cs.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
