using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionWebsite.Controllers
{
    public class SecureController : Controller
    {
        public SecureController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Anom()
        {
            try
            {
                //action logic here
                return View();
            }
            catch (Exception ex)
            {
                // Log the exception 
                TempData["error"] = "An error occurred while processing the request.";
                return RedirectToAction("Index"); // Redirect to index
            }
        }
    }
}
