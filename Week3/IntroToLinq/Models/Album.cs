using System.ComponentModel.DataAnnotations;

namespace IntroToLinq.Models
{
    public class Album
    {
        //This is the primary key
        //.Net assumes this is the primary key
        [Key]
        public int Id { get; set; }
        //Required
        [Required(ErrorMessage = "Album Title cannot be blank")]
        public string Title { get; set; }
        [StringLength(50, ErrorMessage = "Artist cannot be more than 50 characters")]
        public string Artist { get; set; }
        [Required(ErrorMessage = "Genre cannot be blank")]
        public string Genre { get; set; }
        //Range 
        [Range(0, 999.99)]
        public decimal Price { get; set; }
    }
}
