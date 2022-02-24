using Microsoft.AspNetCore.Mvc;
using Week9Day4Demo.Models;
using Week9Day4Demo.Services;

namespace Week9Day4Demo.Controllers
{
    public class MovieTheaterController : Controller
    {
        private readonly IMovieSecurityGuardService _securityGuardService;

        public MovieTheaterController(IMovieSecurityGuardService securityGuardService)
        {
            _securityGuardService = securityGuardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MovieVisitor movieVisitor)
        {
            if (_securityGuardService.IsVisitorAllowed(movieVisitor.Age))
                movieVisitor.IsAllowed = true;

            return View(movieVisitor);
        }
    }
}
