namespace AutoShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //There can be many vehicles associated with each customer
        public IEnumerable<Vehicle> Vehicles { get; set; }

    }
}
