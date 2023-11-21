using AutoShop.Data;
using AutoShop.Models;
using AutoShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Controllers
{
    public class VehicleController : Controller
    {
        //DBcontext
        ApplicationDbContext _context;
        //Webhost field
        IWebHostEnvironment _environment;
        public VehicleController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        //Index pretty straightforward
        public IActionResult Index()
        {
            return View(_context.Vehicles.Include(x => x.Customer));
        }
        //customerId is a foreign key in Vehicles
        //You HAVE to have a customer to make a vehicle
        //we can take a customerId as a parameter to the vehicle create
        //we can link to the endpoint from anywhere that has a customerId
        [HttpGet]
        //Force the user to login before they create a vehicle
        [Authorize]
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
            VehicleCreateVM vehicleVM = new VehicleCreateVM
            {
                CustomerId = customer.Id,
                Customer = customer
            };
            return View(vehicleVM);
        }
        //My post is no longer taking in a Vehicle
        //It now is going to use a VehicleCreateVM
        [HttpPost]
        public IActionResult Create(VehicleCreateVM vehicleVM)
        {
            if (!ModelState.IsValid)
            {
                Customer customer = _context.Customers.SingleOrDefault(c => c.Id == vehicleVM.CustomerId);
                if (customer == null)
                {
                    return NotFound();
                }
                vehicleVM.Customer = customer;
                return View(vehicleVM);
            }
            //The image came back
            //save the image and get the filename
            string imageLocation = SaveUploadedFile(vehicleVM.VehicleImage);
            //Once we save the image we are ready to hit the database.
            //Create a vehicle from our ViewModel
            Vehicle vehicle = new Vehicle
            {
                CustomerId = vehicleVM.CustomerId,
                Make = vehicleVM.Make,
                Model = vehicleVM.Model,
                Year = vehicleVM.Year,
                VIN = vehicleVM.VIN,
                Mileage = vehicleVM.Mileage,
                ImageLocation = imageLocation,
            };
            //Add the vehicle to the database
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return Json(vehicle);
        }
        //Lets make a method that takes an IformFile as a parameter
        //gives it a random file name
        //Saves the file
        //Webhost environment
        //tell us where the project is currently located
        //using that locaion I can save the image in an image folder
        private string SaveUploadedFile(IFormFile file)
        {
            if(file != null)
            {
                //First we need to determine what folder to store this in
                string folder = Path.Combine(_environment.WebRootPath, "Images");
                //we need a random file name
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                //now we need the full path
                string fullPath = Path.Combine(folder, fileName);
                //now we have everything we need to save the file
                using (FileStream fs = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
                return fileName;
            }
            return "";
        }

    }
}
