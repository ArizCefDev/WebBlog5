using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class WriterController : Controller
    {
        WriterService ws = new WriterService(new EfWriterRepository());
        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index()
        {
            var values = ws.TGetList();
            return View(values);
        }
        
        public IActionResult DeleteWriter(int id)
        {
            var values = ws.TGetById(id);
            ws.TDelete(values);
            return RedirectToAction("Index", "Writer");
        }
    }
}
