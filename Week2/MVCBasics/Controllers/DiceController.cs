using Microsoft.AspNetCore.Mvc;
using MVCBasics.Services;

namespace MVCBasics.Controllers
{
    public class DiceController : Controller
    {   
        //To get a services from the service collection
        //we take in a parameter in our constructor that matches the interface
        IDiceRoller _roller;
        public DiceController(IDiceRoller roller)
        {
            _roller = roller;
        }

        //The wrong way
        //Random random = new Random();
        public IActionResult Index()
        {
            int die1 = _roller.RollDice();
            int die2 = _roller.RollDice();
            //int die1 = random.Next(1, 7);
            //int die2 = random.Next(1, 7);
            //int die3 = random.Next();
            return Content($"You rolled {die1} and {die2}");
        }
    }
}
