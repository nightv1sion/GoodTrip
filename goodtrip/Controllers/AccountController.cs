using goodtrip.Storage;
using goodtrip.Models;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using goodtrip.Storage.Enums;

namespace goodtrip.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;
        private GoodTripContext _dbContext { get; set; }

        public AccountController(GoodTripContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<UserRole> roleManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = context;
            _roleManager = roleManager;
            //SeedData();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            await SeedData();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Login = registerUser.Login , UserName = registerUser.Login, 
                    Password = registerUser.Password, Profile = registerUser.AccountType == "Operator" ? new UserOperatorProfile() : new UserCustomerProfile()};
                user.AccountType = registerUser.AccountType == "Operator" ? AccountType.Operator : AccountType.Customer;
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                await _userManager.AddToRoleAsync(user, registerUser.AccountType);
                if (result.Succeeded)
                {
                    /*var claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, "name"),
                                                   new Claim(ClaimsIdentity.DefaultRoleClaimType, registerUser.AccountType) };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);*/
                    await _signInManager.SignInAsync(user, null);
                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
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
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUser.Login, loginUser.Password, loginUser.RememberMe, false);
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        private async Task SeedData()
        {
            string[] rolenames = { "Admin", "Operator", "Customer" };
            foreach (var rolename in rolenames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(rolename);
                if (!roleExist)
                {
                    var roleResult = await _roleManager.CreateAsync(new UserRole(rolename));
                }
            }
        }
    }
}
