using Microsoft.AspNetCore.Mvc;

namespace OdeToFoodCore.Controllers
{
    // We want the /about to reach the Phone action
    // We want the Phone action to be the default action for this controller


    // company/about/phone or company/about/address requests
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "777 777 7777";
        }


        public string Address()
        {
            return "USA";
        }
         

    }
}