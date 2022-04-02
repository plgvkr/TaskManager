using Microsoft.AspNetCore.Mvc;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    public class CalendarController : Controller
    {


        public IActionResult Index(int shiftMonth)
        {
            Calendar calendar = new Calendar(shiftMonth);

            return View(calendar);
        }
    }
}
