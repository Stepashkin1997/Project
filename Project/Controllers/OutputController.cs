using Project.Models;
using System.Linq;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class OutputController : Controller
    {
        private DataContext context;
        // GET: Output
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees()
        {
            using (context = new DataContext())
            {
                ViewBag.Employees = context.Employee.ToList();
            }
            return View();
        }

        public ActionResult Projects()
        {
            using (context = new DataContext())
            {
                ViewBag.Projects = context.Project.ToList();
            }
            return View();
        }
    }
}