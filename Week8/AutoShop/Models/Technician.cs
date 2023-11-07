namespace AutoShop.Models
{
    public class Technician
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string EmployeeNumber { get; set; }
        //Navigation Property - A technican can perform multiple services
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }
    }
}
