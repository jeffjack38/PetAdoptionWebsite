using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionWebsite.Models;

namespace PetAdoptionWebsite.Controllers
{
    [Authorize]  // Requires the user to be authenticated
    public class FavoritesController : Controller
    {
        //calls Index() action method when the user clicks on the "Favorites" link
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                // create new PetSession object and post it to the Session property of the HttpContext property
                var session = new PetSession(HttpContext.Session);
                // create new PetListViewModel object to load it with data from session state 
                var model = new PetListViewModel
                {
                    Pets = session.GetMyPets()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                // Log the exception (you can customize this based on your logging strategy)
                TempData["error"] = "An error occurred while loading favorite pets.";
                return RedirectToAction("Index", "Home");
            }
        }

        // called when the user clicks "Clear Favorites" from the Favorites page  // we don't use this, do we want to keep this?
        [HttpPost]
        public RedirectToActionResult Delete()
        {
            try
            {
                // create new PetSession object and pass it the Session property of the controller's HttpContext property
                var session = new PetSession(HttpContext.Session);
                // call RemoveMyPets() method of the CountrySession object
                session.RemoveMyPets();

                // store message in TempData to tell the user the favorite pets cleared, the layout displays this message
                TempData["message"] = "Favorite pets cleared";

                // redirect back to the Home page, get Id values of active cat and game that are stored in session state and build the route parameters of the URL
                return RedirectToAction("Index", "Home", new { Pets = session.GetMyPets() });
            }
            catch (Exception ex)
            {
                // Log the exception (you can customize this based on your logging strategy)
                TempData["error"] = "An error occurred while clearing favorite pets.";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
