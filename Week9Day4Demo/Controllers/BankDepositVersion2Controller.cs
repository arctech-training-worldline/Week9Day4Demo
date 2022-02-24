using Microsoft.AspNetCore.Mvc;
using Week9Day4Demo.Models;
using Week9Day4Demo.Services;
using Week9Day4Demo.Services.BankDeposit;

namespace Week9Day4Demo.Controllers
{
    /// <summary>
    /// This is working fine
    /// However client now wants version 2 of this software
    /// Where the interest should be CompoundInterest
    /// Steps to change
    /// 1. Remove SimpleInterestServiceV2 - OK
    /// 2. Create CompoundInterestService with the logic for CompoundInterest - OK
    /// 3. Change all classes which depend on SimpleInterestService and change it to CompoundInterest - NOT OK
    ///     // NOT OK because, changing the source code in 100 places where all there are dependencies to simple interest
    ///     // will cause bugs to creep in and such code is difficult to maintain.
    /// </summary>
    public class BankDepositVersion2Controller : Controller
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

            var compoundInterestService = new CompoundInterestService();
            depositInfo.Interest = compoundInterestService.Calculate(depositInfo.Amount, depositInfo.Years, Interest);

            return View(depositInfo);
        }
    }
}
