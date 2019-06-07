using Microsoft.AspNetCore.Mvc;

namespace OdeToFoodCore.Controllers
{
    // We want the /about to reach the Phone action
    // We want the Phone action to be the default action for this controller


    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "777 777 7777";
        }


        [Route("[action]")]
        public string Address()
        {
            return "USA";
        }
         

    }
}