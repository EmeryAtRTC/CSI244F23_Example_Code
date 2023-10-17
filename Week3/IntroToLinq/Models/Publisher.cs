namespace IntroToLinq.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //Navigation property - This is not a column in the database
        //This needs to mirror the relationship in the data
        //There is a collection of albums associated with each publisher
        public IEnumerable<Album> Albums { get; set; }
    }
}
