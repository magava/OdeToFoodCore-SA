using Microsoft.AspNetCore.Mvc;

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
        /**
         * The ActionResult like Content doesn't immediately write into response
         * It'll return IActionResult that tells the MVC framework what to do next
         * Here we separate deciding what to do and actually doing that thing
         * Here we're deciding to render Content
         */
        public IActionResult Index()
        {     
            return Content("Hello from in HomeController using IActionResult!!!");
        }
    }
}
