using goodtrip.Managers;
using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using goodtrip.Storage.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace goodtrip.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IProfileManager _profileManager { get; set; }
        public ProfileController(IProfileManager profileManager)
        {
            _profileManager = profileManager;
        }

        public async Task<IActionResult> Index()
        {
            string role = User?.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value;
            if(role == "Customer")
            {
                return RedirectToAction("CustomerChangeDocuments");
            }
            else if(role == "Operator")
            {
                return RedirectToAction("OperatorChangeDocuments");
            }
            return NotFound();
        }

        [Authorize(Roles="Customer")]
        [HttpGet]
        public async Task<IActionResult> CustomerChangeDocuments()
        {
            string username = HttpContext.User.Identity.Name;
            DocumentsModel profile;
            if (username != null)
            {
                profile = _profileManager.DocumentsInfo(username);
            }
            else
            {
                profile = new DocumentsModel();
            }
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerChangeDocuments(DocumentsModel profile)
        {
            string username = HttpContext.User.Identity.Name;
            await _profileManager.ChangeDocumentsAsync(username, profile);
            return View();
        }
        [Authorize(Roles="Operator")]
        [HttpGet]
        public async Task<IActionResult> OperatorChangeDocuments()
        {
            string username = HttpContext.User.Identity.Name;
            DocumentsModel profile;
            if (username != null)
            {
                profile = _profileManager.DocumentsInfo(username);
            }
            else
            {
                profile = new DocumentsModel();
            }
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> OperatorChangeDocuments(DocumentsModel profile)
        {
            string username = HttpContext.User.Identity.Name;
            await _profileManager.ChangeDocumentsAsync(username, profile);
            return View();
        }
        [Authorize(Roles = "Operator")]
        [HttpGet]
        public IActionResult CreateTour(NewTourModel newtourModel = null)
        {
            return View(newtourModel);
        }

        [Authorize(Roles="Operator")]
        [ActionName("CreateTour")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTourPost(NewTourModel newtourModel)
        {
            if(ModelState.IsValid == false || Request.Form.Files.Count == 0)
            {
                ViewBag.SuperError = "All fields are required";
                return View(newtourModel);
            }
            var files = Request.Form.Files;
            string username = HttpContext.User.Identity.Name;
            if(username != null)
            {
                _profileManager.CreateTour(username, newtourModel, files);
            }
            return RedirectToAction("PrintTours");
        }

        [Authorize(Roles = "Operator")]
        public IActionResult PrintTours()
        {
            string username = HttpContext.User.Identity.Name;
            List<Tour> tours = _profileManager.AllTours(username);
            return View(tours);
        }


        public IActionResult DeleteTour(string id)
        {
            _profileManager.RemoveTour(id);
            return RedirectToAction("PrintTours");
        }


        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> PrintRequests()
        {
            string username = HttpContext.User.Identity.Name;
            List<RequestModel> searchedRequests;
            if (username!= null)
            {
                searchedRequests = _profileManager.AllRequests(username);
            }
            else
            {
                return View();
            }
            return View(searchedRequests);
        }

        [Authorize(Roles = "Operator")]
        [Route("Profile/AcceptRequest/{requestId}")]
        public IActionResult AcceptRequest(string requestId)
        {
            Guid guid = Guid.Parse(requestId);
            _profileManager.AcceptRequest(guid);
            return RedirectToAction("PrintRequests");
        }
        [Authorize(Roles = "Operator")]
        [Route("Profile/RejectRequest/{requestId}")]
        public IActionResult RejectRequest(string requestId)
        {
            Guid guid = Guid.Parse(requestId);
            _profileManager.RejectRequest(guid);
            return RedirectToAction("PrintRequests");
        }

        [Authorize(Roles = "Customer")]
        public IActionResult CustomerRequests()
        {
            string username = HttpContext.User.Identity.Name;
            List<RequestModel> searchedRequests;
            if (username != null)
            {
                searchedRequests = _profileManager.CustomerRequests(username);
            }
            else
            {
                return View();
            }
            return View(searchedRequests);
        }
    }
}
