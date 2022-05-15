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
            SeedData();
            SeedData1();
            SeedData2();
            SeedData3();
            SeedData4();
            SeedData5();
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
                Description = "Fulfill your American Dream! Visit LA with us.",
                Duration = 7,
                StartDate = new DateTime(2022, 5, 18),
                EndDate = new DateTime(2022, 5, 25),
                MaxTourists = 5,
                TourOperator = "TravelAroundTheUS",
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Marriott LAX 4",
                City = "Los-Angeles",
                Description = "The Los Angeles Marriott Airport is an excellent choice for guests of Los Angeles, the family atmosphere and many useful services will make your stay very pleasant.",
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
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\hotelLAX.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(),ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id}
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\hotelLAX2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\hotelLAX3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Getting to know Los Angeles",
                Description = "Los Angeles, getting to know the city. Excursion to the historical and modern center, Griffith Park - a fantastic panorama of the city, a photo session against the background of the famous inscription HOLLYWOOD.",
                Duration = 12,
                Language = "English",
                MaxAmountOfVisitors = 10,
                Place = "Around the Los Angeles",
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
                StartDate = new DateTime(2022, 5, 20),
                EndDate = new DateTime(2022, 5, 26),
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
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SpringHill2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SpringHill3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
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
                StartDate = new DateTime(2022, 5, 28),
                EndDate = new DateTime(2022, 6, 02),
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
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Harra2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Harra3.jpg", FileMode.Open);
            ms = new MemoryStream();
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
                Description = "Evening excursion in LV to see lost of sights",
                Duration = 4,
                Language = "English",
                MaxAmountOfVisitors = 12,
                Place = "Center of Las-Vegas",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\EVex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion2 = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "To the Grand Canyon",
                Description = "Enjoy 6 hours at the Grand Canyon, compared to 3 hours offered by other companies. West Rim includes Eagle Point & Guano Point. Photo stop at the Hoover Dam Bypass",
                Duration = 6,
                Language = "English",
                MaxAmountOfVisitors = 8,
                Place = "Grand Canyon",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\GCex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages2 = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion2, ExcurtionId = excurtion2.Id }
            );
            excurtion2.Images = excurtionimages2;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            tour.Excurtion.Add(excurtion2);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public void SeedData3()
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Maiami Beaches",
                City = "Maiami",
                Country = "USA",
                Description = "The luxury and glitz of the American oceanfront lifestyle",
                Duration = 8,
                StartDate = new DateTime(2022, 5, 31),
                EndDate = new DateTime(2022, 6, 07),
                MaxTourists = 8,
                TourOperator = "SandAndWater",
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "TRUMP INTERNATIONAL BEACH RESORT",
                City = "Maiami",
                Description = "A modern oceanfront hotel in the Sunny Isles area. The hotel was built by the famous entrepreneur and millionaire Donald Trump and in 2008 became part of The Leading Hotels of the World.",
                Country = "USA",
                Address = "18001 Collins Ave, Miami Beach",
                Feeding = true,
                FreeRooms = 32,
                Rooms = 50,
                IsWifi = true,
                Mark = 5,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Trump.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Trump2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Trump3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Miami Seaquarium",
                Description = "You will see a lot of sea inhabitants",
                Duration = 3,
                Language = "English",
                MaxAmountOfVisitors = 30,
                Place = "Miami Seaquarium",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Msea.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion2 = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Jungle Island",
                Description = "Jungle Island provides a great day out for any company or group. Our amazing animals, exciting exhibits and sensational shows make Jungle Island the perfect choice for a company picnic, large group outing or private daytime or evening event",
                Duration = 5,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Jungle Island",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\JIex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages2 = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion2, ExcurtionId = excurtion2.Id }
            );
            excurtion2.Images = excurtionimages2;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            tour.Excurtion.Add(excurtion2);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public void SeedData4()
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Palms and Sun in Hawaii",
                City = "Honolulu",
                Country = "USA",
                Description = "Visiting the most interesting places of the island. Scenic panorama of Honolulu",
                Duration = 5,
                StartDate = new DateTime(2022, 6, 01),
                EndDate = new DateTime(2022, 6, 06),
                MaxTourists = 4,
                TourOperator = "SandAndWater",
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Waikiki Resort Hotel",
                City = "Honolulu",
                Description = "Reputable for its outstanding value and convenience in location, this 275 room hotel is ideally located just steps from famous Waikiki Beach and nearby dining and shopping. ",
                Country = "USA",
                Address = "2460 Koa Avenue, Honolulu, Oahu, HI 96815",
                Feeding = true,
                FreeRooms = 40,
                Rooms = 70,
                IsWifi = true,
                Mark = 4,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Wai.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Wai2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Wai3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Excursion around the island of Oahu.",
                Description = "Scenic panorama of Honolulu from Mount Tantalus; the crater of the Diamond Head volcano; area of ​​luxury houses Kahala. Hanauma Bay is a magnificent beach and a coral reef that stretches inside the crater, a real Halona ocean geyser and the beach From Here to Eternity.",
                Duration = 12,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Around the island of Oahu",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\OHex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion2 = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Excursion to Pearl Harbor",
                Description = "Visit the famous Pearl Harbor - the naval base where the US began the Second World War.",
                Duration = 6,
                Language = "English",
                MaxAmountOfVisitors = 12,
                Place = "Pearl Harbor",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\PHex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages2 = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion2, ExcurtionId = excurtion2.Id }
            );
            excurtion2.Images = excurtionimages2;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            tour.Excurtion.Add(excurtion2);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public void SeedData5()
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "On the land of Alaska",
                City = "Anchorage",
                Country = "USA",
                Description = "Anchorage - the main city of Alaska, commercial, transport and tourist center, where almost half of the total population of the state lives.",
                Duration = 7,
                StartDate = new DateTime(2022, 6, 03),
                EndDate = new DateTime(2022, 6, 10),
                MaxTourists = 8,
                TourOperator = "TravelAroundTheUS",
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Alex Hotel & Suites",
                City = "Anchorage",
                Description = "Alex Hotel & Suites features 123 oversized guest rooms with an excellent location.",
                Country = "USA",
                Address = "4615 Spenard Rd, Anchorage, AK 99517-3235",
                Feeding = false,
                FreeRooms = 15,
                Rooms = 32,
                IsWifi = false,
                Mark = 3,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Alex.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Alex2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Alex3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Anchorage City Tour.",
                Description = "A sightseeing tour introduces the sights and history of Anchorage. A visit to the largest museum in Alaska, which introduces the history and sights of the state.* Overnight in Anchorage.",
                Duration = 5,
                Language = "English",
                MaxAmountOfVisitors = 15,
                Place = "Around the Anchorage",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\ANex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion2 = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Moving to the Denali Reserve region",
                Description = "On the way - beautiful views of mountains, valleys, tundra, lakes. Visit the village of Wassila and the headquarters of the most famous dog sled race in Alaska - Iditarod. Overnight at a hotel in the Denali Wildlife Refuge.",
                Duration = 24,
                Language = "English",
                MaxAmountOfVisitors = 8,
                Place = "Denali",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\DENex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages2 = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion2, ExcurtionId = excurtion2.Id }
            );
            excurtion2.Images = excurtionimages2;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            tour.Excurtion.Add(excurtion2);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
    }
}