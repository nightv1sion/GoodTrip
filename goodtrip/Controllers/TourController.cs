using goodtrip.Storage;
using goodtrip.Storage.Entity;
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
        [Route("Tour/{id}")]
        public IActionResult Index(string id)
        {
            Guid guid = new Guid(id);
            Tour tour = _context.Tours.Include(t => t.Excurtion).Include(t => t.Hotel).ToList<Tour>().FirstOrDefault(t => t.Id == guid);
            if(tour != null)
            {
                tour.Hotel.Images = _context.ImageHotel.Where(i => i.HotelId == tour.Hotel.Id).ToList();
                foreach(var excurtion in tour.Excurtion)
                {
                    excurtion.Images = _context.ImageExcurtion.Where(i => i.ExcurtionId == excurtion.Id).ToList();
                }
            }
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
            return View(tour);
        }
    }
}
