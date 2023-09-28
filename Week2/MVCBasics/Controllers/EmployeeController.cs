using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class EmployeeController : Controller
    {
        //field
        List<Employee> employees;

        //Random random = new Random();
        public EmployeeController()
        {
            //int randomNumber = random.Next(10);
            //Instantiate the list
            employees = new List<Employee>();
            //The most basic way
            Employee emp1 = new Employee();
            emp1.Id = 1;
            emp1.FirstName = "Will";
            emp1.LastName = "Cram";
            emp1.Phone = "243-234-1183";
            emp1.Email = "Wcram@VRGamingHQ.VR";
            emp1.Active = true;
            //add employee to the list
            employees.Add(emp1);
            //newer syntax
            Employee emp2 = new Employee
            {
                Id = 2,
                FirstName = "Lhoucine",
                LastName = "Zerrouki",
                Phone = "238-456-4653",
                Email = "LZ@Math.com",
                Active = true
            };
            employees.Add(emp2);
            //do it all in one step
            employees.Add(new Employee
            {
                Id = 3,
                FirstName = "Josh",
                LastName = "Emery",
                Phone = "238-456-1234",
                Email = "Josh@TheEldenLord.com",
                Active = false
            });
        }


        //I hit this endpoint by going to webhost/employee/index OR webhost/employee
        //Lets filter the index page by active employees
        //lets take a parameter, if we get a true we will filter employees by active
        //if we do not get anything we will not filter
        public IActionResult Index(bool filterByActive = false)
        {
            //lets check the bool that came in
            if (!filterByActive)
            {
                return View(employees);
            }
            //down here we know that filterByActive is true
            List<Employee> filteredEmployees = new List<Employee>();
            foreach (Employee emp in employees)
            {
                if (emp.Active)
                {
                    filteredEmployees.Add(emp);
                }
            }
            return View(filteredEmployees);
            //return Content("The Employee Index View is working");
            //return JSON
            //return Json(employees);
            //It looks for a file in Views/Employee/Index.cshtml
            
        }
        //Lets call this endpoint details
        public IActionResult Details(int id)
        {
            //return Content($"The id is {id}");
            if(id == 0)
            {
                //This sends a 404
                return NotFound();
            }
            foreach(Employee emp in employees)
            {
                if(emp.Id == id)
                {
                    //return Json(emp);
                    //Its going to look for a view in Views/Employee/Details.cshtml
                    return View(emp);
                }
            }
            //there was no matching employee
            return NotFound();
        }
    }
}
