using goodtrip.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        
        public string Index()
        {
            return "ACCCESSS";
        }
    }
}
