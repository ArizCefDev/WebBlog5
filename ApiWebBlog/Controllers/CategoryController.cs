using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiWebBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            var category = c.Categories.ToList();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            using var c = new Context();
            var category = c.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Category category)
        {
            using var c = new Context();
            var cty = c.Find<Category>(category.ID);
            if (cty == null)
            {
                return NotFound();
            }
            else
            {
                cty.Name = category.Name;
                cty.Description = category.Description;
                c.Update(cty);
                c.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var category = c.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(category);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
