using Project.Models;
using System;
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

            ViewBag.List = new List<string>() { "Employees", "Projects", "EmpinPrj", "Task" };//список имен таблиц
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
                        var otdel = context.Project.ToList().Select(a => new { a.Id, a.Name, a.Customer, a.Executor, a.ManagerId, Date_start = a.Date_start.ToShortDateString(), Date_end = a.Date_end.ToShortDateString(), a.Priority }).OrderBy(a => a.Id);
                        return Json(otdel);
                    case "EmpinPrj":
                        var product = context.EmpinPrjs.ToList().Select(a => new { a.Id, a.EmployeeId, a.ProjectId }).OrderBy(a => a.Id);
                        return Json(product);
                    case "Employees":
                        var employee = context.Employee.ToList().Select(a => new { a.Id, a.Name, a.Surname, a.Middle_name, a.email }).OrderBy(a => a.Id);
                        return Json(employee);
                    case "Task":
                        var task = context.Tasks.ToList().Select(a => new { a.Id, a.Name, a.Status, a.Comment, a.Priority, a.AuthorId, a.ExecutorId, a.Project }).OrderBy(a => a.Id);
                        return Json(task);
                    default:
                        return Json("none");
                }
            }
        }



        //методы изменения
        [HttpPost]
        public ActionResult EditEmployees(Employees employees)//изменение Employees
        {
            if (ModelState.IsValid)//validation check
            {
                using (context = new DataContext())
                {
                    var edit = context.Employee.Where(a => a.Id == employees.Id).FirstOrDefault();
                    edit.Copy(employees);//копирование
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult EditProjects(Projects projects)//изменение Projects
        {
            if (ModelState.IsValid)//validation check
            {
                using (context = new DataContext())
                {
                    var edit = context.Project.Where(a => a.Id == projects.Id).FirstOrDefault();
                    edit.Copy(projects);//копирование
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult EditEmpinPrj(EmpinPrj p_e)//изменение Projects_Employees
        {
            if (ModelState.IsValid)//validation check
            {
                using (context = new DataContext())
                {
                    var edit = context.EmpinPrjs.Where(a => a.Id == p_e.Id).FirstOrDefault();
                    edit.Copy(p_e);//копирование
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult EditTask(Task task)//изменение Task
        {
            if (ModelState.IsValid)//validation check
            {
                using (context = new DataContext())
                {
                    var edit = context.Tasks.Where(a => a.Id == task.Id).FirstOrDefault();
                    edit.Copy(task);//копирование
                    
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("Error");
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
            if (ModelState.IsValid)//validation check
            {
                using (context = new DataContext())
                {
                    context.Employee.Add(employees);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        [HttpPost]
        public ActionResult AddProjects(Projects projects)//добавление проекта
        {
            if (ModelState.IsValid)//validation check
            {
                using (context = new DataContext())
                {
                    context.Project.Add(projects);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        [HttpPost]
        public ActionResult AddEmpinPrj(EmpinPrj p_e)//добавление сотрудников на проект
        {
            if (ModelState.IsValid)//validation check
            {
                using (context = new DataContext())
                {
                    try
                    {
                        context.EmpinPrjs.Add(p_e);
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return View("Error");
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        [HttpPost]
        public ActionResult AddTask(Task task)//добавление задачи
        {
            if (ModelState.IsValid)//validation check
            {
                using (context = new DataContext())
                {
                    try
                    {
                        context.Tasks.Add(task);
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return View("Error");
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}