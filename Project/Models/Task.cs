using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }//название задачи,
        public int Author { get; set; }//автор задачи
        public int Executor { get; set; }//исполнитель задачи
        public string Status { get; set; }//статус задачи
        public string Comment { get; set; }//комментарий
        public int Priority { get; set; }//приоритет задачи
    }
}