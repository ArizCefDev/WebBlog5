
using BusinessLayer.Concrete;
using BusinessLayer.ValidatorRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebBlog5.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryService cs = new CategoryService(new EfCategoryRepository());
        [Route("AdminPanel/[controller]/[action]")]
        public IActionResult Index()
        {
            var values = cs.TGetList();
            //var httpClient = new HttpClient();
            //var responseMessage = await httpClient.GetAsync("https://localhost:44350/api/Category");
            //var jsonString=await responseMessage.Content.ReadAsStringAsync();
            //var values=JsonConvert.DeserializeObject<List<Category>>(jsonString);
            return View(values);
        }

        [Route("AdminPanel/[controller]/[action]")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [Route("AdminPanel/[controller]/[action]")]
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                p.Status = true;
                p.Description = "Kategoriya";
                cs.TInsert(p);
                return RedirectToAction("Index", "Category", new { area = "AdminPanel" });
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
        public IActionResult CategoryUpdate(int id)
        {
            CategoryService cs = new CategoryService(new EfCategoryRepository());
            var values = cs.TGetById(id);
            Category ct = new Category()
            {
                ID = values.ID,
                Name = values.Name,
                Description = values.Description
            };
            return View(ct);
        }

        [Route("AdminPanel/[controller]/[action]")]
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                CategoryService cs = new CategoryService(new EfCategoryRepository());
                var values = cs.TGetById(p.ID);
                values.Name = p.Name;
                values.Description = p.Description;
                values.Status = true;
                cs.TUpdate(values);
                return RedirectToAction("Index", "Category");
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

        public IActionResult DeleteCategory(int id)
        {
            var values = cs.TGetById(id);
            cs.TDelete(values);
            return RedirectToAction("Index", "Category");
        }





        //[HttpGet]
        //public async Task<IActionResult> CategoryUpdate(int id)
        //{
        //    var httpClient = new HttpClient();
        //    var responseMessage = await httpClient.GetAsync("https://localhost:44350/api/Category/" + id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonCategory = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<Category>(jsonCategory);
        //        return View(values);
        //    }
        //    return RedirectToAction("Index", "Category", new { area = "AdminPanel" });
        //}

        //[HttpPost]
        //public async Task<IActionResult> CategoryUpdate(Category p)
        //{
        //    var httpClient = new HttpClient();
        //    var jsonCategory = JsonConvert.SerializeObject(p);
        //    var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
        //    var responseMessage = await httpClient.PutAsync("https://localhost:44350/api/Category/", content);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Category", new { area = "AdminPanel" });
        //    }
        //    return View(p);
        //}
    }
}
