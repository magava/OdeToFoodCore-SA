using OdeToFoodCore.Models;
using System.Collections.Generic;

namespace OdeToFoodCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
