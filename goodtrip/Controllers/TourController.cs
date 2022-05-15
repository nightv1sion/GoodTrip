using Microsoft.AspNetCore.Mvc;

namespace goodtrip.Controllers
{
    public class TourController : Controller
    {
        [Route("{id}")]
        public IActionResult Index(Guid id)
        {
            return View();
        }
    }
}
