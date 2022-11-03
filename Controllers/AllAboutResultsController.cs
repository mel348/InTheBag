using System;
using Microsoft.AspNetCore.Http; //when using session data must use this
using Microsoft.AspNetCore.Mvc;

namespace InTheBag.Controllers
{
    public class AllAboutResults : Controller
    {
        public IActionResult Index()
        {
            var weekday = DateTime.Now.DayOfWeek;
            var day = weekday.ToString();
            var time = DateTime.Now.Hour;
            //greetings are being stored as a session variable using SetString.
            //greet key
            if (time <= 6)
            {
                HttpContext.Session.SetString("greet", "It is too early to be up!");
            }
            else if (time <= 12)
            {
                HttpContext.Session.SetString("greet", "Good Morning");
            }
            else if (time <= 18)
            {
                HttpContext.Session.SetString("greet", "Good Afternoon");
            }
            else
            {
                HttpContext.Session.SetString("greet", "Good Evening");
            }
            int route = 0;
            /*retrieving with "dayMsg".  The way the app knows what to retrieve is it's taking the session id and
            storing it as a cookie.  When we send a request from our client it is sending that session id and 
             matching it up.  That way it knows which one we are.*/
            //day message key
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                    HttpContext.Session.SetString("dayMsg", "The work week just started!  Stay focused, you have a lot to do this week!");
                    route = 1;
                    break;
                case "Wednesday":
                    HttpContext.Session.SetString("dayMsg", "Halfway to the weekend!");
                    route = 2;
                    break;
                case "Thursday":
                    HttpContext.Session.SetString("dayMsg", "Isn't it Friday somewhere?");
                    route = 3;
                    break;
                case "Friday":
                    HttpContext.Session.SetString("dayMsg", "Woo hoo TGIF");
                    route = 4;
                    break;
                default:
                    HttpContext.Session.SetString("dayMsg", "Ahhhh   the weekend!");
                    route = 5;
                    break;
            }
            //route = 5;  remove comment to test out the routing
            if (route == 1)
            {
                return RedirectToAction("Weekday", "AllAboutResults");
            }
            else if (route == 2 || route == 3)
            {
                return Redirect("https://lisabalbach.com/CIT218/Chapter8/HappyWednesday.html");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Weekday()
        {
            //Session Data
            HttpContext.Session.SetString("greet", "Congratulations, the work week just started and you have been rerouted!");
            return View();
        }
    }
}






//This has the view data and viewbags that we were using to pass from the controller to views.
//Above this commented code we are using session data instead.

/*using System;
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
                return Redirect(""); //takes you to an external website
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
}*/
