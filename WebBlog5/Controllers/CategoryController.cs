using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebBlog5.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService cs = new CategoryService(new EfCategoryRepository());

        public IActionResult Index()
        {
            var values = cs.TGetList();
            return View(values);
        }

        //AdminPanel
        public async Task<IActionResult> CategoryList()
        {
            //var values = cs.TGetList();
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44350/api/Category");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        public class Class1
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        //[HttpGet]
        //public async Task<IActionResult> CategoryUpdatez(int id)
        //{
        //    var httpClient = new HttpClient();
        //    var responseMessage = await httpClient.GetAsync("https://localhost:44350/api/Category" + id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonCategory=await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<Category>(jsonCategory);
        //        return View(values);
        //    }
        //    return RedirectToAction("Index", "Category", new { area = "AdminPanel" });
        //}

        //[HttpPost]
        //public async Task<IActionResult> CategoryUpdatez(Category p)
        //{
        //    var httpClient = new HttpClient();
        //    var jsonCategory = JsonConvert.SerializeObject(p);
        //    var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
        //    var responseMessage = await httpClient.PutAsync("https://localhost:44350/api/Category", content);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Category", new { area = "AdminPanel" });
        //    }
        //    return View(p);
        //}
    }
}
