using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //display home page
        public IActionResult Index()
        {
            return View();
        }
    }
}
