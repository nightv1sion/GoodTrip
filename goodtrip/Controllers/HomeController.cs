using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace goodtrip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly GoodTripContext _dbContext;
        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, GoodTripContext dbContext)
        {
            _logger = logger;
            _signInManager = signInManager;
            _dbContext = dbContext;
            //SeedDataClass.SuperSeed(_dbContext);

        }
        [HttpGet]
        public IActionResult Index()
        {
            var objTourList = _dbContext.Tours.ToList();
            List<string> hotelPhotos = new List<string>();
            foreach (var objTour in objTourList)
            {
                foreach (var photo in objTour.Hotel.Images)
                {
                    hotelPhotos.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(photo.ImageData)));
                }
            }
            ViewBag.HotelPhotos = hotelPhotos;
            return View(objTourList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}