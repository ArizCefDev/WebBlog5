using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebBlog5.Areas.WriterPanel.ViewComponents.WriterInfo
{
    public class WriterAboutDashboard : ViewComponent
    {
        WriterService bs = new WriterService(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.Mail == usermail)
                .Select(y=>y.ID).FirstOrDefault();
            var values = bs.GetWiriterByID(writerID);
            return View(values);
        }
    }
}
