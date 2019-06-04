using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Employees//cущность работник
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }//Имя
        [Required]
        public string Surname { get; set; }//Фамилия
        [Required]
        public string Middle_name { get; set; }//Отчество
        [Required]
        public string email { get; set; }//Почта
        public ICollection<Task> Task { get; set; }
        public Employees()//ленивая загрузка
        {
            Task = new HashSet<Task>();
        }
        public void Copy(Employees employees)//конструктор копирования
        {
            Name = employees.Name;
            Surname = employees.Surname;
            Middle_name = employees.Middle_name;
            email = employees.email;
        }
    }
}