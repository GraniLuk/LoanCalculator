using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanCalculator.Data;
using LoanCalculator.Data.Models;
using LoanCalculator.ViewModels;

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

            var loan = new Loan()
            {
                Amount = loanFormViewModel.Amount,
                NumberOfInstallments = loanFormViewModel.NumberOfInstallments,
                LoanTypeId = loanFormViewModel.LoanTypeId
            };

            return RedirectToAction("Get", "Schedule", loan);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

    }
}
