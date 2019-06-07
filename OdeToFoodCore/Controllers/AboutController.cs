using Microsoft.AspNetCore.Mvc;

namespace OdeToFoodCore.Controllers
{
    // We want the /about to reach the Phone action
    // We want the Phone action to be the default action for this controller



    // MVC framework will go to AboutController but as there are two public methods
    // it doesn't know which one to execute when we go to /about and we'll get
    // AmbiguousActionException: Multiple actions matched. 
    // The following actions matched route data and had all constraints satisfied:
    // OdeToFoodCore.Controllers.AboutController.Phone(OdeToFoodCore)
    // OdeToFoodCore.Controllers.AboutController.Address(OdeToFoodCore)


    [Route("about")]
    public class AboutController
    {
        [Route("")]
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