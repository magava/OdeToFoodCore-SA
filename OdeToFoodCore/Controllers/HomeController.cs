using Microsoft.AspNetCore.Mvc;
using OdeToFoodCore.Services;
using OdeToFoodCore.ViewModels;

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
        private IGreeter greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            this.restaurantData = restaurantData;
            this.greeter = greeter;
        }
       
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = restaurantData.GetAll();
            model.CurrentMessage = greeter.GetMessageOfTheDay();
            return View(model);
        }


        /**
         * We want to give the user an ability to click on a link and go to the Details
         * and see everything about a specific restaurant.
         * This link will have to point to a new controller action that builds a different
         * type of model, a model that contains a single restaurant.
         * In the order for the controller to locate a restaurant that we want we need to 
         * pass along an input model, which in this case can be the id
         * The MVC Framework will look for something called id everywhere.
         * One of the places is inside routing data (/Home/Index/4). 
         * The third segment of the URL will be id.
         * 
         */
        public IActionResult Details(int id)
        {
            return Content(id.ToString());
        }
    }
}
