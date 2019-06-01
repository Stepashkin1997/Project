using Project.Models;
using Project.ViewModels;
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
                var result = context.Project.ToList().Join(context.Employee, a => a.Manager, b => b.Id, (p, c) => new ProjectView// результат
                {
                    Id = p.Id,
                    Name = p.Name,
                    Customer = p.Customer,
                    Executor = p.Executor,
                    Manager = c.Name + " " + c.Surname + " " + c.Middle_name,
                    Date_start = p.Date_start.ToShortDateString(),
                    Date_end = p.Date_end.ToShortDateString(),
                    Info_Executor = p.Info_Executor,
                    Priority = p.Priority
                });
                ViewBag.Projects = result.ToList();
            }
            return View("Projects");
        }
    }
}