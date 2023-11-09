using AutoShop.Data;
using AutoShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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
            IEnumerable<Customer> customers = _context.Customers.Where(c => c.Active);
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
            if (!ModelState.IsValid)
            {
                //we send them back with error messages
                return View(customer);
            }
            //down here we are confident that customer is valid
            _context.Customers.Add(customer);
            //we save changes to run the sql 
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //details takes in an id, but there is only a get
        [HttpGet]
        public IActionResult Details(int id)
        {
            //get the customer out of the database, 
            //make sure that the customer exists and send to the view
            if(id == 0)
            {
                return NotFound();
            }
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer is null)
            {
                return NotFound();
            }
            //we found a customer
            return View(customer);
        }
        //Edit takes an id like details
        //it has a get and post like Create
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //get the customer out of the database, 
            //make sure that the customer exists and send to the view
            if (id == 0)
            {
                return NotFound();
            }
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            //we found a customer
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            //Update - the new way
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
            //The old way, and sometims you still have to do it this way
            //Customer c = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
            //if(c is null)
            //{
            //    return NotFound();
            //}
            //c.FirstName = customer.FirstName;
            //c.LastName = customer.LastName;
            //c.Phone = customer.Phone;
            //c.Email = customer.Email;
            //_context.SaveChanges();
        }
        //Lets talk about delete
        //Delete is a really sensitive operation
        //Delete just needs an ID but we make a get and a post just to make sure
        //they want to delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //get the customer out of the database, 
            //make sure that the customer exists and send to the view
            if (id == 0)
            {
                return NotFound();
            }
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            //we found a customer
            return View(customer);
        }
        [HttpPost]
        //simulate delete
        public IActionResult Delete(Customer customer)
        {
            if(customer.Id == 0)
            {
                return NotFound();
            }
            Customer c = _context.Customers.SingleOrDefault(c => c.Id ==  customer.Id);
            //we are simulating delete
            //so now delete just makes a customer inactive
            c.Active = false;
            //remove from the database
            //_context.Customers.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
