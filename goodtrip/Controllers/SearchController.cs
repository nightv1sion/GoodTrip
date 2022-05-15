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
            List<TourModel> searchedTours  = new List<TourModel>();
            foreach(var tour in _context.Tours.Include(t => t.Excurtion).ToList())
            {
                foreach(var excurtion in tour.Excurtion)
                {
                    excurtion.Images = _context.ImagesExcurtion.Where(i => i.ExcurtionId == excurtion.Id).ToList<ImageExcurtion>();
                }
                TourModel model = new TourModel()
                {
                    Name = tour.Name,
                    Description = tour.Description,
                    Id = tour.Id,
                    ImageDataUrl = tour.Excurtion[0].Images.Count!=0 ? string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(tour.Excurtion[0]?.Images[0]?.ImageData)) : null
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
