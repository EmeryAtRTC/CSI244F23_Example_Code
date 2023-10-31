namespace CodeFirst.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //Navigation Properties
        //Each Product has many ProductOrders
        IEnumerable<ProductOrder> ProductOrders { get; set; }
    }
}
