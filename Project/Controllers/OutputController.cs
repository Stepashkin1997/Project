using Project.Models;
using System.Linq;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class OutputController : Controller//контроллер выдачи данных
    {
        private DataContext context;
        // GET: Output
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees()//метод возвращающий предсталение с сотрудниками
        {
            using (context = new DataContext())
            {
                ViewBag.Employees = context.Employee.ToList();
            }
            return View("Employees");
        }

        public ActionResult Projects()//метод возвращающий предсталение с проектами
        {
            using (context = new DataContext())
            {
                ViewBag.Projects = context.Project.ToList();
            }
            return View("Projects");
        }
    }
}