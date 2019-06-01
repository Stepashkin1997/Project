namespace Project.Models
{
    public enum Status//перечисление для статуса задачи
    {
        ToDo,
        InProgress,
        Done,
    }

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }//название задачи,
        public Status Status { get; set; }//статус задачи
        public string Comment { get; set; }//комментарий
        public int Priority { get; set; }//приоритет задачи

        public int AuthorId { get; set; }//автор задачи
        public Employees Author { get; set; }

        public int ExecutorId { get; set; }//исполнитель задачи
        public Employees Executor { get; set; }
    }
}