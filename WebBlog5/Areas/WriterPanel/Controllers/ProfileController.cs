using BusinessLayer.Concrete;
using BusinessLayer.ValidatorRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlog5.Areas.WriterPanel.Controllers
{
    [Area("WriterPanel")]
    [Route("WriterPanel/[controller]/[action]")]
    public class ProfileController : Controller
    {
        WriterService ws = new WriterService(new EfWriterRepository());

        [HttpGet]
        public IActionResult WriterUpdateProfile()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.Mail == usermail)
                .Select(y => y.ID).FirstOrDefault();
            var values = ws.TGetById(writerID);
            return View(values);
        }

        [HttpPost]
        public IActionResult WriterUpdateProfile(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);

            if (results.IsValid)
            {
                p.Image = "/webWriter/assets/images/writerimg.png";
                ws.TUpdate(p);
                return RedirectToAction("Index","Writer");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
