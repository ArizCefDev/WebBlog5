using BusinessLayer.Concrete;
using BusinessLayer.ValidatorRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebBlog5.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactService cs = new ContactService(new EfContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            ContactValidator ct = new ContactValidator();
            ValidationResult results = ct.Validate(p);
            if (results.IsValid)
            {
                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.Status = true;
                cs.TInsert(p);
                return RedirectToAction("ShowMessage", "Contact");
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
