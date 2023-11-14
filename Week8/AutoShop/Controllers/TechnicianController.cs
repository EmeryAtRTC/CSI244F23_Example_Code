using AutoShop.Data;
using AutoShop.Models;
using AutoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShop.Controllers
{
    public class TechnicianController : Controller
    {
        ApplicationDbContext _context;
        public TechnicianController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Technicians);
        }
        //We need a technician status to create a technician
        //instead of taking the foreign key into the create()
        //I am going to send all of the statuses to the view
        //and the user choses one
        //ViewModel - Data Transfer Object (DTO)
        //lets create a viewmodel for Technician Create Method
        public IActionResult Create()
        {
            //create a new select List. The actual status will show on the page, but what will post back
            //is the ID
            IEnumerable<SelectListItem> techStatusList = _context.TechnicianStatuses.Select(x => new SelectListItem
            {
                Text = x.Status,
                Value = x.Id.ToString()
            });
            //create our view model
            TechCreateVM techCreateVM = new TechCreateVM
            {
                TechStatusList = techStatusList
            };
            //send the view model to the view
            return View(techCreateVM);
        }
        [HttpPost]
        public IActionResult Create(TechCreateVM techCreateVM)
        {
            if (!ModelState.IsValid)
            {
                //the list of selectlistitem does not post back.
                //has to to be created again
                IEnumerable<SelectListItem> techStatusList = _context.TechnicianStatuses.Select(x => new SelectListItem
                {
                    Text = x.Status,
                    Value = x.Id.ToString()
                });
                techCreateVM.TechStatusList = techStatusList;
                return View(techCreateVM);
            }
            //if we get down here, we passed validation
            //Create a new technician from the viewmodel
            Technician technician = new Technician
            {
                FirstName = techCreateVM.FirstName,
                LastName = techCreateVM.LastName,
                Email = techCreateVM.Email,
                Phone = techCreateVM.Phone,
                EmployeeNumber = techCreateVM.EmployeeNumber,
                TechnicianStatusId = techCreateVM.TechnicianStatusId
            };
            _context.Technicians.Add(technician);
            _context.SaveChanges();
            return Json(technician);
        }
    }
}
