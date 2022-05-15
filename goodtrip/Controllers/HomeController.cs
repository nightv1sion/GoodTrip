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
            //SeedData1();
        }

        public IActionResult Index()
        {
            /* ImageExcurtion img = _dbContext.ImageExcurtion.First();
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
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\los-angelesExcursion1.jpg", FileMode.Open);
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
        public void SeedData1()
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Meeting New York",
                City = "New-York",
                Country = "USA",
                Description = "You will meet New-York and get to know a lot of about this amazing city",
                Duration = 6,
                MaxTourists = 4,
                TourOperator = "AmericanToursFE",
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Springhill by Marriott Midtown Manhattan",
                City = "New-York",
                Description = "The most modern hotel of the East",
                Country = "USA",
                Address = "111 East 24 Street",
                Feeding = true,
                FreeRooms = 28,
                Rooms = 50,
                IsWifi = true,
                Mark = 5,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SpringHill.jpg", FileMode.Open);
            List <ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Niaghara Waterfall",
                Description = "Morning trip to NW",
                Duration = 8,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Niaghara Waterfall",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\NigWat.jpg", FileMode.Open);
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
        public void SeedData2()
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Las-Vegas",
                City = "Las-Vegas",
                Country = "USA",
                Description = "We offer a guaranteed tour to Las Vegas for 4 days, with accommodation in the center of the Strip in hotel. During the tour you will learn all about Las Vegas, its main attractions and the best casinos. If you wish, you can go on an excursion to Death Valley or Hoover Dam.",
                Duration = 4,
                MaxTourists = 3,
                TourOperator = "AmericanToursFE",
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Harrah’s",
                City = "Las-Vegas",
                Description = "At Harrah’s, playtime is never over. Harrah’s offers a fun gaming atmosphere, world-class entertainment and welcoming rooms. Here is a place that’s friendly, lighthearted and exciting – the perfect spot to come out and play.",
                Country = "USA",
                Address = "3475 S Las Vegas Blvd",
                Feeding = false,
                FreeRooms = 10,
                Rooms = 25,
                IsWifi = true,
                Mark = 3,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Harra.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Evening Las-Vegas",
                Description = "Morning trip to NW",
                Duration = 8,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Niaghara Waterfall",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\NigWat.jpg", FileMode.Open);
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