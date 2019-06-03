using Project.Models;

namespace Project.ViewModels
{
    public class TaskView
    {
        public int Id { get; set; }
        public string Name { get; set; }//название задачи,

        public string Status
        {
            get { return StatusEnum.ToString(); }
            set { StatusEnum = value.ParseEnum<Status>(); }
        }

        public Status StatusEnum { get; set; }

        public string Comment { get; set; }//комментарий
        public int Priority { get; set; }//приоритет задачи

        public int AuthorId { get; set; }//автор задачи

        public int? ExecutorId { get; set; }//исполнитель задачи

        public int Project { get; set; }//проект задачи
    }
}