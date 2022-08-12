using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Controllers
{
    public class WriterController : Controller
    {
        WriterService ws = new WriterService(new EfWriterRepository());
        public IActionResult Index()
        {
            var values = ws.TGetList();
            return View(values);
        }
    }
}
