using Project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Project.Controllers
{
    public sealed class UpdateController : Controller//контроллер для изменения БД
    {
        private DataContext context;
        // GET: Update
        public ActionResult Index()
        {

            ViewBag.List = new List<string>() { "Employees", "Projects", "Projects_Employees", "Task" };//список имен таблиц
            return View();
        }

        [HttpPost]
        public JsonResult Select(string table)//post метод возвращающий таблицы в JSON
        {
            using (context = new DataContext())
            {
                switch (table)//выбор таблицы по запросу
                {
                    case "Projects":
                        var otdel = context.Project.ToList().Select(a => new { a.Id, a.Name, a.Customer, a.Executor, a.Manager, Date_start = a.Date_start.ToShortDateString(), Date_end = a.Date_end.ToShortDateString(), a.Info_Executor, a.Priority }).OrderBy(a => a.Id);
                        return Json(otdel);
                    case "Projects_Employees":
                        var product = context.Project_Employee.ToList();
                        return Json(product);
                    case "Employees":
                        var employee = context.Employee.ToList().Select(a => new { a.Id, a.Name, a.Surname, a.Middle_name, a.email }).OrderBy(a => a.Id);
                        return Json(employee);
                    case "Task":
                        var task = context.Tasks.ToList().Select(a => new { a.Id, a.Name, a.Status, a.Comment, a.Priority, a.AuthorId, a.ExecutorId }).OrderBy(a => a.Id);
                        return Json(task);
                    default:
                        return null;
                }
            }
        }



        //методы изменения
        [HttpPost]
        public ActionResult EditEmployees(Employees employees)//изменение Employees
        {
            using (context = new DataContext())
            {
                var edit = context.Employee.Where(a => a.Id == employees.Id).FirstOrDefault();
                edit.Copy(employees);//копирование
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditProjects(Projects projects)//изменение Projects
        {
            using (context = new DataContext())
            {
                var edit = context.Project.Where(a => a.Id == projects.Id).FirstOrDefault();
                edit.Copy(projects);//копирование
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditProjects_Employees(Projects_Employees p_e)//изменение Projects_Employees
        {
            using (context = new DataContext())
            {
                var edit = context.Project_Employee.Where(a => a.Id == p_e.Id).FirstOrDefault();
                edit.Copy(p_e);//копирование
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditTask(Task task)//изменение Task
        {
            using (context = new DataContext())
            {
                var edit = context.Tasks.Where(a => a.Id == task.Id).FirstOrDefault();
                edit.Copy(task);//копирование
                context.SaveChanges();
            }
            return RedirectToAction("Select");
        }


        //метод удаления
        [HttpPost]
        public void Delete(string command)
        {
            using (context = new DataContext())
            {
                if (command != null)
                {
                    context.Database.ExecuteSqlCommand(@command);//выполнение sql команды
                }
            }
        }


        //методы добавления
        [HttpPost]
        public ActionResult AddEmployees(Employees employees)//добавление сотрудника
        {
            using (context = new DataContext())
            {
                context.Employee.Add(employees);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddProjects(Projects projects)//добавление проекта
        {
            using (context = new DataContext())
            {
                context.Project.Add(projects);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddProjects_Employees(Projects_Employees p_e)//добавление сотрудников на проект
        {
            using (context = new DataContext())
            {
                context.Project_Employee.Add(p_e);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddTask(Task task)//добавление задачи
        {
            using (context = new DataContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}