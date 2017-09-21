using System.Linq;
using System.Web.Mvc;
using LoanCalculator.Data;
using LoanCalculator.Data.Models;
using LoanCalculator.Models;
using LoanCalculator.Models.Calculator;
using System.Data.Entity;

namespace LoanCalculator.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly LoanDb _db;

        public ScheduleController()
        {
            _db = new LoanDb();
        }

        public ActionResult Get(Loan loan)
        {
            loan.LoanType = _db.LoanTypes.Include(x => x.RateInterval).Include(x => x.PaymentInterval).FirstOrDefault(x => x.Id == loan.LoanTypeId);

            return View(new Schedule(loan, new FixedRateCalculator(loan)));
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}