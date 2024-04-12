using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionWebsite.Models;
using System.Threading.Tasks;


namespace PetAdoptionWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.Username,
                        Email = model.Email
                    };

                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred on user registration/login");
                TempData["error"] = "An error occurred during registration.";
                return RedirectToAction("Index"); // Redirect to home page
            }
        }

        [HttpGet]
        public IActionResult Login(string returnURL = "")
        {
            ModelState.Remove("returnURL"); // Explicitly clear ModelState for returnURL
            var model = new LoginViewModel { ReturnURL = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(
                        model.Username, model.Password, isPersistent: model.RememberMe,
                        lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                        {
                            return Redirect(model.ReturnURL);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid username/password.");
                return View(model);
            }
            catch (Exception ex)
            {
                
                TempData["error"] = "An error occurred during login.";
                return RedirectToAction("Index"); // Redirect to the appropriate action
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}
