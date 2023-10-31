namespace CodeFirst.Models
{
    public class Customer
    {
        //prop tab tab
        public int Id { get; set; }
        //ctrl+shift+enter makes new line
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }

        //What navigation properties should Customer have?
        //A customer can have multiple orders
        public IEnumerable<Order> Orders { get; set; }
    }
}
