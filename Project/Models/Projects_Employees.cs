using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Projects_Employees//cущность проект-работник
    {
        public int Id { get; set; }
        [Required]
        public int Employee { get; set; }
        [Required]
        public int Project { get; set; }
        public void Copy(Projects_Employees p_e)//контструкор копирования
        {
            Employee = p_e.Employee;
            Project = p_e.Project;
        }
    }
}