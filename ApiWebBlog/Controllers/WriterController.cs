using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiWebBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        [HttpGet]
        public IActionResult WriterList()
        {
            using var c = new Context();
            var values = c.Writers.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult WriterGet(int id)
        {
            using var c = new Context();
            var values = c.Writers.Find(id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult WriterAdd(Writer p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult WriterUpdate(Writer p)
        {
            using var c = new Context();
            var writer = c.Find<Writer>(p.ID);
            if (writer==null)
            {
                return NotFound();
            }
            else
            {
                writer.Name = p.Name;
                writer.About = p.About;
                writer.Image = p.Image;
                writer.Mail = p.Mail;
                writer.Password = p.Password;
                c.Update(p);
                c.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult WriterDelete(int id)
        {
            using var c = new Context();
            var writer = c.Writers.Find(id);
            if (writer==null)
            {
                return NotFound();
            }
            else
            {
                c.Writers.Remove(writer);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
