using BusinessLayer.Concrete;
using BusinessLayer.ValidatorRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.Controllers
{
    [AllowAnonymous]

    public class RegisterController : Controller
    {
        WriterService ws = new WriterService(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator wt = new WriterValidator();
            ValidationResult results = wt.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                p.Image = "/webWriter/assets/images/writerimg.png";
                p.About = "Özün haqqında ətraflı yaz";
                ws.TInsert(p);
                return RedirectToAction("ShowMessage", "Register");
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

        public IActionResult ShowMessage()
        {
            return View();
        }
    }
}
