using Microsoft.AspNetCore.Mvc;
using OdeToFoodCore.Models;

namespace OdeToFoodCore.Controllers
{

    /**
     * This is a usual C# class.
     * By default HomeController will receive a request to the root of the application.
     * MVC will create the HomeController class and invoke the Index method.
     * We'll see "Hello from HomeController!!!" when go to the root.
    */

    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Pizza Place" };
            return View(model);
        }
    }
}
