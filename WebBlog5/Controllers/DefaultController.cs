using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        BlogService bs = new BlogService(new EfBlogRepository());

        public IActionResult Index()
        {
            var values = bs.GetBlogListCategory();
            return View(values);
        }
    }
}
