using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vidly.Models;
using Vidly.ViewModels;

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

            var customers = new List<Customer>
            {
                new Customer {Name= "Customer 1" },
                new Customer {Name= "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("hello world");
            //return NotFound();
            //return RedirectToAction("Privacy", "Home");
        }
        public ActionResult Edit(int id)
        {
            return Content("id" + id);
        }
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(string.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));
        }
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
