namespace TaskManager.Models
{
    public class ScheduledTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DateTime { get; set; }
        public bool IsCompleted { get; set; }

    }
}
