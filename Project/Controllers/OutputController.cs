using Project.Models;
using Project.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using Filter = Project.Models.Filter;

namespace Project.Controllers
{
    public sealed class OutputController : Controller//контроллер выдачи данных
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
                ViewBag.Names = result.Select(a => a.Name).Distinct().ToList();
                ViewBag.Customers = result.Select(a => a.Customer).Distinct().ToList();
                ViewBag.Executors = result.Select(a => a.Executor).Distinct().ToList();
                ViewBag.Managers = result.Select(a => a.Manager).Distinct().ToList();
                ViewBag.Priorities = result.Select(a => a.Priority).Distinct().ToList();
            }
            return View("Projects");
        }

        public ActionResult EmployeesinProjects(int id)//метод возвращающий предсталение с проектами
        {
            using (context = new DataContext())
            {
                string project;
                try
                {
                    project = context.Project.Where(a => a.Id == id).Select(b => b.Name).First();
                }
                catch (InvalidOperationException e)
                {
                    return View("Error");
                }
                var result = context.Project_Employee.ToList().Where(r => r.Project == id).Join(context.Employee, a => a.Employee, b => b.Id, (p, c) => 
                
                    c.Name + " " + c.Surname + " " + c.Middle_name
                );
                ViewBag.Result = result.ToList();
                ViewBag.Project = project;
            }
            return View("EmployeesinProjects");
        }

        [HttpPost]
        public ActionResult Filters(Filter filter)//Метод для фильтрации информации о проектах
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

                ViewBag.Names = result.Select(a => a.Name).Distinct().ToList();
                ViewBag.Customers = result.Select(a => a.Customer).Distinct().ToList();
                ViewBag.Executors = result.Select(a => a.Executor).Distinct().ToList();
                ViewBag.Managers = result.Select(a => a.Manager).Distinct().ToList();
                ViewBag.Priorities = result.Select(a => a.Priority).Distinct().ToList();
                result = result.Where(a => Convert.ToDateTime(a.Date_start) > filter.start && Convert.ToDateTime(a.Date_start) < filter.end);
                if (filter.name != "All")
                    result = result.Where(a => a.Name.Contains(filter.name));
                if (filter.customer != "All")
                    result = result.Where(a => a.Customer.Contains(filter.customer));
                if (filter.executor != "All")
                    result = result.Where(a => a.Executor.Contains(filter.executor));
                if (filter.manager != "All")
                    result = result.Where(a => a.Manager.Contains(filter.manager));
                if (filter.priority != -1)
                    result = result.Where(a => a.Priority == filter.priority);

                ViewBag.Projects = result.ToList();
            }
            return View("Projects");
        }
    }
}