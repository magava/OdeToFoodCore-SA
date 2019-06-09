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
         * If we had id in the route and also id in a query string(e.g /home/details/3?id=1),
         * we would get the one in the route (e.g. 3)
         * The framework will look in routing data before it looks in a query string
         * 
         */
        public IActionResult Details(int id)
        {
            var model = restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        /**
         * Here we don't need any parameters or view models for creating a restaurant.
         * Also pay attention that even though we don't pass a model into the view 
         * we use @model OdeToFoodCore.Models.Restaurant in Create.cshtml, which is the 
         * type of the model that we manipulate.
         * 
         * This Create should respond to HTTP Get request (/Home/Create)
         */

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        /**
         * When the user clicks on the submit button(e.g Save in Create view)
         * the form that we've rendered will create a HTTP Post that goes back to
         * /Home/Create and includes Name and Cuisine values. We want to capture 
         * these values and save them.
         * 
         * Because this comes back to Create action, we add another version of Create.
         * This version needs to take an input model.
         * 
         * We could use Restaurant as an input model aka IActionResult Create(Restaurant res)
         * Restaurant has Name property and Cuisine property, so MVC Framework would be able to
         * map the form's values into the object.
         * But it'll try to map everything tat is in the object, which is not safe as you could
         * add additional posted form values to Http request.
         * This is called overposting, when you're receiving more information in Http request 
         * than you're expecting.
         * 
         * You should create a dedicated input model that only contains the properties you'd
         * expect to post from the form. 
         * We've created RestaurantEditModel for that.
         * 
         */
        [HttpPost]
        public IActionResult Create(RestaurantEditModel model)
        {
            // We should copy the information from input model to a restaurant
            return Content("POST");
        }
    }
}
