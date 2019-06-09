using OdeToFoodCore.Models;
using System.Collections.Generic;

namespace OdeToFoodCore.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
