using goodtrip.Storage;
using goodtrip.Models;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace goodtrip.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private GoodTripContext _dbContext { get; set; }

        public AccountController(GoodTripContext context, UserManager<User> userManager, SignInManager<User> signInManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = context;
        }
        [HttpPost]
        public IActionResult Check(User user)
        {
            User finded_user = _dbContext.Users.ToList<User>().Find(u => u.Email == user.Email);
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
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Email = registerUser.Email, UserName = registerUser.Email, Password = registerUser.Password };
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (result.Succeeded)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, registerUser.Email) };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    await _signInManager.SignInAsync(user, null);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                }
            }
            
            return View("Register", registerUser);
        }
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new LoginUser { ReturnUrl = returnUrl });
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
                    if (!string.IsNullOrEmpty(loginUser.ReturnUrl) && Url.IsLocalUrl(loginUser.ReturnUrl))
                    {
                        return Redirect(loginUser.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect");
                }
            }
            return View(loginUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
