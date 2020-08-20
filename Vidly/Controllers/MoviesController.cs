using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        //public IActionResult Index(int? pageIndex , string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content(string.Format("pageIndex={0} & sortBy={1}" , pageIndex , sortBy));

        //    var movie = GetMovies();
        //    return View(movie);
        //}

        public ActionResult MovieDetails(int id)
        {
            //var movie = GetMovies().SingleOrDefault(c => c.Id == id);
            /*since we get genre name and movie name together we update this linq
              var movie = _context.Movies.SingleOrDefault(m => m.Id == id);*/

            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }
        public ActionResult GenreDetails(int id)
        {
            var genre = _context.Movies.Include(g => g.GenreId == id).ToString();
            return View(genre);
        }

        // You can use attribute routing instead of map route inside startup.cs [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year , int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult Edit(int id)
        {
            return Content("id" + id);
        }

        //public IActionResult Random()
        //{
        //    var movie = new Movie()
        //    {
        //        Name = "Shrek!" ,
        //    };

        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name= "Customer 1" },
        //        new Customer {Name= "Customer 2" }
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie ,
        //        Customers = customers
        //    };
        //    return View(viewModel);

        //    return Content("hello world");
        //    return NotFound();
        //    return RedirectToAction("Privacy" , "Home");
        //}

        #region Movie Instance
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Id=1,Name="Matrix"},
                new Movie{Id=2,Name="Wall-e"},
                new Movie{Id=3,Name="Shrek"}
            };
        }

        //static List<RandomMovieViewModel> movies = new List<RandomMovieViewModel>()
        //{
        //    new RandomMovieViewModel
        //    {
        //       Movie= new Movie{Name="Wall-e"}
        //    },
        //    new RandomMovieViewModel
        //    {
        //        Movie = new Movie{Name="Matrix"}
        //    }
        //};

        #endregion
    }
}
