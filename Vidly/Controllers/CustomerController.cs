using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound("Error");
            return View(customer);
        }
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1,Name="John Smith"},
                new Customer{Id=2,Name="Mary Jane"}
            };
        }

        //static List<Customer> customers = new List<Customer>()
        //{
        //    new Customer
        //    {
        //       Name ="Fatih Ceylan",
        //       Id= 1,
        //    },
        //    new Customer
        //    {
        //        Name="Mahmut Tuncer",
        //        Id=2,
        //    },
        //    new Customer
        //    {
        //        Name="İsmail Türüt",
        //        Id=3,
        //    }
        //};

        //[Route("~/Customers")]
        //public IActionResult Customers()
        //{
        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //}

        //public IActionResult Details(int? id)
        //{

        //    var customer = customers.FirstOrDefault(a => a.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound("Error");
        //    }
        //    return View(customer);

        //}
    }
}
