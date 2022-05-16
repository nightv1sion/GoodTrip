using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using goodtrip.Storage.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace goodtrip.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private GoodTripContext _context { get; set; }
        public ProfileController(GoodTripContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string role = User?.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value;
            string name = User?.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            if(role == "Customer")
            {
                return RedirectToAction("CustomerChangeSettings");
            }
            else if(role == "Operator")
            {
                return RedirectToAction("OperatorChangeSettings");
            }
            return NotFound();
        }

        [Authorize(Roles="Customer")]
        [HttpGet]
        public async Task<IActionResult> CustomerChangeDocuments()
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            DocumentsModel profile = new DocumentsModel();
            if (user != null)
            {
                profile.Name = user.Profile.Name;
                profile.LastName = user.Profile.LastName;
                profile.BirthDay = user.Profile.BirthDay;
                profile.Nationality = user.Profile.Nationality.ToString();
                profile.Gender = user.Profile.Gender.ToString().ToLower();
                profile.PassNumber = user.Profile.PassportNumber;
                profile.PassValidityPeriod = user.Profile.PassportValidityPeriod;
            }
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerChangeDocuments(DocumentsModel profile)
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            if(user != null)
            {
                user.Profile.Name = profile.Name;
                user.Profile.LastName = profile.LastName;
                user.Profile.BirthDay = profile.BirthDay;
                user.Profile.Nationality = profile.Nationality == "Russia" ? Nationality.Russia : Nationality.Europe;
                user.Profile.Gender = profile.Gender == "male" ? Gender.Male : Gender.Female;
                user.Profile.PassportNumber = profile.PassNumber;
                user.Profile.PassportValidityPeriod = profile.PassValidityPeriod;
                _context.Update<User>(user);
                await _context.SaveChangesAsync();
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles="Customer")]
        public async Task<IActionResult> CustomerChangeSettings()
        {
            return View();
        }
        [Authorize(Roles="Operator")]
        [HttpGet]
        public async Task<IActionResult> OperatorChangeDocuments()
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            DocumentsModel profile = new DocumentsModel();
            if (user != null)
            {
                profile.Name = user.Profile.Name;
                profile.LastName = user.Profile.LastName;
                profile.BirthDay = user.Profile.BirthDay;
                profile.Nationality = user.Profile.Nationality.ToString();
                profile.Gender = user.Profile.Gender.ToString().ToLower();
                profile.PassNumber = user.Profile.PassportNumber;
                profile.PassValidityPeriod = user.Profile.PassportValidityPeriod;
            }
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> OperatorChangeDocuments(DocumentsModel profile)
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            if (user != null)
            {
                user.Profile.Name = profile.Name;
                user.Profile.LastName = profile.LastName;
                user.Profile.BirthDay = profile.BirthDay;
                user.Profile.Nationality = profile.Nationality == "Russia" ? Nationality.Russia : Nationality.Europe;
                user.Profile.Gender = profile.Gender == "male" ? Gender.Male : Gender.Female;
                user.Profile.PassportNumber = profile.PassNumber;
                user.Profile.PassportValidityPeriod = profile.PassValidityPeriod;
                _context.Update<User>(user);
                await _context.SaveChangesAsync();
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> OperatorChangeSettings()
        {
            return View();
        }
        [Authorize(Roles = "Operator")]
        public IActionResult CreateTour(NewTourModel newtourModel = null)
        {
            return View(newtourModel);
        }
        [Authorize(Roles="Operator")]
        [ActionName("CreateTour")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTourPost(NewTourModel newtourModel)
        {
            if(ModelState.IsValid == false || Request.Form.Files.Count == 0)
            {
                ViewBag.SuperError = "All fields are required";
                return View(newtourModel);
            }
            UserOperatorProfile creator = _context.UserOperatorProfiles.Include(p => p.User).FirstOrDefault(p => p.User.UserName == HttpContext.User.Identity.Name);
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = newtourModel.TourName,
                City = newtourModel.TourCity,
                Country = newtourModel.TourCountry,
                Description = newtourModel.TourDescription,
                Duration = newtourModel.TourDuration,
                StartDate = newtourModel.StartDate,
                EndDate = newtourModel.EndDate,
                MaxTourists = newtourModel.TourMaxTourists,
                Price = newtourModel.TourPrice,
            };
            if(creator != null)
            {
                tour.TourOperatorProfile = creator;
                tour.TourOperatorProfileId = creator.UserProfileId;
            }
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = newtourModel.HotelName,
                City = newtourModel.HotelCity,
                Country = newtourModel.HotelCountry,
                Address = newtourModel.HotelAddress,
                Description = newtourModel.HotelDescription,
                Feeding = newtourModel.HotelFeeding == "yes" ? true : false,
                FreeRooms = newtourModel.HotelFreeRooms,
                Rooms = newtourModel.HotelRooms,
                Mark = newtourModel.HotelMark,
                IsWifi = newtourModel.HotelIsWifi == "yes" ? true : false,
                Tour = tour,
                TourId = tour.Id,
                Images = new List<ImageHotel>()
            };
            foreach (var file in Request.Form.Files)
            {
                ImageHotel img = new ImageHotel();
                img.ImageTitle = file.FileName;
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();
                ms.Close(); ms.Dispose();
                img.Id = Guid.NewGuid();
                img.Hotel = hotel; img.HotelId = hotel.Id;
                hotel.Images.Add(img);
            }
            ImageHotel imghotellast = hotel.Images[hotel.Images.Count - 1];
            ImageExcurtion imgexc = new ImageExcurtion()
            {
                ImageData = imghotellast.ImageData,
                ImageTitle = imghotellast.ImageTitle,
                Id = Guid.NewGuid()
            };
            hotel.Images.RemoveAt(hotel.Images.Count - 1);
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = newtourModel.ExcursionName,
                Description = newtourModel.ExcursionDescription,
                Duration = newtourModel.ExcursionDuration,
                Language = newtourModel.ExcursionLanguage,
                MaxAmountOfVisitors  = newtourModel.ExcursionMaxAmountOfVisitors,
                Place = newtourModel.ExcursionPlace,
                Tour = tour,
                TourId = tour.Id,
                Images = new List<ImageExcurtion>()
            });
            imgexc.Excurtion = tour.Excurtion[0];
            imgexc.ExcurtionId = tour.Excurtion[0].Id;
            tour.Excurtion[0].Images.Add(imgexc);
            _context.Tours.Add(tour);
            _context.SaveChanges();
            return RedirectToAction("PrintTours");

        }

        public IActionResult PrintTours()
        {
            List<Tour> tours = _context.Tours.Include(t => t.TourOperatorProfile).Include(t => t.TourOperatorProfile.User).
                Where(t => t.TourOperatorProfile.User.UserName == HttpContext.User.Identity.Name).ToList();
            return View(tours);
        }
        public IActionResult DeleteTour(string id)
        {
            Guid guid = Guid.Parse(id);
            Tour tourtodelete = _context.Tours.FirstOrDefault(t => t.Id == guid);
            if(tourtodelete != null)
            {
                _context.Tours.Remove(tourtodelete);
            }
            _context.SaveChanges();
            return RedirectToAction("PrintTours");
        }
        public async Task<IActionResult> OperatorChangeBussinessInfo()
        {
            return View();
        }
    }
}
