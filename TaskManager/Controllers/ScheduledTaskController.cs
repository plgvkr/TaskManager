using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    public class ScheduledTaskController : Controller
    {
        private readonly ApplicationContext _context;

        public ScheduledTaskController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var scheduledTasks = _context.ScheduledTasks.ToList();
            var repeatScheduledTasks = _context.RepeatScheduledTasks.ToList();

            var data = new TaskData() { scheduledTasks = scheduledTasks, repeatScheduledTasks = repeatScheduledTasks };

            return View(data);
            
        }

        public IActionResult TaskOnDay(DateTime date, int day)
        {
            DateTime dateTime = date.AddDays(day - date.Day);
            dateTime = dateTime.Date;

            return View(dateTime);
        }
    }
}
