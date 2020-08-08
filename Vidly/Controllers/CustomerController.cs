using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        static List<Customer> customers = new List<Customer>()
        {
            new Customer
            {
               Name ="Fatih Ceylan",
               Id= 1,
            },
            new Customer
            {
                Name="Mahmut Tuncer",
                Id=2,
            },
            new Customer
            {
                Name="İsmail Türüt",
                Id=3,
            }
        };


        [Route("~/Customers")]
        public IActionResult Customers()
        {
            var viewModel = new RandomMovieViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {

            var customer = customers.FirstOrDefault(a => a.Id == id);
            if (customer == null)
            {
                return NotFound("Error");
            }
            return View(customer);

        }
    }
}
