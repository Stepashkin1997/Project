using System;

namespace Project.Models.Filters
{
    public class ProjectFilter//Модель для фильра проектов
    {
        public string name { get; set; }//название проекта
        public string customer { get; set; }//имя заказчика
        public string executor { get; set; }//название компании-исполнителя
        public string manager { get; set; }//имя руководителя
        public DateTime start { get; set; }//дата начала
        public DateTime end { get; set; }//дата конца
        public int priority { get; set; }//целочисленный приоритет
    }
}