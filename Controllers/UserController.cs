using PetAdoptionWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using Xunit;
using Moq;

namespace PetAdoptionWebsite.Controllers
{
    public class UserController : Controller
    {
        private readonly PetContext _context;
        private readonly UserManager<User> _userManager;

        public UserController(PetContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user != null)
                {
                    return View(user);
                }

                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user != null)
                {
                    return View(user);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(User editedUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    if (user != null)
                    {
                        user.FirstName = editedUser.FirstName;
                        user.LastName = editedUser.LastName;
                        user.UserName = editedUser.UserName;
                        user.Email = editedUser.Email;

                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Profile");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return View(editedUser);
            }
            catch (Exception ex)
            {
                // Log the exception
                return RedirectToAction("Error");
            }
        }

        public IActionResult Favorites(string species = "All")
        {
            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);

                var favorites = _context.Favorites
                    .Include(f => f.Pet)
                    .Where(f => f.UserId == userId)
                    .Select(f => f.Pet)
                    .ToList();

                // Filter favorites by species
                if (species != "All")
                {
                    favorites = favorites.Where(p => p.Species == species).ToList();
                }

                // Initialize PetListViewModel
                var petListViewModel = new PetListViewModel
                {
                    Pets = favorites,
                };

                // Set the 'Species' property after initializing 'petListViewModel'
                petListViewModel.Species = GetDistinctSpecies(favorites);

                return View(petListViewModel);
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Error");
            }
        }

   
        private List<string> GetDistinctSpecies(List<Pet> pets)
        {

            var distinctSpecies = pets.Select(p => p.Species).Distinct().ToList();

            // Insert "All" at the beginning of the list
            distinctSpecies.Insert(0, "All");

            return distinctSpecies;
        }

        // Error action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
