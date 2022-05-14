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
            return View(searchModel);
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost(SearchModel searchModel)
        {
            searchModel.Tours = _context.Tours.Include(tour => tour.DepartureCities).Include(tour => tour.Dates)
                .Where<Tour>(tour => tour.ArrivalCity == searchModel.PlaceTo).ToList<Tour>().Where<Tour>(tour => tour.Nights == searchModel.Nights)
                .Where<Tour>(tour => searchModel.Tourists <= tour.MaxTourists).ToList<Tour>();
            
            foreach(var tour in searchModel.Tours)
            {
                bool removeFlagCity = true;
                bool removeFlagDate = true;

                foreach (var departCities in tour.DepartureCities)
                {
                    if(departCities.City == searchModel.PlaceFrom)
                    {
                        removeFlagCity = false;
                        continue;
                    }
                }
                foreach(var date in tour.Dates)
                {
                    if(date.DateTime.Date == searchModel.When.Date)
                    {
                        removeFlagDate = false;
                    }
                }
                if(removeFlagCity == true || removeFlagDate == true)
                {
                    searchModel.Tours.Remove(tour);
                }
            }
            return View(searchModel);
        }
        private void SeedData()
        {
            List<Tour> tours = new()
            {
                new Tour() { Id = Guid.NewGuid(), DepartureCities = new List<DepartureCity> { new DepartureCity() { Id = Guid.NewGuid(), City = "Moscow" } },
                    ArrivalCity = "Antalya", Dates = new List<Date>() { new Date { Id = Guid.NewGuid(), DateTime = new DateTime(2022, 05, 12) },
                        new Date { Id = Guid.NewGuid(), DateTime = new DateTime(2022, 05, 13) }
                    },
                    MaxTourists = 8,
                    Nights = 10
                },
                new Tour()
                {
                    Id = Guid.NewGuid(),
                    DepartureCities = new List<DepartureCity> { new DepartureCity() { Id = Guid.NewGuid(), City = "Moscow" } },
                    ArrivalCity = "Los-Angeles",
                    Dates = new List<Date>() { new Date { Id = Guid.NewGuid(), DateTime = new DateTime(2022, 05, 14) },
                        new Date { Id = Guid.NewGuid(), DateTime = new DateTime(2022, 05, 15) }
                    },
                    MaxTourists = 8,
                    Nights = 10
                },
                new Tour()
                {
                    Id = Guid.NewGuid(),
                    DepartureCities = new List<DepartureCity> { new DepartureCity() { Id = Guid.NewGuid(), City = "Moscow" } },
                    ArrivalCity = "New-York",
                    Dates = new List<Date>() { new Date { Id = Guid.NewGuid(), DateTime = new DateTime(2022, 05, 16) },
                        new Date { Id = Guid.NewGuid(), DateTime = new DateTime(2022, 05, 17) }
                    },
                    MaxTourists = 8,
                    Nights = 10
                },
            };
            _context.Tours.AddRange(tours);
            _context.SaveChanges();
        }
    }
}
