using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Controllers
{
    public class TourController : Controller
    {
        private readonly GoodTripContext _context;
        public TourController(GoodTripContext context)
        {
            _context = context;
        }
        [Route("Tour/Index/{id}")]
        public IActionResult Index(string id)
        {
            Guid guid = new Guid(id);
            Tour tour = _context.Tours.Include(t => t.Excurtion).Include(t => t.Hotel).Include(t => t.Review).ToList<Tour>().FirstOrDefault(t => t.Id == guid);
            if(tour != null)
            {
                tour.Hotel.Images = _context.ImagesHotel.Where(i => i.HotelId == tour.Hotel.Id).ToList();
                foreach(var excurtion in tour.Excurtion)
                {
                    excurtion.Images = _context.ImagesExcurtion.Where(i => i.ExcurtionId == excurtion.Id).ToList();
                }
            }
            else
            {
                return NotFound();
            }
            tour.Review = tour.Review.OrderByDescending(r => r.Created).ToList<Review>();
            List<string> hotelPhotos = new List<string>();
            foreach(var photo in tour.Hotel.Images)
            {
                hotelPhotos.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(photo.ImageData)));
            }
            ViewBag.HotelPhotos = hotelPhotos;
            List<string> excurtionPhotos = new List<string>();
            foreach(var excurtion in tour.Excurtion)
            {
                if(excurtion.Images.Count != 0)
        {
                    excurtionPhotos.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(excurtion.Images[0]?.ImageData)));
                }
            }
            ViewBag.ExcurtionPhotos = excurtionPhotos;
            TourInfoModel tourmodel = new TourInfoModel()
            {
                Tour = tour,
                TourId = tour.Id.ToString(),
                CommentName = HttpContext?.User?.Identity?.Name != null ? _context.Users.Include(u => u.Profile).FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name)?.Profile?.Name : null
            };

            return View("Index", tourmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Comment(TourInfoModel tourinfoModel)
        {
            if (tourinfoModel.CommentName != null && tourinfoModel.CommentText != null)
            {
                Tour tour = await _context.Tours.FirstOrDefaultAsync(t => t.Id == Guid.Parse(tourinfoModel.TourId));
                if(tour != null)
                {
                    Review review = new Review()
                    {
                        Id = Guid.NewGuid(),
                        Tour = tour,
                        TourId = tour.Id,
                        Created = DateTime.Now,
                        Text = tourinfoModel.CommentText,
                        Username = tourinfoModel.CommentName
                    };
                    await _context.Reviews.AddAsync(review);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                ModelState.AddModelError("comment","Name and text are required!");
            }
            return Redirect($"Index/{tourinfoModel.TourId.ToString()}");
        }
        [Authorize(Roles="Customer")]
        [Route("Tour/CreateRequest/{id}")]
        [HttpGet]
        public IActionResult CreateRequest(string id)
        {
            RequestModel requestModel = new RequestModel()
            {
                TourId = id
            };
            return View(requestModel);
        }
        [HttpPost]
        public IActionResult CreateRequest(RequestModel requestModel)
        {
            Request newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                CustomerName = requestModel.CustomerName,
                CustomerLastName = requestModel.CustomerLastName,
                PhoneNumber = requestModel.PhoneNumber,
            };
            Tour choosedTour = _context.Tours.FirstOrDefault(t => t.Id == Guid.Parse(requestModel.TourId));
            newRequest.Tour = choosedTour;
            newRequest.TourId = choosedTour.Id;

            UserCustomerProfile customer = _context.UserCustomerProfiles.Include(p => p.User).FirstOrDefault(p => p.User.UserName == HttpContext.User.Identity.Name);
            //newRequest.CustomerProfile = customer;
            newRequest.CustomerProfileId = customer.UserProfileId;

            //newRequest.OperatorProfile = choosedTour.TourOperatorProfile;
            newRequest.OperatorProfileId = choosedTour.TourOperatorProfileId;
            newRequest.Created = DateTime.Now;

            _context.Requests.Add(newRequest);
            _context.SaveChanges();
            return Redirect($"/Tour/Index/{newRequest.Tour.Id}");
        }
    }
}
