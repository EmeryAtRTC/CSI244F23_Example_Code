using AutoShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShop.ViewModels
{
    public class TechCreateVM
    {
        //Viewmodel is a container for EVERYTHING
        //that either has to go to the view
        //OR come back from the view
        //To create a technician we need all of the stuff from the tech model
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string EmployeeNumber { get; set; }
        public int TechnicianStatusId { get; set; }
        //I want to send a select list to the view
        public IEnumerable<SelectListItem> TechStatusList { get; set; }
        //Navigation Property - A technican can perform multiple services
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }
        //Each technician has one status
        public TechnicianStatus TechnicianStatus { get; set; }
    }
}
