using System.Web.Mvc;
namespace Project.Controllers
{
    public sealed class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}