using IntroToDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IntroToDotNet.Controllers
{
    //Controllers inherit from a base class called Controller
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //This is a constructor
        //This is the code that runs whenever a new Instance of HomeContoller
        //is created
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Console.WriteLine("The Home Constructor is running");
        }
        //Actions are just Methods
        //This method runs whenever the user goes to /Home/Index
        //Or if they do not specify a path
        public IActionResult Index()
        {
            Console.WriteLine("We hit /home/index");
            //This sends the user to the corresponding
            //This will look for a view inside of /Views/Home/Index.cshtml
            //The same pattern as the routing
            //Views/ControllerName/ActionName.cshtml
            return View();
        }
        //This method runs whenver the user goes to /Home/Privacy
        public IActionResult Privacy()
        {
            Console.WriteLine("We hit /home/privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}