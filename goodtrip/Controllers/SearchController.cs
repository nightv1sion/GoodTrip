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
  
            return View(searchModel);
        }
    }
}
