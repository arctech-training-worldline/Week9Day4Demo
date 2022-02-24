using Microsoft.AspNetCore.Mvc;
using Week9Day4Demo.Models;
using Week9Day4Demo.Services;

namespace Week9Day4Demo.Controllers
{
    public class BankDepositController : Controller
    {
        private const double Interest = 14.5;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(DepositInfo depositInfo)
        {
            if (!ModelState.IsValid) return View(depositInfo);

            var simpleInterestService = new SimpleInterestService();

            depositInfo.Interest = simpleInterestService.Calculate(depositInfo.Amount, depositInfo.Years, Interest);

            return View(depositInfo);
        }
    }
}
