using AutoShop.Data;
using AutoShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers
{
    public class CustomerController : Controller
    {
        //add our DbContext as a field
        ApplicationDbContext _context;
        //Constructor to assign the fields
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //The index view gets all of the customers from the database
            IEnumerable<Customer> customers = _context.Customers;
            //Passes them to the view
            return View(customers);
        }
        //Lets do Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            return Json(customer);
        }
    }
}
