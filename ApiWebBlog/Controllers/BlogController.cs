using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiWebBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult BlogList()
        {
            using var c = new Context();
            var Blog = c.Blogs.ToList();
            return Ok(Blog);
        }

        [HttpGet("{id}")]
        public IActionResult BlogGet(int id)
        {
            using var c = new Context();
            var Blog = c.Blogs.Find(id);
            if (Blog == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Blog);
            }
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult BlogUpdate(Blog p)
        {
            using var c = new Context();
            var blog = c.Find<Blog>(p.ID);
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                blog.Title = p.Title;
                blog.Content = p.Content;
                blog.Image = p.Image;
                blog.CategoryID = p.CategoryID;
                blog.WriterID = p.WriterID;
                c.Update(p);
                c.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult BlogDelete(int id)
        {
            using var c = new Context();
            var blog=c.Blogs.Find(id);
            if (blog==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(blog);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
