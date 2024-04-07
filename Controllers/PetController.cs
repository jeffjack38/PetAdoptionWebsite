using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionWebsite.Models;

namespace PetAdoptionWebsite.Controllers
{
    public class PetController : Controller
    {
        private readonly PetContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PetController(PetContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewList()
        {
            var pets = _context.Pets.ToList();
            return View(pets);
        }

        public IActionResult Details(int id)
        {
            try
            {
                var pet = _context.Pets.FirstOrDefault(p => p.Id == id);

                if (pet == null)
                {
                    return RedirectToAction("NotFound");
                }

                return View(pet);
            }
            catch (Exception ex)
            {
                // Log the exception 
                TempData["error"] = "An error occurred while retrieving pet details.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult FilterByType(string species)
        {
            var filteredPets = _context.Pets.Where(p => p.Species == species).ToList();
            return View("ViewList", filteredPets);
        }

        public IActionResult FilterByAge(string ageRange)
        {
            var ageBounds = ageRange.Split('-').Select(int.Parse).ToArray();
            var filteredPets = _context.Pets.Where(p => p.Age >= ageBounds[0] && p.Age <= ageBounds[1]).ToList();
            return View("ViewList", filteredPets);
        }

        public IActionResult Filter(string species, string ageRange)
        {
            IQueryable<Pet> filteredPets = _context.Pets;

            if (!string.IsNullOrEmpty(species))
            {
                filteredPets = filteredPets.Where(p => p.Species == species);
            }

            if (!string.IsNullOrEmpty(ageRange))
            {
                var ageBounds = ageRange.Split('-').Select(int.Parse).ToArray();
                filteredPets = filteredPets.Where(p => p.Age >= ageBounds[0] && p.Age <= ageBounds[1]);
            }

            return View("ViewList", filteredPets.ToList());
        }

        [HttpPost]
        public RedirectToActionResult Add(PetViewModel model)
        {
            try
            {
                int petId = model.Pet.Id;
                model.Pet = _context.Pets.Where(p => p.Id == model.Pet.Id).FirstOrDefault();

                var session = new PetSession(HttpContext.Session);
                var pets = session.GetMyPets();
                pets.Add(model.Pet);
                session.SetPetList(pets);

                TempData["message"] = $"{model.Pet.Name} added to your favorites";

                return RedirectToAction("ViewList", new { Pet = session.GetMyPets() });
            }
            catch (Exception ex)
            {
                // Log the exception 
                TempData["error"] = "An error occurred while adding the pet to favorites.";
                return RedirectToAction("ViewList");
            }
        }

        public IActionResult NotFound()
        {
            return View("NotFound");
        }

        private async Task<string> GetCurrentUserIdAsync()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            return user?.Id;
        }
    }
}
