using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog5.ViewComponents.CategoryList
{
    public class CategoryList : ViewComponent
    {
        CategoryService cs = new CategoryService(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = cs.TGetList();
            return View(values);
        }
    }
}
