using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class ScheduledTaskController : Controller
    {
        public IActionResult Index(DateTime date, int day)
        {
            return View();
        }
    }
}
