namespace Project.Models.Filters
{
    public class TaskFilter//Модель для фильра задач
    {
        public string name { get; set; }//название задачи
        public string author { get; set; }//имя автора
        public string executor { get; set; }//имя исполнителя
        public string status { get; set; }//статус задачи
        public int priority { get; set; }//целочисленный приоритет
        public int project { get; set; }//к какому пректу относится
    }
}