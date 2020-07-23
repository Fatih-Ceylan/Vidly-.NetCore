using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movies()
            {
                Name = "Shrek!"
            };

            //return View(movie);
            //return Content("hello world");
            return RedirectToAction("Privacy", "Home");
        }
    }
}
