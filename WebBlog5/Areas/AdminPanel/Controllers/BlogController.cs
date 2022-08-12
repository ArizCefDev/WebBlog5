using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BlogController : Controller
    {
        BlogService bs = new BlogService(new EfBlogRepository());
        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index()
        {
            var values = bs.GetBlogListCategory();
            return View(values);
        }

        public IActionResult BlogDelete(int id)
        {
            var values = bs.TGetById(id);
            bs.TDelete(values);
            return RedirectToAction("Index", "Blog");
        }

        //[HttpGet]
        //public IActionResult BlogUpdate(int id)
        //{
        //    CategoryService cs = new CategoryService(new EfCategoryRepository());
        //    var blogvalues = bs.TGetById(id);
        //    List<SelectListItem> categoryvalues = (from x in cs.TGetList()
        //                                           select new SelectListItem
        //                                           {
        //                                               Text = x.Name,
        //                                               Value = x.ID.ToString()
        //                                           }).ToList();
        //    ViewBag.cv = categoryvalues;
        //    return View(blogvalues);
        //}

        //[HttpPost]
        //public IActionResult BlogUpdate(Blog p)
        //{
        //    Context c = new Context();
        //    var usermail = User.Identity.Name;
        //    var writerID = c.Writers.Where(x => x.Mail == usermail)
        //        .Select(y => y.ID).FirstOrDefault();
        //    p.WriterID = writerID;
        //    p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    p.Status = true;
        //    bs.TUpdate(p);
        //    return RedirectToAction("MyBlogDetails", "Writer", new { area = "WriterPanel" });
        //}

    }
}
