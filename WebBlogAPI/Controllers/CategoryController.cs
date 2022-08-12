using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            var values = c.Categories.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            using var c = new Context();
            var values = c.Categories.Find(id);
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
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            var values = c.Add(p);
            c.SaveChanges();
            return Ok(values);
        }

        [HttpPut("{id}")]
        public IActionResult CategoryUpdate(Category p)
        {
            using var c = new Context();
            var values = c.Find<Category>(p.ID);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                values.Name = p.Name;
                values.Description = p.Description;
                c.Update(p);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
