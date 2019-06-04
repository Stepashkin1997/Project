namespace Project.ViewModels
{
    public class ProjectView//класс для отображения сущности Project 
    {
        public int Id { get; set; }//столбец индификации
        public string Name { get; set; }//название проекта
        public string Customer { get; set; }//название компании-заказчика
        public string Executor { get; set; }//название компании-исполнителя
        public string Manager { get; set; }//руководитель проекта
        public string Date_start { get; set; }//дата начала проекта
        public string Date_end { get; set; }//дата окончания проекта
        public int Priority { get; set; }//приоритет проекта
    }
}