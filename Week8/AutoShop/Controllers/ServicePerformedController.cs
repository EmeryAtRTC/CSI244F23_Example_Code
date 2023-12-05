using AutoShop.Data;
using AutoShop.Models;
using AutoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShop.Controllers
{
    public class ServicePerformedController : Controller
    {
        ApplicationDbContext _context;
        public ServicePerformedController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Create a Service Performed
        //3 foreign keys
        //vehicleId
        //techId
        //serviceStatusId
        [HttpGet]
        public IActionResult Create(int vehicleId)
        {
            //we have to have a vehicle
            if(vehicleId == 0)
            {
                return NotFound();
            }
            Vehicle vehicle = _context.Vehicles.SingleOrDefault(x => x.Id == vehicleId);
            if(vehicle == null)
            {
                return NotFound();
            }
            //if we make it down here we know that the vehicle exists
            ServicePerformedCreateVM spCreateVM = new ServicePerformedCreateVM();
            spCreateVM.VehicleId = vehicleId;
            spCreateVM.Vehicle = vehicle;
            //lets prepare the selectLists
            spCreateVM.TechnicianList = _context.Technicians.Select(t => new SelectListItem
            {
                Text = $"{t.FirstName} {t.LastName}",
                Value = t.Id.ToString()
            });
            //now we need a status List
            spCreateVM.ServiceStatusList = _context.ServiceStatuses.Select(s => new SelectListItem
            {
                Text = s.Status,
                Value = s.Id.ToString()
            });
            spCreateVM.TimePerformed = DateTime.Now;
            return View(spCreateVM);
        }
        [HttpPost]
        public IActionResult Create(ServicePerformedCreateVM spCreateVM)
        {
            //if we fail server side validation, prepare the viewmodel again
            if (!ModelState.IsValid)
            {
                Vehicle vehicle = _context.Vehicles.SingleOrDefault(x => x.Id == spCreateVM.VehicleId);
                spCreateVM.Vehicle = vehicle;
                //lets prepare the selectLists
                spCreateVM.TechnicianList = _context.Technicians.Select(t => new SelectListItem
                {
                    Text = $"{t.FirstName} {t.LastName}",
                    Value = t.Id.ToString()
                });
                //now we need a status List
                spCreateVM.ServiceStatusList = _context.ServiceStatuses.Select(s => new SelectListItem
                {
                    Text = s.Status,
                    Value = s.Id.ToString()
                });
                spCreateVM.TimePerformed = DateTime.Now;
                return View(spCreateVM);
            }
            //If we get down here we know the model is vald
            ServicePerformed sp = new ServicePerformed
            {
                ServiceStatusId = spCreateVM.ServiceStatusId,
                TechnicianId = spCreateVM.TechnicianId,
                VehicleId = spCreateVM.VehicleId,
                Notes = spCreateVM.Notes,
                TimePerformed = spCreateVM.TimePerformed
            };
            _context.ServicesPerformed.Add(sp);
            _context.SaveChanges();
            return Json(sp);
        }
    }
}
