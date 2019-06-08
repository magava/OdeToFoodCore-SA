using Microsoft.AspNetCore.Mvc;
using OdeToFoodCore.Services;

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
        private IRestaurantData restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
       
        public IActionResult Index()
        {
            var model = restaurantData.GetAll();
            return View(model);
        }
    }
}
