using Project.Models;
using Project.Models.Filters;
using Project.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

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

        public ActionResult Tasks()//метод возвращающий предсталение с задачами
        {
            context = new DataContext();
            var result = context.Tasks;
            ViewBag.Task = result;

            //передача данных в представление
            ViewBag.Names = result.Select(a => a.Name).Distinct().ToList();
            ViewBag.Authors = result.Select(a => a.Author.Name).Distinct().ToList();
            ViewBag.Executors = result.Select(a => a.Executor.Name).Distinct().ToList();
            ViewBag.Status = result.Select(a => a.Status).Distinct().ToList();
            ViewBag.Priorities = result.Select(a => a.Priority).Distinct().ToList();
            ViewBag.Project = result.Select(a => a.Project).Distinct().ToList();
            return View("Tasks");
        }

        [HttpPost]
        public ActionResult FiltersTask(TaskFilter filter)//Метод для фильтрации информации о задачах
        {
            using (context = new DataContext())
            {
                var result = context.Tasks.ToList();

                //передача данных в представление
                ViewBag.Names = result.Select(a => a.Name).Distinct().ToList();
                ViewBag.Authors = result.Select(a => a.Author.Name).Distinct().ToList();
                ViewBag.Executors = result.Select(a => a.Executor.Name).Distinct().ToList();
                ViewBag.Status = result.Select(a => a.Status).Distinct().ToList();
                ViewBag.Priorities = result.Select(a => a.Priority).Distinct().ToList();
                ViewBag.Project = result.Select(a => a.Project).Distinct().ToList();


                //Фильтрация результата через набор условий
                if (filter.name != "All")//задано ли условие с именем задачи
                    result = result.Where(a => a.Name.Contains(filter.name)).ToList(); 

                if (filter.author != "All")//задано ли условие с автором
                    result = result.Where(a => a.Author.Name.Contains(filter.author)).ToList();

                if (filter.executor != "All")//задано ли условие с исполнителем
                    result = result.Where(a => a.Executor.Name.Contains(filter.executor)).ToList();

                if (filter.status != "All")//задано ли условие с статусом
                    result = result.Where(a => a.Status.Contains(filter.status)).ToList();

                if (filter.priority != -1)//задано ли условие с приоритетом
                    result = result.Where(a => a.Priority == filter.priority).ToList();
                if (filter.project != -1)//задано ли условие с приоритетом
                    result = result.Where(a => a.Project == filter.project).ToList();

                //передача результата в представление
                ViewBag.Task = result;
            }
            return View("Tasks");
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
                var result = context.Project.ToList().Join(context.Employee, a => a.Manager, b => b.Id, (p, c) => new ProjectView// соединение таблиц Project и Employee и выборка для представления
                {
                    Id = p.Id,
                    Name = p.Name,
                    Customer = p.Customer,
                    Executor = p.Executor,
                    Manager = c.Name + " " + c.Surname + " " + c.Middle_name,//Конкатинация Имени Фамилии и Отчества
                    Date_start = p.Date_start.ToShortDateString(),
                    Date_end = p.Date_end.ToShortDateString(),
                    Info_Executor = p.Info_Executor,
                    Priority = p.Priority
                });

                //передача данных в представление
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
                    return View("Error");//если запрашиваемый проект не существует вернуть ошибку
                }
                var result = context.Project_Employee.ToList().Where(r => r.Project == id).Join(context.Employee, a => a.Employee, b => b.Id, (p, c) =>

                    c.Name + " " + c.Surname + " " + c.Middle_name
                );// соединение таблиц Project_Employee и Employee и выборка полного имени

                //передача данных в представление
                ViewBag.Result = result.ToList();
                ViewBag.Project = project;
            }
            return View("EmployeesinProjects");
        }

        [HttpPost]
        public ActionResult Filters(ProjectFilter filter)//Метод для фильтрации информации о проектах
        {
            using (context = new DataContext())
            {
                var result = context.Project.ToList().Join(context.Employee, a => a.Manager, b => b.Id, (p, c) => new ProjectView// соединение таблиц Project и Employee и выборка для представления
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

                //передача данных в представление
                ViewBag.Names = result.Select(a => a.Name).Distinct().ToList();
                ViewBag.Customers = result.Select(a => a.Customer).Distinct().ToList();
                ViewBag.Executors = result.Select(a => a.Executor).Distinct().ToList();
                ViewBag.Managers = result.Select(a => a.Manager).Distinct().ToList();
                ViewBag.Priorities = result.Select(a => a.Priority).Distinct().ToList();

                //Фильтрация результата через набор условий
                result = result.Where(a => Convert.ToDateTime(a.Date_start) > filter.start && Convert.ToDateTime(a.Date_start) < filter.end);//фильтр даты
                if (filter.name != "All")//задано ли условие с именем проекта
                    result = result.Where(a => a.Name.Contains(filter.name));

                if (filter.customer != "All")//задано ли условие с заказчиком
                    result = result.Where(a => a.Customer.Contains(filter.customer));

                if (filter.executor != "All")//задано ли условие с исполнителем
                    result = result.Where(a => a.Executor.Contains(filter.executor));

                if (filter.manager != "All")//задано ли условие с руководителем
                    result = result.Where(a => a.Manager.Contains(filter.manager));

                if (filter.priority != -1)//задано ли условие с приоритетом
                    result = result.Where(a => a.Priority == filter.priority);

                //передача результата в представление
                ViewBag.Projects = result.ToList();
            }
            return View("Projects");
        }
    }
}