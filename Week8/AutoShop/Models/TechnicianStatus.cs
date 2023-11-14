namespace AutoShop.Models
{
    public class TechnicianStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        //each status can be assign to multiple technicians
        public IEnumerable<Technician> Technicians { get; set; }
    }
}
