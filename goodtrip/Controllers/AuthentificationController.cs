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
            if(_dbContext.Users.ToList<User>().Find(u => u.LoginName == user.LoginName) != null)
            {
                if (_dbContext.Users.ToList<User>().Find(u => u.Password == user.Password) != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return NotFound();
        }
    }
}
