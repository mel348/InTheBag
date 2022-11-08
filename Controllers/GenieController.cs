using Microsoft.AspNetCore.Mvc;
using System;

namespace InTheBag.Controllers
{
    public class GenieController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        /*[HttpPost]          //post of our action method because we don't want them to go through the above method after they submit
        public IActionResult Create(string GenieName, int Age, int WishesGranted) //Brings in the data posted by user GenieName, Age, WishesGranted
        {                                                               //checking to see if wishes are over 5000 or if age is more then 1000
            if (WishesGranted > 5000 || Age > 1000)                   //if wishes over 5000 or age is over 1000 the it returns ....         
                return View("ExperiencedGenie");                     //.. "Experience Genie"         
            else
                return View("Novice");                               //else it return Novie for wishes under 5000 and age under 1000
        }*/
        //Can use name attribute (Request.Form) even when a model exists
        //Request.Form["nameAttribute"] TO ACCESS THE VALUE
        [HttpPost]          
        public IActionResult Create(string GenieName) 
        {
            /*access wishesGranted.  It's not integer..it is considered text. Need to run through a method to convert 
             over into an integer.*/
            int Years = Int32.Parse(Request.Form["Age"]);
            int numGranted = Int32.Parse(Request.Form["WishesGranted"]);  

            if (numGranted > 5000 || Years > 1000)                      
                return View("ExperiencedGenie");                             
            else
                return View("Novice");                              
        }
        //type Genie/Create2/name/age/yearsExperience -- format of what we would type in our action method
        //example: /Genie/Create2/Lisa/33/3343

        //Will have to change endpoints to use RouteData.Values

        /*app.UseEndpoints(endpoints =>
        {
        endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

        endpoints.MapControllerRoute(
        name: "genie2",
        pattern: "{controller=Genie}/{action=Create2}/{GenieName?}/{Age?}/{WishesGranted?}");  *****This is where the variables are being pulled to in the controller
        });*/
        /*this action method will use route data to determine whether a Genie
            is experienced or not*/
        public IActionResult Create2()                              //overload map controller in startup and allowing the name, age, # wishes granted, optional
        {
            var name = RouteData.Values["GenieName"];                           
            var Years = Int32.Parse((string)RouteData.Values["Age"]);
            var numGranted = Int32.Parse((string)RouteData.Values["WishesGranted"]);

            if (numGranted > 5000 || Years > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }
        //GET METHOD
        
        public IActionResult Perks()
        {
            ViewBag.Posted = false;
            return View();
        }
        /*To include data from each one of the perks in the PerksView
        you have to put it in parameter and include it as a string array*/
        [HttpPost]
        public IActionResult Perks(string[] perk)  //(action method = Perks) and it brings in string array "perk" 
        {
            ViewBag.Posted = true;
            //ViewBag.Perks = Request.Form["perks"];        //interchangable option.
            ViewBag.Perks = perk;
            return View();
        }
    }
}
