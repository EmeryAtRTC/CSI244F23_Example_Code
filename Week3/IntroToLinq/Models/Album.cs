using System.ComponentModel.DataAnnotations;

namespace IntroToLinq.Models
{
    public class Album
    {
        //This is the primary key
        //.Net assumes this is the primary key
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
