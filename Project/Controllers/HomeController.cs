using Project.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;
        public string Index()
        {
            dynamic sql;
            using (context = new DataContext())
            {
                // создаем два объекта User
                //Employees user1 = new Employees { Name = "Tom", Surname="" , Middle_name="", email=""};
                //Employees user2 = new Employees { Name = "Sam", Surname = "", Middle_name = "", email = "" };

                //// добавляем их в бд
                //context.Employee.Add(user1);
                //context.Employee.Add(user2);
                //context.SaveChanges();
                //Console.WriteLine("Объекты успешно сохранены");
                
                sql = context.Database.Log.ToString();
            }
            return sql;
        }
    }
}