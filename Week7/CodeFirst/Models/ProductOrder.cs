namespace CodeFirst.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        //Navigation Properties?
        //There are two
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
