using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBlog5.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogService bs = new BlogService(new EfBlogRepository());
        
        public IActionResult Index()
        {
            var values = bs.GetBlogListCategory();
            return View(values);
        }

        public IActionResult BlogDetails(int id)
        {
            Context c = new Context();
            ViewBag.WriterComment = c.Comments.Where(x => x.BlogID == 23).Count();
            ViewBag.i = id;
            var values = bs.GetBlogById(id);
            return View(values);
        }

    }
}
