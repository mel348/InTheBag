using System;
using Microsoft.AspNetCore.Mvc;

namespace InTheBag.Controllers
{
    public class AllAboutResultsController : Controller
    {
        public IActionResult Index()
        {
            var weekday = DateTime.Now.DayOfWeek;                   //retrieving weekday
            var day = weekday.ToString();                           //getting day of the week by converting weekday to string
            var time = DateTime.Now.Hour;                            //getting current time

            if (time <= 6)                                          //getting a message based on the time (military time setup)
            {
                ViewBag.Greeting = "It is too early to be up!";
            }
            else if (time <= 12)
            {
                ViewBag.Greeting = "Good Morning";
            }
            else if (time <= 18)
            {
                ViewBag.Greeting = "Good Afternoon";
            }
            else
            {
                ViewBag.Greeting = "Good Evening";
            }
            //generate different messages based on the day of the week.
            //key is dayMessage  and objects are the messages.
            int route = 0;                                          
            //day = "Thursday";                                         //to test the days of the week.
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                    ViewData["dayMessage"] = "The work week just started!  Stay focused, you have a lot to do this week!";
                    route = 1;
                    break;
                case "Wednesday":
                    ViewData["dayMessage"] = "Halfway to the weekend!";
                    route = 2;
                    break;
                case "Thursday":
                    ViewData["dayMessage"] = "Isn't it Friday somewhere?";
                    route = 3;
                    break;
                case "Friday":
                    ViewData["dayMessage"] = "Woo Hoo TGIF";
                    route = 4;
                    break;
                default:
                    ViewData["dayMessage"] = "Let the weekend begin!";
                    route = 5;
                    break;
            }
            //redirect to a different action method or to a URL
            if (route == 1)
            {
                return RedirectToAction("Weekday", "AllAboutResults");                           //goes to Weekday, in the AllAboutResults controller
            }
            else if (route == 2 || route == 3)
            {
                return Redirect("https://lisabalbach.com/CIT218/Chapter8/HappyWednesday.html"); //takes you to an external website
            }
            else
            {
                return View();                                                                  //return the normal view
            }
        }
        //Weekday action method
        public IActionResult Weekday()
        {
            ViewBag.Greeting = "Congratulations, the work week just started and you have been rerouted!";
            return View();
        }
    }
}
