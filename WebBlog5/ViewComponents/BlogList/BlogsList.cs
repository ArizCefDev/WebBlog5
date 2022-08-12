using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlog5.ViewComponents.BlogList
{
    public class BlogsList : ViewComponent
    {
        BlogService bs = new BlogService(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            //var blogcom = User.Identity.Name;
            //var BlogID = c.Blogs.Where(x => x.Content == blogcom)
            //    .Select(y => y.ID).FirstOrDefault();
            ViewBag.WriterComment = c.Comments.Where(x => x.BlogID == 23).Count();
            var values = bs.GetBlogListCategory();
            return View(values);
        }
    }
}
