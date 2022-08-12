using BusinessLayer.Concrete;
using BusinessLayer.ValidatorRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebBlog5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class NotificationController : Controller
    {
        NotificationService ns = new NotificationService(new EfNotificationRepository());
        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index()
        {
            var values = ns.TGetList();
            return View(values);
        }

        [HttpGet]
        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult AddNotification()
        {
            return View();
        }

        [HttpPost]
        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult AddNotification(Notification p)
        {
            NotificationValidator nv = new NotificationValidator();
            ValidationResult results = nv.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.TypeSimvol = "mdi mdi-calendar";
                p.Color = "preview-icon bg-success";
                ns.TInsert(p);
                return RedirectToAction("Index", "Notification", new { area = "AdminPanel" });
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
        [HttpGet]
        public IActionResult NotificationUpdate(int id)
        {
            NotificationService ns = new NotificationService(new EfNotificationRepository());
            var values = ns.TGetById(id);
            Notification ct = new Notification()
            {
                ID = values.ID,
                Type = values.Type,
                TypeSimvol = values.TypeSimvol,
                Details = values.Details,
                Color =values.Color
            };
            return View(ct);
        }

        [Route("AdminPanel/[controller]/[action]")]
        [HttpPost]
        public IActionResult NotificationUpdate(Notification p)
        {
            NotificationValidator nt = new NotificationValidator();
            ValidationResult results = nt.Validate(p);
            if (results.IsValid)
            {
                NotificationService ns = new NotificationService(new EfNotificationRepository());
                var values = ns.TGetById(p.ID);
                values.Type = p.Type;
                values.Details = p.Details;
                values.Status = true;
                ns.TUpdate(values);
                return RedirectToAction("Index", "Notification");
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

        public IActionResult DeleteNotification(int id)
        {
            var values = ns.TGetById(id);
            ns.TDelete(values);
            return RedirectToAction("Index", "Notification");
        }
    }
}
