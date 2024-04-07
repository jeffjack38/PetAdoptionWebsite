using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionWebsite.Models;
using System.Diagnostics;

namespace PetAdoptionWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly PetContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(PetContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // ManagePet Action
        public IActionResult ManagePet()
        {
            try
            {
                var pets = _context.Pets.ToList();
                return View(pets);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Redirect to an error view
                return RedirectToAction("Error");
            }
        }

        // EditPet Action
        [HttpGet]
        public IActionResult EditPet(int petId)
        {
            try
            {
                var pet = _context.Pets.Find(petId);
                if (pet == null)
                {
                    // Handle the case where pet is not found
                    return NotFound();
                }

                return View(pet);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Redirect to an error view 
                return RedirectToAction("Error");
            }
        }

        // DeletePet Action
        public IActionResult DeletePet(int petId)
        {
            try
            {
                var pet = _context.Pets.Find(petId);

                if (pet != null)
                {
                    _context.Pets.Remove(pet);
                    _context.SaveChanges();
                }

                return RedirectToAction("ManagePet");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Redirect to an error view
                return RedirectToAction("Error");
            }
        }

        // MarkAsAdopted Action
        public IActionResult MarkAsAdopted(int petId)
        {
            try
            {
                var pet = _context.Pets.Find(petId);

                if (pet != null)
                {
                    pet.IsAdopted = true;
                    _context.SaveChanges();
                }

                return RedirectToAction("ManagePet");
            }
            catch (Exception ex)
            {
                // Log the exception 
                // Redirect to an error view 
                return RedirectToAction("Error");
            }
        }

        // ManageUsers Action
        public IActionResult ManageUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                return View(users);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Redirect to an error view 
                return RedirectToAction("Error");
            }
        }

        // ViewUserProfile Action
        public IActionResult ViewUserProfile(string userId)
        {
            try
            {
                var userProfile = _context.Users.Find(userId);

                if (userProfile != null)
                {
                    return View(userProfile);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                // Log the exception 
                // Redirect to an error view 
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public IActionResult EditUser(string userId)
        {
            try
            {
                var user = _context.Users.Find(userId);

                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            catch (Exception ex)
            {
                // Log the exception 
                // Redirect to an error view 
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public IActionResult EditUser(User updatedUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(updatedUser);
                }

                var userProfile = _context.Users.Find(updatedUser.Id);

                if (userProfile != null)
                {
                    userProfile.UserName = updatedUser.UserName;
                    _context.SaveChanges();
                }

                return RedirectToAction("ManageUsers", new { userId = updatedUser.Id });
            }
            catch (Exception ex)
            {
                // Log the exception 
                // Redirect to an error view 
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteUser(string userId)
        {
            try
            {
                var user = _context.Users.Find(userId);

                if (user == null)
                {
                    return NotFound();
                }

                _context.Users.Remove(user);
                _context.SaveChanges();

                return RedirectToAction("ManageUsers");
            }
            catch (Exception ex)
            {
                // Log the exception 
                // Redirect to an error view 
                return RedirectToAction("Error");
            }
        }

        // Error action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Log the error if neede
            // Display a custom error view with the error details
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
