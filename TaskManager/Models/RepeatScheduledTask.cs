namespace TaskManager.Models
{
    public class RepeatScheduledTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public RepeatType RepeatType { get; set; }

    }

    public enum RepeatType
    {
        EveryDay = 0,
        EveryWeek,
        EveryMonth,
        EveryYear
    }
}
