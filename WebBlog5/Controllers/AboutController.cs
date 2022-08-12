using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Controllers
{
    
    public class AboutController : Controller
    {
        AboutService abs = new AboutService(new EfAboutRepository());
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = abs.TGetList();
            return View(values);
        }
    }
}
