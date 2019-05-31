using Project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class UpdateController : Controller//контроллер для изменения БД
    {
        private DataContext context;
        // GET: Update
        public ActionResult Index()
        {
            ViewBag.List = new List<string>() { "Employees", "Projects", "Projects_Employees" };//список имен таблиц
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
                        var otdel = context.Project.ToList();
                        return Json(otdel);
                    case "Projects_Employees":
                        var product = context.Project_Employee.ToList();
                        return Json(product);
                    case "Employees":
                        var employee = context.Employee.ToList();
                        return Json(employee);
                    default:
                        return null;
                }
            }
        }
    }
}