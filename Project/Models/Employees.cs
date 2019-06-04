using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Employees//cущность работник
    {
        public int Id { get; set; }

        [RegularExpression(@"[A-Za-z]")]
        [Required]
        public string Name { get; set; }//Имя

        [RegularExpression(@"[A-Za-z]")]
        [Required]
        public string Surname { get; set; }//Фамилия

        [RegularExpression(@"[A-Za-z]")]
        [Required]
        public string Middle_name { get; set; }//Отчество

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
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