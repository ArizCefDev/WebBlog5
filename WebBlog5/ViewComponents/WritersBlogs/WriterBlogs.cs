using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.ViewComponents.WriterBlogs
{
    public class WriterBlogs : ViewComponent
    {
        BlogService bs = new BlogService(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bs.GetBlogListCategory();
            return View(values);
        }
    }
}
