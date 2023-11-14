using AutoShop.Data;
using AutoShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers
{
    public class VehicleController : Controller
    {
        //DBcontext
        ApplicationDbContext _context;
        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Index pretty straightforward
        public IActionResult Index()
        {
            return View(_context.Vehicles);
        }
        //customerId is a foreign key in Vehicles
        //You HAVE to have a customer to make a vehicle
        //we can take a customerId as a parameter to the vehicle create
        //we can link to the endpoint from anywhere that has a customerId
        [HttpGet]
        public IActionResult Create(int customerId)
        {
            if(customerId == 0)
            {
                return NotFound();
            }
            //try to retrieve the customer
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == customerId);
            if(customer == null)
            {
                return NotFound();
            }
            //I know the customer exists
            //create a new vehicle
            Vehicle vehicle = new Vehicle
            {
                CustomerId = customer.Id,
                Customer = customer
            };
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if(!ModelState.IsValid)
            {
                Customer customer = _context.Customers.SingleOrDefault(c => c.Id == vehicle.CustomerId);
                if (customer == null)
                {
                    return NotFound();
                }
                vehicle.Customer = customer;
                return View(vehicle);
            }
            return Json(vehicle);
        }
    }
}
