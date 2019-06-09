using OdeToFoodCore.Models;

namespace OdeToFoodCore.ViewModels
{
    /**
     * Properties match the names of the fields we have in our form.
     * 
     */
    public class RestaurantEditModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
