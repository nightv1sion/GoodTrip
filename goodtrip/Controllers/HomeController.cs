using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace goodtrip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly GoodTripContext _dbContext;
        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, GoodTripContext dbContext)
        {
            _logger = logger;
            _signInManager = signInManager;
            _dbContext = dbContext;
            
        }

        public IActionResult Index(LoginUser? loginUser = null)
        {
            if(loginUser != null)
            {
                return View(loginUser);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, loginUser.RememberMe, false);
                if (result.Succeeded)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, loginUser.Email) };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    User user = _dbContext.Users.FirstOrDefault(u => u.Email == loginUser.Email);
                    if(user != null)
                    {
                        await _signInManager.SignInAsync(user, null);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect");
                }
            }
            return View("Index", loginUser);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}