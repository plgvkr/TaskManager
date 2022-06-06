using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class ScheduledTaskController : Controller
    {
        private readonly ApplicationContext _context;
        public ScheduledTaskController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var scheduledTasks = await _context.ScheduledTasks.ToListAsync();

            return View(scheduledTasks);
        }

        [HttpGet]
        public IActionResult TaskOnDay(DateTime date, int day)
        {
            DateTime dateTime = date.AddDays(day - date.Day);
            dateTime = dateTime.Date;

            var scheduledTasks = new List<ScheduledTask>();

            var scheduledTaskForDay = _context.ScheduledTasks.Where(task => DateTime.Compare(dateTime, task.DateTime) == 0);
            var scheduledTaskEveryDay = _context.ScheduledTasks.Where(task => task.RepeatType == RepeatType.EveryDay);
            var scheduledTaskEveryWeek = _context.ScheduledTasks.Where(task => task.RepeatType == RepeatType.EveryWeek && task.DayOfWeek == dateTime.DayOfWeek);
            var scheduledTaskEveryMonth = _context.ScheduledTasks.Where(task => task.RepeatType == RepeatType.EveryMonth && task.DateTime.Day == dateTime.Day);
            var scheduledTaskEveryYear = _context.ScheduledTasks.Where(task => task.RepeatType == RepeatType.EveryYear && task.DateTime.DayOfYear == dateTime.DayOfYear);

            scheduledTasks.AddRange(scheduledTaskForDay);
            scheduledTasks.AddRange(scheduledTaskEveryDay);
            scheduledTasks.AddRange(scheduledTaskEveryWeek);
            scheduledTasks.AddRange(scheduledTaskEveryMonth);
            scheduledTasks.AddRange(scheduledTaskEveryYear);

            return View(scheduledTasks);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ScheduledTask scheduledTask)
        {
            _context.ScheduledTasks.Add(scheduledTask);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = _context.ScheduledTasks.Where(_task => _task.Id == id).FirstOrDefault();

            if (deleted != null)
            {
                _context.ScheduledTasks.Remove(deleted);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
