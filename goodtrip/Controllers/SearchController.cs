using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Controllers
{
    public class SearchController : Controller
    {
        private readonly GoodTripContext _context;
        public SearchController(GoodTripContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(string? city, DateTime? startdate, DateTime? enddate)
        {
            SearchModel searchModel = new SearchModel();
            
            List<TourModel> searchedTours  = new List<TourModel>();
            List<Tour> tours = _context.Tours.Include(t => t.Hotel).ToList();
            if (city != null)
            {
                tours = tours.Where(t => t.City == city).ToList();
            }
            if(startdate != null)
            {
                tours = tours.Where(t => t.StartDate >= startdate).ToList();
            }
            if(enddate != null)
            {
                tours = tours.Where(t => t.EndDate >= enddate).ToList();
            }
            foreach (var tour in tours)
            {
                var hotel = tour.Hotel;
                    hotel.Images = _context.ImagesHotel.Where(i => i.HotelId == hotel.Id).ToList<ImageHotel>();

                TourModel model = new TourModel()
                {
                    Name = tour.Name,
                    Description = tour.Description,
                    Id = tour.Id,
                    Price = tour.Price,
                    ImageDataUrl = tour.Hotel.Images.Count!=0 ? string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(tour.Hotel?.Images[0]?.ImageData)) : null
                };
                searchedTours.Add(model);
            }
            searchModel.Tours = searchedTours;
            return View(searchModel);
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost(SearchModel searchModel)
        {
            return View(searchModel);
        }
    }
}
