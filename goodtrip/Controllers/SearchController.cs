using goodtrip.Managers;
using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchManager _searchManager;
        public SearchController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        [HttpGet]
        [Route("Search/Index/{city}")]
        public IActionResult Index(string city)
        {
            SearchModel searchModel = new SearchModel()
            {
                Place = city
            };
            return IndexPost(searchModel);
        }

        [HttpGet]
        public IActionResult Index(SearchModel searchModel)
        {
            searchModel.Tours = _searchManager.AllTours();
            return View(searchModel);
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost(SearchModel searchModel)
        {
            searchModel.Tours = _searchManager.Filter(searchModel);
            return View(searchModel);
        }
    }
}
