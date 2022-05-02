using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<IActionResult> CustomerChange()
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            CustomerProfile profile = new CustomerProfile();
            if (user != null)
            {
                profile.Name = user.Profile.Name;
                profile.LastName = user.Profile.LastName;
                profile.Age = user.Profile.Age;
            }
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerChange(CustomerProfile profile)
        {
            string username = HttpContext.User.Identity.Name;
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.Email == username) : null;
            if(user != null)
            {
                user.Profile.Name = profile.Name;
                user.Profile.LastName = profile.LastName;
                user.Profile.Age = profile.Age;
                _context.Update<User>(user);
                await _context.SaveChangesAsync();
            }
            return View();
        }
    }
}
