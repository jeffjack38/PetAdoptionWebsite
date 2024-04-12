using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionWebsite.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;


namespace PetAdoptionWebsite.Controllers
{
    public class AdminController : Controller
    {
        private readonly PetContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;

        public AdminController(PetContext context, UserManager<User> userManager, ILogger<AccountController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // add pet
        [HttpGet]
        public IActionResult AddPet()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPet(AddPetViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPet = new Pet
                    {
                        Name = model.Name,
                        Species = model.Species,
                        Age = model.Age,
                        BondedBuddyStatus = model.BondedBuddyStatus,
                        Description = model.Description,
                        SpecialCareInstructions = model.SpecialCareInstructions
                    };

                    _context.Pets.Add(newPet);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("ManagePets");
                }
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var error in errors)
                    {
                        _logger.LogError($"Validation error: {error.ErrorMessage}");
                    }

                }
                    // If model state is not valid, return the view with the current model to display validation errors
                    return View(model);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new pet.");
                return RedirectToAction("Error");
            }
        }

        // ManagePet Action
        public IActionResult ManagePets()
        {
            try
            {
                var pets = _context.Pets.ToList();
                return View(pets);
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Error");
            }
        }

        // EditPet Action
        [HttpGet]
        public IActionResult EditPet(int Id)
        {
            try
            {
                var pet = _context.Pets.Find(Id);
                if (pet == null)
                {
                    // Handle the case where pet is not found
                    return NotFound();
                }

                return View(pet);
            }
            catch (Exception ex)
            {
                 
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditPet(Pet editedPet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Retrieve the existing pet from the database using its ID
                    var existingPet = _context.Pets.Find(editedPet.Id);

                    if (existingPet == null)
                    {
                        // Handle the case where pet is not found
                        return NotFound();
                    }

                    // Update the properties of the existing pet
                    existingPet.Name = editedPet.Name;
                    existingPet.Species = editedPet.Species;
                    existingPet.Age = editedPet.Age;
                    existingPet.BondedBuddyStatus = editedPet.BondedBuddyStatus;
                    existingPet.Description = editedPet.Description;
                    existingPet.SpecialCareInstructions = editedPet.SpecialCareInstructions;

                    // Save the changes to the database
                    _context.Pets.Update(existingPet);
                    await _context.SaveChangesAsync();

                    // Redirect to the appropriate action (e.g., Pet details)
                    return RedirectToAction("Details", "Pet", new { id = existingPet.Id });
                }

                // If model state is not valid, return the view with validation errors
                return View(editedPet);
            }
            catch (Exception ex)
            {
                // Log the exception
                return RedirectToAction("Error");
            }
        }




        // DeletePet Action
        public IActionResult DeletePet(int Id)
        {
            try
            {
                var pet = _context.Pets.Find(Id);

                if (pet != null)
                {
                    _context.Pets.Remove(pet);
                    _context.SaveChanges();
                }

                return RedirectToAction("ManagePets");
            }
            catch (Exception ex)
            {
                
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
                
                return RedirectToAction("Error");
            }
        }

        // ViewUserProfile Action
        public IActionResult ViewUserProfile(string Id)
        {
            try
            {
                var userProfile = _context.Users.Find(Id);

                if (userProfile != null)
                {
                    return View(userProfile);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public IActionResult EditUser(string Id)
        {
            try
            {
                var user = _context.Users.Find(Id);

                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            catch (Exception ex)
            {
                
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
                    userProfile.FirstName = updatedUser.FirstName;
                    userProfile.LastName = updatedUser.LastName;
                    _context.SaveChanges();
                   
                    return RedirectToAction("ManageUsers", new { userId = updatedUser.Id });
                }
                else
                {
                    ModelState.AddModelError("", "User not found.");
                    return View(updatedUser);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing the user.");
                TempData["error"] = "An error occurred while processing your request. Please try again.";

                return RedirectToAction("Error");
            }
        }


        // DeleteUser Action
        public IActionResult DeleteUser(string Id)
        {
            try
            {
                var user = _context.Users.Find(Id);

                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }

                return RedirectToAction("ManageUsers");
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Error");
            }
        }

        // Error action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
