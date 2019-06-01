namespace Project.Models.Filters
{
    public class TaskFilter
    {
        public string name { get; set; }
        public string author { get; set; }
        public string executor { get; set; }
        public string status { get; set; }
        public int priority { get; set; }
    }
}