using Microsoft.AspNetCore.Mvc;
using Week9Day4Demo.Models;
using Week9Day4Demo.Services;
using Week9Day4Demo.Services.BankDeposit;

namespace Week9Day4Demo.Controllers
{
    /// <summary>
    /// How to implement your requirement using Dependency Injection
    /// 1. Ensure your Service class has an Interface
    /// 2. Register the interface and class with the asp.net core Service Container
    /// 3. Allow asp.net Service Container to create the instance and send you the reference
    /// </summary>
    public class IciciBankDepositController : Controller
    {
        private const double Interest = 14.5;

        private IBankInterestService _bankInterest;

        public IciciBankDepositController(IBankInterestService bankInterest)
        {
            _bankInterest = bankInterest;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(DepositInfo depositInfo)
        {
            if (!ModelState.IsValid) return View(depositInfo);

            //var simpleInterestService = new IciciSimpleInterestService();

            depositInfo.Interest = _bankInterest.Calculate(depositInfo.Amount, depositInfo.Years, Interest);

            return View(depositInfo);
        }
    }
}
