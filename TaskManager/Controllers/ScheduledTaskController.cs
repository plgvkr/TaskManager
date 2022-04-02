using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;

namespace TaskManager.Controllers
{
    public class ScheduledTaskController : Controller
    {
        private readonly ApplicationContext _context;

        public ScheduledTaskController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index(DateTime date, int day)
        {
            DateTime dateTime = date.AddDays(day - date.Day);
            dateTime = dateTime.Date;

            return View();
        }
    }
}
