using System.Collections.Generic;
using System.Linq;
using OdeToFoodCore.Models;

namespace OdeToFoodCore.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Pizza Place"},
                new Restaurant {Id = 2, Name = "Tersiguels"},
                new Restaurant {Id = 3, Name = "King's Contrivance"},
            };
        }


        /**
         * Here we're dealing with a service that holds the restaurant data in memory in a list.
         * We're modifying that list.
         * We want every Http request that comes to the application to see the same list.
         * 
         * To do this we've changed the Scoped lifetime of the InMemoryRestaurantData service 
         * to Singleton via services.AddSingleton in ConfigureServices.
         * This should be used for test in development, not in production.
         */
        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
            return restaurant;
        }


        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }


        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
