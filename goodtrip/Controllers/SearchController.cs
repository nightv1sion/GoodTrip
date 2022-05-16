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
        public IActionResult Index(SearchModel searchModel)
        {
            List<TourModel> searchedTours = new List<TourModel>();
            List<Tour> tours = _context.Tours.Include(t => t.Hotel).ToList();
            foreach (Tour tour in tours)
            {
                var hotel = tour.Hotel;
                hotel.Images = _context.ImagesHotel.Where(i => i.HotelId == hotel.Id).ToList<ImageHotel>();

                TourModel model = new TourModel()
                {
                    Name = tour.Name,
                    Description = tour.Description,
                    Id = tour.Id,
                    Price = tour.Price,
                    ImageDataUrl = tour.Hotel.Images.Count != 0 ? string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(tour.Hotel?.Images[0]?.ImageData)) : null
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
            List<TourModel> searchedTours = new List<TourModel>();
            List<Tour> tours = _context.Tours.Include(t => t.Hotel).ToList();
            if (searchModel.Place != null)
            {
                tours = tours.Where(t => t.City == searchModel.Place).ToList();
            }
            if (searchModel.DateOfStart != null)
            {
                tours = tours.Where(t => t.StartDate >= searchModel.DateOfStart).ToList();
            }
            if (searchModel.DateOfEnd != null)
            {
                tours = tours.Where(t => t.EndDate >= searchModel.DateOfEnd).ToList();
            }
            if(searchModel.PriceEnd != null)
            {
                tours = tours.Where(t => t.Price <= searchModel.PriceEnd).ToList();

            }
            if (searchModel.PriceStart != null)
            {
                tours = tours.Where(t => t.Price >= searchModel.PriceStart).ToList();

            }
            if (searchModel.Duration != null)
            {
                tours = tours.Where(t => t.Duration == searchModel.Duration).ToList();
            }
            if (searchModel.AmountOfStartOfHotel != null)
            {
                tours = tours.Where(t => (int)t.Hotel.Mark == searchModel.AmountOfStartOfHotel).ToList();
            }
            if (searchModel.IsFeeding != null)
            {
                tours = tours.Where(t => t.Hotel.Feeding == searchModel.IsFeeding).ToList();
            }
            if (searchModel.IsWifi != null)
            {
                tours = tours.Where(t => t.Hotel.IsWifi == searchModel.IsWifi).ToList();
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
                    ImageDataUrl = tour.Hotel.Images.Count != 0 ? string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(tour.Hotel?.Images[0]?.ImageData)) : null
                };
                searchedTours.Add(model);
            }
            searchModel.Tours = searchedTours;
            return View(searchModel);
        }
    }
}
