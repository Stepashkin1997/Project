using Project.Models;
using Project.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Project.Controllers
{
    public sealed class UpdateController : Controller//контроллер для изменения БД
    {
        private DataContext context;
        // GET: Update
        public ActionResult Index(string id)
        {
            ViewBag.List = new List<string>() { "Employees", "Projects", "Projects_Employees", "Task" };//список имен таблиц

            using (context = new DataContext())
            {
                switch (id)//выбор таблицы по запросу
                {
                    case "Projects":
                        ViewBag.Table = context.Project.ToList().Join(context.Employee, a => a.Manager, b => b.Id, (p, c) => new ProjectView// соединение таблиц Project и Employee и выборка для представления
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
                        }).ToList();
                        return View("Projects");

                    case "Projects_Employees":
                        ViewBag.Table = context.Project_Employee.ToList().Join(context.Employee, a => a.Employee, b => b.Id, (p, c) =>
                            c.Name + " " + c.Surname + " " + c.Middle_name
                        );// соединение таблиц Project_Employee и Employee и выборка полного имени
                        return View("Projects_Employees");

                    case "Employees":
                        ViewBag.Table = context.Employee.ToList();
                        return View("Employees");

                    case "Task":
                        context.Tasks.Load();
                        var result= context.Tasks.Local;
                        ViewBag.Table = result;
                        return View("Task");

                    default:
                        return View();
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