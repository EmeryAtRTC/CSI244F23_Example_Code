using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class ProductController : Controller
    {
        //Add your dbcontext as field to the controller
        StoreContext _context;
        //Constrcutor assigns values to the field
        public ProductController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //get our products out of the database
            IEnumerable<Product> products = _context.Products;
            //send them to the view
            return Json(products);
        }
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Product product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Json(product);
        }
        //Create - Create involves a Get and a Post
        [HttpGet]
        public IActionResult Create()
        {
            //All this does is send them a form
            //Located in Views/Product/Create.cshtml
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            //if modelstate is not valid send the user back to the form
            //with error messages
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            //Down here we know that the model is valid
            //We add it to the List
            _context.Products.Add(product);
            //When you call add, EF sets up some SQL Statements that it is going run
            //It runs them when you call SaveChanges()
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
