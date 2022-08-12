using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlog5.Areas.WriterPanel.ViewComponents.DasHboardBlog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogService bs = new BlogService(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.Mail == usermail)
                .Select(y => y.ID).FirstOrDefault();

            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerID).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
