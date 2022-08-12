using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult AdminList()
        //{
        //    using var c = new Context();
        //    var values = c.Admins.ToList();
        //    return Ok(values);
        //}

        //[HttpGet("{id}")]
        //public IActionResult AdminGet(int id)
        //{
        //    using var c = new Context();
        //    var values = c.Admins.Find(id);
        //    return Ok(values);
        //}

        //[HttpPost]
        //public IActionResult AdminAdd(Admin p)
        //{
        //    using var c = new Context();
        //    c.Add(p);
        //    c.SaveChanges();
        //    return Ok();
        //}

        //[HttpPut]
        //public IActionResult AdminUpdate(Admin p)
        //{
        //    using var c = new Context();
        //    var values = c.Find<Admin>(p.ID);
        //    if (values == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        values.Name = p.Name;
        //        values.About = p.About;
        //        c.Update(values);
        //        c.SaveChanges();
        //        return Ok();
        //    }
        //}
        //[HttpDelete("{id}")]
        //public IActionResult AdminDelete(int id)
        //{
        //    using var c = new Context();
        //    var values = c.Admins.Find(id);
        //    if (values==null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        c.Remove(values);
        //        c.SaveChanges();
        //        return Ok();
        //    }
        //}
    }
}
