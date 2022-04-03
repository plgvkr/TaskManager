using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class TaskData
    {
        public List<ScheduledTask> scheduledTasks { get; set; }
        public List<RepeatScheduledTask> repeatScheduledTasks { get; set; }
    }
}
