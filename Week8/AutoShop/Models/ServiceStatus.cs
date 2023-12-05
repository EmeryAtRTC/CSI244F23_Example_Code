
using System.ComponentModel.DataAnnotations;


namespace AutoShop.Models
{
    public class ServiceStatus
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        //Navigation Property
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }

    }
}
