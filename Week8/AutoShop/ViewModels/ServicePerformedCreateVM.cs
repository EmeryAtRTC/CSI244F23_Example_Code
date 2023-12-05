using AutoShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShop.ViewModels
{
    public class ServicePerformedCreateVM
    {
        public int Id { get; set; }
        public DateTime TimePerformed { get; set; }
        public string Notes { get; set; }
        //Each service will be associated with one Vehicle
        //and one Technician
        public int TechnicianId { get; set; }
        public int VehicleId { get; set; }
        public int ServiceStatusId { get; set; }
        //Navigation
        public Technician Technician { get; set; }
        public Vehicle Vehicle { get; set; }
        //I need to send a selectList for Technicians
        //I need to send a selectlist for status
        public IEnumerable<SelectListItem> TechnicianList { get; set; }
        public IEnumerable<SelectListItem> ServiceStatusList { get; set; }
    }
}
