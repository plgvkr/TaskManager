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

            //todo: find RepeatTypeTask
            var scheduledTaskForDay = _context.ScheduledTasks.Where(task => DateTime.Compare(dateTime, task.DateTime) == 0);

            return View(scheduledTaskForDay);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ScheduledTask scheduledTask)
        {
            _context.ScheduledTasks.Add(scheduledTask);
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
