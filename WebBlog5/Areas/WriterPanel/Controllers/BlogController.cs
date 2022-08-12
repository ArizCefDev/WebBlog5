
using BusinessLayer.Concrete;
using BusinessLayer.ValidatorRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebBlog5.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    
    public class BlogController : Controller
    {
        BlogService bs = new BlogService(new EfBlogRepository());

        [Route("WriterPanel/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("WriterPanel/[controller]/[action]")]
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryService cs = new CategoryService(new EfCategoryRepository());

            List<SelectListItem> values = (from x in cs.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.cv = values;
            return View();
        }

        [Route("WriterPanel/[controller]/[action]")]
        [HttpPost]
        public IActionResult BlogAdd(BlogAdd p)
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.Mail == usermail)
                .Select(y => y.ID).FirstOrDefault();

            Blog b = new Blog();
            if(p.ImageURL != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newImage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory()
                    , "wwwroot/BlogImages/", newImage);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                b.Image = newImage;
            }
            p.WriterID = writerID;
            b.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.Status = true;
            b.Title = p.Title;
            b.Content = p.Content;
            b.CategoryID = p.CategoryID;
            b.WriterID = p.WriterID;
            bs.TInsert(b);
            return RedirectToAction("MyBlogDetails", "Writer");
        }

        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            CategoryService cs = new CategoryService(new EfCategoryRepository());
            var blogvalues = bs.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cs.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
            ViewBag.ctv = categoryvalues;
            return View(blogvalues);
        }

        [Route("WriterPanel/[controller]/[action]")]
        [HttpPost]
        public IActionResult BlogUpdate(Blog p)
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.Mail == usermail)
                .Select(y => y.ID).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                p.WriterID = writerID;
                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.Status = true;
                bs.TUpdate(p);
                return RedirectToAction("MyBlogDetails", "Writer");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            CategoryService cs = new CategoryService(new EfCategoryRepository());

            List<SelectListItem> values = (from x in cs.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.ctv = values;
            return View();
        }

        public IActionResult BlogDelete(int id)
        {
            var values = bs.TGetById(id);
            bs.TDelete(values);
            return RedirectToAction("MyBlogDetails", "Writer", new { area = "WriterPanel" });
        }
    }
}
