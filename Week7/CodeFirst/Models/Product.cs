using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0, 100000)]
        [Column(TypeName = "decimal(8, 2)")]
        //The column data annotation takes SQL String datatype
        public decimal Price { get; set; }
        //Lets say our client called us and said they need to record barcode number
        [Required]
        [StringLength(30)]
        public string BarCode { get; set; }

        //Navigation Properties
        //Each Product has many ProductOrders
        IEnumerable<ProductOrder> ProductOrders { get; set; }
    }
}
