using IntroToLinq.Data;
using IntroToLinq.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLinq.Controllers
{
    public class PublisherController : Controller
    {
        //fields
        IEnumerable<Album> _albums;
        IEnumerable<Publisher> _publishers;
        //pull in the services from dependency injection
        public PublisherController(IAlbumList albumService, IPublisherList publisherService)
        {
            _albums = albumService.GetAlbums();
            _publishers = publisherService.GetPublishers();
        }
        public IActionResult Index()
        {
            return View();
        }
        //Lets make an endpoint that finds the publisher based on an albumId
        public IActionResult PublisherForAlbum(int albumId)
        {
            //we need to find the publisher based on an albumIn
            //Where is the publisherID that I need?
            //First I need to get the album
            //Inside of that album is publisherId foreign key which I can then use to get the publisher
            Album a = _albums.SingleOrDefault(a => a.Id == albumId);
            //Now I have the album, each album has one publisher associated with it
            Publisher publisher = _publishers.SingleOrDefault(p => p.Id == a.PublisherId);
            //what condition should I used to find all the albums with a given publisher
            publisher.Albums = _albums.Where(a => a.PublisherId == publisher.Id);
            return Json(publisher);
        }
    }
}
