namespace Project.Models
{
    public class Projects_Employees//cущность проект-работник
    {
        public int Id { get; set; }
        public int Employee { get; set; }
        public int Project { get; set; }

    }
}