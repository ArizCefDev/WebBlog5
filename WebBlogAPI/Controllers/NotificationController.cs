using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpGet]
        public IActionResult NotificationList()
        {
            using var c = new Context();
            var values = c.Notifications.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult NotificationGet(int id)
        {
            using var c = new Context();
            var values = c.Notifications.Find(id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult NotificationAdd(Notification p)
        {
            using var c = new Context();
            c.Notifications.Add(p);
            c.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult NotificationUpdate(Notification p)
        {
            using var c = new Context();
            var values = c.Find<Notification>(p.ID);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                c.Notifications.Update(values);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult NotificationDelete(int id)
        {
            using var c = new Context();
            var values = c.Notifications.Find(id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
