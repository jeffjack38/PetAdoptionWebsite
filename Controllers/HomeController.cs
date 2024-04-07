using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetAdoptionWebsite.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;


namespace PetAdoptionWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Display home page
        public IActionResult Index()
        {
            return View();
        }

        // Display about page
        public IActionResult About()
        {
            return View();
        }

        // Display adoption page
        public IActionResult Adoption()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }

        // Error handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Log the error if needed
            _logger.LogError("An error occurred while processing the request");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [TypeFilter(typeof(ErrorHandlingFilter))]
        public class ErrorHandlingFilter : ExceptionFilterAttribute
        {
            private readonly ILogger<HomeController> _logger;

            public ErrorHandlingFilter(ILogger<HomeController> logger)
            {
                _logger = logger;
            }

            public override void OnException(ExceptionContext context)
            {
                // Log the exception
                var exception = context.Exception;
                // Example: Log the exception using a logging framework or to a file
                _logger.LogError(exception, "An unhandled exception occurred");

                // Redirect to an error view or display a generic error message
                context.Result = new ViewResult { ViewName = "Error" };

                // Mark the exception as handled
                context.ExceptionHandled = true;

                base.OnException(context);
            }
        }
    }
}
