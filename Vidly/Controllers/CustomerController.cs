using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm" , viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter ;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index" , "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer ,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm" , viewModel);
        }
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            //include extension used for eager loading. otherwise we get null ex ref
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound("Error");

            return View(customer);
        }

        /* No longer needed codes */

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id=1,Name="John Smith"},
        //        new Customer{Id=2,Name="Mary Jane"}
        //    };
        //}

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
