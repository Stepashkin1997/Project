using System.ComponentModel.DataAnnotations;
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
        public void Copy(Task task)//контструкор копирования
        {
            Name = task.Name;
            Status = task.Status;
            Executor = task.Executor;
            Comment = task.Comment;
            AuthorId = task.AuthorId;
            ExecutorId = task.ExecutorId;
            Project = task.Project;
            Priority = task.Priority;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }//название задачи,
        [Required]
        [Column("Status")]
        public string Status
        {
            get { return StatusEnum.ToString(); }
            set { StatusEnum = value.ParseEnum<Status>(); }
        }

        [NotMapped]
        public Status StatusEnum { get; set; }
        [Required]
        public string Comment { get; set; }//комментарий
        [Required]
        public int Priority { get; set; }//приоритет задачи
        [Required]
        public int AuthorId { get; set; }//автор задачи
        public virtual Employees Author { get; set; }
        [Required]
        public int? ExecutorId { get; set; }//исполнитель задачи
        public virtual Employees Executor { get; set; }
        [Required]
        public int Project { get; set; }//проект задачи
    }
}