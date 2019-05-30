namespace Project.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Customer { get; set; }
        public string Executor { get; set; }
        public string Manager { get; set; }
        public string Date_start { get; set; }
        public string Date_end { get; set; }
        public int Priority { get; set; }
    }
}