using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlog5.Areas.WriterPanel.ViewComponents.WriterBlog
{
    public class WriterBlogList : ViewComponent
    {
        BlogService bs = new BlogService(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.Mail == usermail)
                .Select(y => y.ID).FirstOrDefault();
            var values = bs.GetListWithCategoryByWriterBM(writerID);
            return View(values);
        }
    }
}
