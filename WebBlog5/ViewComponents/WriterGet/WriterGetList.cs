using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.ViewComponents.WriterGet
{
    public class WriterGetList : ViewComponent
    {
        BlogService bs = new BlogService(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bs.GetBlogListWriter();
            return View(values);
        }
    }
}
