using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Mvc;

namespace goodtrip.Controllers
{
    public class AuthentificationController : Controller
    {
        private GoodTripContext _dbContext { get; set; }

        public AuthentificationController(GoodTripContext context)
        {
            _dbContext = context;
        }
        [HttpPost]
        public IActionResult Check(User user)
        {
            User finded_user = _dbContext.Users.ToList<User>().Find(u => u.LoginName == user.LoginName);
            if (ModelState.IsValid != true)     
            {
                return View("Home/Index", user);
            }
            if(finded_user != null)
            {
                if(finded_user.Password == user.Password)
                {
                    // action
                }
                else
                {
                    ModelState.AddModelError("Authentification", "Login or password is wrong!");
                    return View("/../../Home/Index/", user);
                }
            }
            return RedirectToAction("Index", "Home", null);
        }
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(user);
            }
        }
    }
}
