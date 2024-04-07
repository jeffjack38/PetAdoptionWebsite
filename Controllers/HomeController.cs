using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionWebsite.Controllers
{
    public class HomeController : Controller
    {

        //display home page
        public IActionResult Index()
        {
            return View();
        }
    }
}
