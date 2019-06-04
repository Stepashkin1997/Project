using Project.Models.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
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
        [MyStatus(new string[] { "ToDo", "InProgress", "Done" })]
        [Column("Status")]
        public string Status { get; set; }//статус

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