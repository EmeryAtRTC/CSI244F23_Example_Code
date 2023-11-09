using System.ComponentModel.DataAnnotations;

namespace AutoShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //Bool to track if customer is active
        [Required]
        public bool Active { get; set; }

        //There can be many vehicles associated with each customer
        public IEnumerable<Vehicle> Vehicles { get; set; }

    }
}
