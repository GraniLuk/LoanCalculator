using System.Linq;
using System.Web.Mvc;
using LoanCalculator.Data;
using LoanCalculator.ViewModels;
using System.Data.Entity;

namespace LoanCalculator.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanDb _db;

        public LoanController()
        {
            _db = new LoanDb();
        }

        public ActionResult New()
        {
            var viewModel = new LoanFormViewModel
            {
                LoanTypes = _db.LoanTypes.ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Validate(LoanFormViewModel loanFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LoanFormViewModel
                {
                    LoanTypes = _db.LoanTypes.ToList()
            };

                return View("New",viewModel);
            }

            return RedirectToAction("Get", "Schedule", loanFormViewModel);
        }

        public ActionResult GetDetails(int id)
        {
            var loanType = _db.LoanTypes.Include(x=>x.RateInterval).Include(x=>x.PaymentInterval).FirstOrDefault(x => x.Id == id);

            return PartialView("_loanDetailsPartial", loanType);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

    }
}
