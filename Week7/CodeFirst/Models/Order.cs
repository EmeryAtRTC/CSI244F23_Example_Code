namespace CodeFirst.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        //Foreign Key references the Customer Table
        public int CustomerId { get; set; }

        //What can go down here - Makes our lives much easier
        //Navigation Propery
        //This navigation property only exists in our C#
        //This is not a column in the database
        public Customer Customer { get; set; }
        //Each Order has a collection of ProductOrder
        public IEnumerable<ProductOrder> ProductOrders { get; set; }
    }
}
