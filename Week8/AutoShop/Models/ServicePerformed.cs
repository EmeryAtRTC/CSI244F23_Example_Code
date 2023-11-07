namespace AutoShop.Models
{
    public class ServicePerformed
    {
        public int Id { get; set; }
        public DateTime TimePerformed { get; set; }
        public string Notes { get; set; }
        //Each service will be associated with one Vehicle
        //and one Technician
        public int TechnicianId { get; set; }
        public int VehicleId { get; set; }
        //Navigation
        public Technician Technician { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
