using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{

    public enum Status //перечисление для статуса задачи
    {
        ToDo,
        InProgress,
        Done,
    }
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }//название задачи,

        [Column("Status")]
        public string Status
        {
            get { return StatusEnum.ToString(); }
            set { StatusEnum = value.ParseEnum<Status>(); }
        }

        [NotMapped]
        public Status StatusEnum { get; set; }

        public string Comment { get; set; }//комментарий
        public int Priority { get; set; }//приоритет задачи

        public int AuthorId { get; set; }//автор задачи
        public virtual Employees Author { get; set; }

        public int? ExecutorId { get; set; }//исполнитель задачи
        public virtual Employees Executor { get; set; }

        public int Project { get; set; }//проект задачи
    }
}