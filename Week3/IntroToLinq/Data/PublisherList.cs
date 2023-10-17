using IntroToLinq.Models;

namespace IntroToLinq.Data
{
    public class PublisherList : IPublisherList
    {
        List<Publisher> publishers;

        public PublisherList()
        {
            publishers = new List<Publisher>
            {
                new Publisher{Id = 1, City = "Los Angeles", Country = "United States", Name = "Universal Records"},
                new Publisher{Id = 2, City = "New York", Country = "United States", Name = "Empire"},
                new Publisher{Id = 3, City = "Nashville", Country = "United States", Name = "Cash Records"},
                new Publisher{Id = 4, City = "Seattle", Country = "United States", Name = "Subpop"},
                new Publisher{Id = 5, City = "Los Angeles", Country = "United States", Name = "Aftermath"},
            };
        }
        public List<Publisher> GetPublishers()
        {
            return publishers;
        }
    }
}
