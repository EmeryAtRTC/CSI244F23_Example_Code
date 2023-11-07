namespace AutoShop.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        //Foreign Key - Each vehicle has one customer
        public int CustomerId { get; set; }
        //Nagivation property-does not exists in the database
        public Customer Customer { get; set; }
        //Each vehicle can have multiple services performed on it
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }
    }
}
