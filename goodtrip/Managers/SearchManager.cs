using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Managers
{
    public class SearchManager : ISearchManager
    {
        private readonly GoodTripContext _context;
        public SearchManager(GoodTripContext context)
        {
            _context = context;
        }
        public List<TourModel> AllTours()
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
            return searchedTours;
        }
        public List<TourModel> Filter(SearchModel searchModel)
        {
            List<TourModel> searchedTours = new List<TourModel>();
            List<Tour> tours = _context.Tours.Include(t => t.Hotel).ToList();
            
            if (searchModel.Place != null)
            {
                tours = tours.Where(t => t.City.ToLower() == searchModel.Place.ToLower()).ToList();
            }
            if (searchModel.DateOfStart != null)
            {
                tours = tours.Where(t => t.StartDate >= searchModel.DateOfStart).ToList();
            }
            if (searchModel.DateOfEnd != null)
            {
                tours = tours.Where(t => t.StartDate <= searchModel.DateOfEnd).ToList();
            }
            if (searchModel.PriceEnd != null)
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
            if(searchModel.Country != null)
            {
                tours = tours.Where(t => t.Country.ToLower() == searchModel.Country.ToLower()).ToList();
            }
            if(searchModel.ExcursionLanguage != null)
            {
                foreach(var tour in tours)
                {
                    tour.Excurtion = _context.Excurtions.Where(e => e.TourId == tour.Id).ToList();
                }
                tours = tours.Where(t => t.Excurtion[0].Language.ToLower() == searchModel.ExcursionLanguage.ToLower()).ToList();
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
            return searchedTours;
        }
    }
}
