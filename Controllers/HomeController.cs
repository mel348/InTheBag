using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InTheBag.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace InTheBag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WishIndex()
        {
            Wishes myWishes = new Wishes  //create object and populate with some values
                { ID = 1, wish1 = "Wisdom", 
                  wish2 = "Health", 
                  wish3 = "Happiness"};
            string jsonWishes = JsonConvert.SerializeObject(myWishes); //Convert into a string using jsonConvert
            HttpContext.Session.SetString("wish", jsonWishes);          //Store conversion of values as Session Data
            return View();
        }
        
        public IActionResult NewWishIndex()  //returns the view
        {
            return View();
        }
        //ORIGINAL MODEL POST (Complext Data Type
        /*[HttpPost]
        public IActionResult NewWishIndex(Wishes model)  //brings in the model after user fills out the form and submits it.
        {
            Wishes myWishes = new Wishes  //create object and populate with some values
            {
                ID = 2,
                wish1 = model.wish1,            //model.wish1 connect to the model to get what they entered.
                wish2 = model.wish2,
                wish3 = model.wish3,
            };
            string jsonWishes = JsonConvert.SerializeObject(myWishes); //Convert into a string using jsonConvert
            HttpContext.Session.SetString("wish", jsonWishes);          //Store conversion of values as Session Data
            return View("WishIndex");                                   //reroute to the wish index view to see wishes
        }*/
        //Request.Form (primitive type) HttpPost
        [HttpPost]  
        public IActionResult NewWishIndex(int? ID)              //Went from a strongly typed model to a more primitive type
        { 
            Wishes myWishes = new Wishes                        //create object and populate with some values
            {
                ID = 2,
                wish1 = Request.Form["wish1"],                  //Normally name attributes, but since we use asp-for it uses the property name 
                wish2 = Request.Form["wish2"],
                wish3 = Request.Form["wish3"],
            };
            string jsonWishes = JsonConvert.SerializeObject(myWishes); //Convert into a string using jsonConvert
            HttpContext.Session.SetString("wish", jsonWishes);          //Store conversion of values as Session Data
            return View("WishIndex");                                   //reroute to the wish index view to see wishes
        }
        public IActionResult IndexViewBag() 
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Peace");
            WishList.Add("Health");
            WishList.Add("Happiness");
            ViewBag.WishList = WishList;
            return View();
        }
        public IActionResult IndexViewData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Quies");
            WishList.Add("Salutem");
            WishList.Add("Beatitudinem");
            ViewData["WishList"] = WishList;
            return View();
        }
        public IActionResult IndexTempData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("La Paz");
            WishList.Add("La Salud");
            WishList.Add("La Felicidad");
            TempData["WishList"] = WishList;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
