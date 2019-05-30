using System;

namespace Project.Models
{
    public class Projects
    {
        public int Id { get; set; }//столбец индификации
        public string Name { get; set; }//название проекта
        public string Customer { get; set; }//название компании-заказчика
        public string Executor { get; set; }//название компании-исполнителя
        public string Manager { get; set; }//руководитель проекта
        public DateTime Date_start { get; set; }//дата начала проекта
        public DateTime Date_end { get; set; }//дата окончания проекта
        public string Info_Executor { get; set; }//данные об исполнителях проекта
        public int Priority { get; set; }//приоритет проекта
    }
}