﻿using Microsoft.AspNetCore.Mvc;
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
            //return NotFound();
            return RedirectToAction("Privacy", "Home");
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
    }
}