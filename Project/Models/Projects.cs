using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project.Models
{
    public class Projects//cущность проект
    {
        public int Id { get; set; }//столбец индификации

        [Required]
        public string Name { get; set; }//название проекта

        [Required]
        public string Customer { get; set; }//название компании-заказчика

        [Required]
        public string Executor { get; set; }//название компании-исполнителя

        [Required]
        public int Manager { get; set; }//руководитель проекта

        [Required]
        public DateTime Date_start { get; set; }//дата начала проекта

        [Required]
        public DateTime Date_end { get; set; }//дата окончания проекта

        [Range(1, 10)]
        [Required]
        public int Priority { get; set; }//приоритет проекта

        public void Copy(Projects projects)//контструкор копирования
        {
            Name = projects.Name;
            Customer = projects.Customer;
            Executor = projects.Executor;
            Manager = projects.Manager;
            Date_start = projects.Date_start;
            Date_end = projects.Date_end;
            Priority = projects.Priority;
        }
    }
}