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
            //SeedData();
        }

        public IActionResult Index()
        {
            /*ImageExcurtion img = _dbContext.ImageExcurtion.First();
            string imageBase64Data =
            Convert.ToBase64String(img.ImageData);
            string imageDataURL =
            string.Format("data:image/jpg;base64,{0}",
            imageBase64Data);
            ViewBag.ImageDataUrl = imageDataURL;*/
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void SeedData()
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "The American Dream",
                City = "Los-Angeles",
                Country = "USA",
                Description = "SuperDescription",
                Duration = 7,
                MaxTourists = 5,
                TourOperator = "PETYA",
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Marriott LAX 4",
                City = "Los-Angeles",
                Description = "SUKAUSKAUSKAUKSUAKUS",
                Country = "USA",
                Address = "5855 West Century Boulevard",
                Feeding = true,
                FreeRooms = 13,
                Rooms = 40,
                IsWifi = true,
                Mark = 4,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Данила\\Desktop\\GT\\goodtrip\\goodtrip\\Storage\\Images\\hotelLAX.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(),ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id}
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Getting to know Los Angeles",
                Description = "",
                Duration = 12,
                Language = "English",
                MaxAmountOfVisitors = 10,
                Place = "LAX",
                Price = 0,
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Данила\\Desktop\\GT\\goodtrip\\goodtrip\\Storage\\Images\\los-angelesExcursion1.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
    }
}