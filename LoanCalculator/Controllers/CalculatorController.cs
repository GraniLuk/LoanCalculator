using System.Web.Mvc;
using LoanCalculator.Data.Models;

namespace LoanCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Calculate(Loan loan)
        {
            var loanCalucator = new Models.Calculator(loan);
            var schedule = loanCalucator.GetSchedule();
            return RedirectToAction("Get", "Schedule", schedule);
        }
    }
}