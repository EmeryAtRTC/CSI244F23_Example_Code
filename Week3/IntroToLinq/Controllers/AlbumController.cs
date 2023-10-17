using IntroToLinq.Models;
using IntroToLinq.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntroToLinq.Controllers
{
    public class AlbumController : Controller
    {
        //AlbumList albums = new AlbumList();
        //lets create our fields
        IAlbumList _albumService;
        List<Album> _albums;
        List<Publisher> _publishers;
        //constructor assigns values to the fields
        public AlbumController(IAlbumList albumService, IPublisherList publisherService)
        {
            _albumService = albumService;
            _albums = _albumService.GetAlbums();
            _publishers = publisherService.GetPublishers();
        }
        //Lets modify the index
        //lets take in some parameters that we may want to filter by
        //lets take in a genre, if genre receives a value filter by it
        //if it does not get a value show all albums
        public IActionResult Index(string genre, string title)
        {
            //lets get all the distinct genres
            IEnumerable<string> genres = _albums.Select(x => x.Genre).Distinct();
            IEnumerable<SelectListItem> genreSelect = genres.Select(g => new SelectListItem
            {
                Text = g,
                Value = g,
                Selected = genre == g
            });
            ViewBag.genreList = genreSelect;

            //if genre contains a value
            if (!string.IsNullOrEmpty(genre))
            {
                IEnumerable<Album> filteredAlbums = _albums.Where(a => a.Genre == genre);
                return View(filteredAlbums);
            }

            //lets check to see if title has a value
            if (!string.IsNullOrEmpty(title))
            {
                //search the albums for a matching title
                //search albums for all titles that contained the search value, ignore case
                IEnumerable<Album> filteredAlbums = _albums.Where(a => a.Title.ToLower().Contains(title.ToLower()));
                return View(filteredAlbums);
            }
            //filter the albums
            //Where() method
            //Find the albums where the price is 9.99
            //IEnumerable<Album> filteredAlbums = _albums.Where(album => album.Price == 9.99m);
            //return Json(_albums);
            //This is going to look for a View AT /Views/Album/Index.cshtml
            return View(_albums);
        }
        //details we only want one album
        //we want the album that matches a given id
        public IActionResult Details(int id)
        {
            //check and make sure that id has a value
            if(id == 0)
            {
                return NotFound();
            }
            //I want to go through the AlbumList and get the
            //album with the matching ID
            //I only want ONE album
            Album album = _albums.SingleOrDefault(a => a.Id == id);
            //check to make sure that we found an album
            if (album is null)
            {
                return NotFound();
            }
            //if we make it down here we know that we found an Ablum
            return View(album);
        }

        //Lets do a Create - 2 steps
        //First we send the user a form to fill out
        //Then the user sends us information from the form - POST Request

        [HttpGet]
        //This endpoint can only take Get Requests - GET is the default
        public IActionResult Create()
        {
            //lets try to generate a list of the genres from the album list
            //What I have is a list of Album, what I need is a list of Genre(string)
            //Select() converts from one type of collection to another
            IEnumerable<string> genres =  _albums.Select(a => a.Genre).Distinct();
            //return Json(genres);
            //I need a collection of SelectListItem
            //SelectListItem has three properties
            //Text, Value, Selected
            IEnumerable<SelectListItem> selectList = genres.Select(genre => new SelectListItem
            {
                Text = genre,
                Value = genre
            });
            //return Json(selectList);
            //There is a container in .net called the ViewBag
            //It is automatically sent to every view
            //Its an generic object container
            ViewBag.genreList = selectList;
            return View();
        }
        //Part2 POST
        [HttpPost]
        public IActionResult Create(Album album)
        {
            //We need to check that the ModelState is valid
            if (!ModelState.IsValid)
            {
                //Anything that was passed in the ViewBag has to be re-created
                //before we send the user back
                //We just need to generate our list again
                IEnumerable<string> genres = _albums.Select(a => a.Genre).Distinct();
                IEnumerable<SelectListItem> selectList = genres.Select(genre => new SelectListItem
                {
                    Text = genre,
                    Value = genre
                });
                ViewBag.genreList = selectList;
                //send the user back to the view if they fail validation
                return View(album);
            }

            //An album comes into this method
            //Lets set the primary key by hand (normally the database does this)
            album.Id = _albums.Count() + 1;
            //add the album to our list
            _albums.Add(album);
            //Where do we go from here
            //Send the user back to the index
            return RedirectToAction("Index");
            //return Json(album); 
        }

        //An Edit - Edit is similar to create, the difference is that the Album already exists for an Edit
        //GET POST
        //The post is similar to create. An album comes back from the form. 
        //We have to go through the database and find the album and update it with the new info
        //The GET is similar to the details. We take in an ID. Make sure the ID was populated
        //Get the album out of the database that matches the ID. Make sure that album exists
        //Then pass the Album to a form for the user to fill out
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Album album = _albums.SingleOrDefault(a => a.Id == id);
            //check to make sure that the album exists
            if(album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            //Check the ModelState Object
            if(!ModelState.IsValid)
            {
                //if validation fails send the user back to the view and pass the model
                return View(album);
            }
            //if I make it down here I know that I passed validation
            //pull the album out of the data
            Album albumToUpdate = _albums.SingleOrDefault(a => a.Id == album.Id);
            //check to make sure that album exists
            if(albumToUpdate == null)
            {
                return NotFound();
            }
            albumToUpdate.Title = album.Title;
            albumToUpdate.Artist = album.Artist;
            albumToUpdate.Price = album.Price;
            albumToUpdate.Genre = album.Genre;
            //Where should we go from here, Where should we send the user?
            //Lets redirect to details for the updatedAlbum
            //Passing an ID to Details using an anonymous object
            return RedirectToAction("Details", new { id = album.Id});
        }
        

        //lets make an endpoint that shows all the albums ordered by price
        //what if we wanted to modify this to genre and desc
        public IActionResult OrderByPrice(string genre, bool desc = true)
        {
            if(desc)
            {
                return Json(_albums.OrderByDescending(a => a.Price).Where(a => a.Genre == genre));
            }
            //there is an impled else
            return Json(_albums.OrderBy(a => a.Price).Where(a=> a.Genre == genre));
        }
        //We want to get the albums that are associated with a given publisherId
        public IActionResult AlbumsByPublisher(int publisherId)
        {
            //get all of the albums that are associated with this parameter
            //IEnumerable<Album> filteredAlbums = _albums.Where(a => a.PublisherId == publisherId);
            //get the publisher from the publishers collection
            //Publisher publisher = _publishers.SingleOrDefault(p => p.Id == publisherId);
            //List of album and we want to include the publisher
            IEnumerable<Album> filteredAlbums = _albums.Where(a => a.PublisherId == publisherId).Select(a => new Album
            {
                Id =a.Id,
                Artist = a.Artist,
                Title = a.Title,
                Genre = a.Genre,
                Price = a.Price,
                PublisherId = a.PublisherId,
                Publisher = _publishers.SingleOrDefault(p => p.Id == publisherId)
            });
            return View(filteredAlbums);
        }
    }
}
