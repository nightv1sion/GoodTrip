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
        private GoodTripContext _context { get; set; }
        public ProfileController(GoodTripContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string role = User?.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value;
            string name = User?.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            if(role == "Customer")
            {
                return RedirectToAction("CustomerChangeSettings");
            }
            else if(role == "Operator")
            {
                return RedirectToAction("OperatorChangeSettings");
            }
            return NotFound();
        }

        [Authorize(Roles="Customer")]
        [HttpGet]
        public async Task<IActionResult> CustomerChangeDocuments()
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            DocumentsModel profile = new DocumentsModel();
            if (user != null)
            {
                profile.Name = user.Profile.Name;
                profile.LastName = user.Profile.LastName;
                profile.BirthDay = user.Profile.BirthDay;
                profile.Nationality = user.Profile.Nationality.ToString();
                profile.Gender = user.Profile.Gender.ToString().ToLower();
                profile.PassNumber = user.Profile.PassportNumber;
                profile.PassValidityPeriod = user.Profile.PassportValidityPeriod;
            }
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerChangeDocuments(DocumentsModel profile)
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            if(user != null)
            {
                user.Profile.Name = profile.Name;
                user.Profile.LastName = profile.LastName;
                user.Profile.BirthDay = profile.BirthDay;
                user.Profile.Nationality = profile.Nationality == "Russia" ? Nationality.Russia : Nationality.Europe;
                user.Profile.Gender = profile.Gender == "male" ? Gender.Male : Gender.Female;
                user.Profile.PassportNumber = profile.PassNumber;
                user.Profile.PassportValidityPeriod = profile.PassValidityPeriod;
                _context.Update<User>(user);
                await _context.SaveChangesAsync();
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles="Customer")]
        public async Task<IActionResult> CustomerChangeSettings()
        {
            return View();
        }
        [Authorize(Roles="Operator")]
        [HttpGet]
        public async Task<IActionResult> OperatorChangeDocuments()
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            DocumentsModel profile = new DocumentsModel();
            if (user != null)
            {
                profile.Name = user.Profile.Name;
                profile.LastName = user.Profile.LastName;
                profile.BirthDay = user.Profile.BirthDay;
                profile.Nationality = user.Profile.Nationality.ToString();
                profile.Gender = user.Profile.Gender.ToString().ToLower();
                profile.PassNumber = user.Profile.PassportNumber;
                profile.PassValidityPeriod = user.Profile.PassportValidityPeriod;
            }
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> OperatorChangeDocuments(DocumentsModel profile)
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            if (user != null)
            {
                user.Profile.Name = profile.Name;
                user.Profile.LastName = profile.LastName;
                user.Profile.BirthDay = profile.BirthDay;
                user.Profile.Nationality = profile.Nationality == "Russia" ? Nationality.Russia : Nationality.Europe;
                user.Profile.Gender = profile.Gender == "male" ? Gender.Male : Gender.Female;
                user.Profile.PassportNumber = profile.PassNumber;
                user.Profile.PassportValidityPeriod = profile.PassValidityPeriod;
                _context.Update<User>(user);
                await _context.SaveChangesAsync();
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> OperatorChangeSettings()
        {
            return View();
        }

        public IActionResult CreateTour()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTour(Tour obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return View();
        }



        public async Task<IActionResult> OperatorChangeBussinessInfo()
        {
            return View();
        }
    }
}
