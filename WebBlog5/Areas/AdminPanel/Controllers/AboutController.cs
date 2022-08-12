using BusinessLayer.Concrete;
using BusinessLayer.ValidatorRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AboutController : Controller
    {
        AboutService abs = new AboutService(new EfAboutRepository());

        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index()
        {
            var values = abs.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AboutUpdate(int id)
        {
            AboutService abs = new AboutService(new EfAboutRepository());
            var values = abs.TGetById(id);
            About ab = new About()
            {
                ID = values.ID,
                image1 = values.image1,
                Details1 = values.Details1,
                Details2 = values.Details2,
            };
            return View(ab);
        }

        [Route("AdminPanel/[controller]/[action]")]
        [HttpPost]
        public IActionResult AboutUpdate(About p)
        {
            AboutValidator nt = new AboutValidator();
            ValidationResult results = nt.Validate(p);
            if (results.IsValid)
            {
                AboutService abs = new AboutService(new EfAboutRepository());
                var values = abs.TGetById(p.ID);
                values.image1 = p.image1;
                values.Details1 = p.Details1;
                values.Details2 = p.Details2;
                values.Status = true;
                abs.TUpdate(values);
                return RedirectToAction("Index", "About");
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
