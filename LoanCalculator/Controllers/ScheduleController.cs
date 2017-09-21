using System.Linq;
using System.Web.Mvc;
using LoanCalculator.Data;
using LoanCalculator.Data.Models;
using Schedule = LoanCalculator.Models.Schedule;

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
            loan.LoanType = _db.LoanTypes.FirstOrDefault(x => x.Id == loan.LoanTypeId);

            return View(new Schedule(loan));
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}