namespace Project.ViewModels
{
    public class Projects_EmployeesView//модель для отображения сущности Projects_Employees
    {
        public int Id { get; set; }
        public string Employee { get; set; }//работник
        public string Project { get; set; }//название проекта
    }
}