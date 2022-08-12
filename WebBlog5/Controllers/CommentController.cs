using BusinessLayer.Concrete;
using BusinessLayer.ValidatorRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebBlog5.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentService cs = new CommentService(new EfCommentRepository());
        BlogService bs = new BlogService(new EfBlogRepository());

        
        

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cs.GetListComment(id);
            return PartialView(values);
        }

        [HttpGet]
        public IActionResult CommentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CommentAdd(Comment p)
        {
            //Context c = new Context();
            //var blogcom = User.Identity.Name;
            //var BlogID = c.Blogs.Where(x => x.Title == blogcom)
            //    .Select(y => y.ID).FirstOrDefault();
            CommentValidator cv = new CommentValidator();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
                p.BlogID = 23;
                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.Status = true;
                cs.TInsert(p);
                return RedirectToAction("ShowCommentMessage", "Comment");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CommentDetails(int id)
        {
            ViewBag.i = id;
            var values = bs.GetBlogById(id);
            return View(values);
        }

        public IActionResult ShowCommentMessage()
        {
            return View();
        }
    }
}
