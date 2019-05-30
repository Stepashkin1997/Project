using Project.Models;
using System.Web.Mvc;
namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;
        public ActionResult Index()
        {
            return View();
        }
    }
}