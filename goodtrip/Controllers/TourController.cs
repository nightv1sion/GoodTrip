using goodtrip.Managers;
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
        private readonly ITourManager _tourManager;
        public TourController(ITourManager tourManager)
        {
            _tourManager = tourManager;
        }

        [Route("Tour/Index/{id:guid}")]
        public IActionResult Index(Guid id)
        {
            Tour tour = _tourManager.FindTour(id);
            ViewBag.HotelPhotos = _tourManager.FindHotelPhotos(tour);
            ViewBag.ExcurtionPhotos = _tourManager.FindExcursionPhotos(tour);
            string username = HttpContext?.User?.Identity?.Name;
            TourInfoModel tourmodel = new TourInfoModel()
            {
                Tour = tour,
                TourId = tour.Id.ToString(),
                CommentName = username != null ? _tourManager.FindCommentName(username) : null
            };

            return View("Index", tourmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(TourInfoModel tourinfoModel)
        {
            if (tourinfoModel.CommentName != null && tourinfoModel.CommentText != null)
            {
                await _tourManager.CommentAsync(tourinfoModel);
            }
            else
            {
                ModelState.AddModelError("comment", "Name and text are required!");
            }
            return Redirect($"Index/{tourinfoModel.TourId.ToString()}");
        }

        [Authorize(Roles = "Customer")]
        [Route("Tour/CreateRequest/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> CreateRequest(Guid id)
        {
            string _id = id.ToString();
            RequestModel requestModel = new RequestModel()
            {
                TourId = _id
            };
            string username = HttpContext.User.Identity.Name;
            UserCustomerProfile profile = null;
            if (username != null)
            {
                profile = await _tourManager.TakeProfileInfoAsync(username);
            }
            if(profile != null)
            {
                requestModel.CustomerName = profile.Name;
                requestModel.CustomerLastName = profile.LastName;
            }
            return View(requestModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(RequestModel requestModel)
        {
            string username = HttpContext?.User?.Identity?.Name;
            Request newRequest = await _tourManager.CreateRequestAsync(requestModel, username);
            
            return Redirect($"/Tour/Index/{newRequest.Tour.Id}");
        }
    }
}