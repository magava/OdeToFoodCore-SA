using OdeToFoodCore.Models;
using System.ComponentModel.DataAnnotations;

namespace OdeToFoodCore.ViewModels
{
    /**
     * Properties match the names of the fields we have in our form.
     * 
     */
    public class RestaurantEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
