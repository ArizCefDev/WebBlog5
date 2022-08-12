using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult ContactList()
        {
            using var c = new Context();
            var values = c.Contacts.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult ContactGet(int id)
        {
            using var c = new Context();
            var values = c.Contacts.Find(id);
            if(values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult ContactAdd(Contact p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult ContactUpdate(Contact p)
        {
            using var c = new Context();
            var values = c.Find<Contact>(p.ID);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                values.UserName = p.UserName;
                values.Mail = p.Mail;
                values.Subject = p.Subject;
                values.Message = p.Message;
                c.Update(values);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ContactDelete(int id)
        {
            using var c = new Context();
            var values = c.Contacts.Find(id);
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
