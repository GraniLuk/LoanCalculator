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
                Loan = new Loan(),
                LoanType = _db.LoanTypes.ToList()
        };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Validate(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LoanFormViewModel
                {
                    Loan = new Loan(),
                    LoanType = _db.LoanTypes.ToList()
            };

                return View("New",viewModel);
            }

            return RedirectToAction("Calculate", "Calculator", loan);
        }

        // POST: Loan/Create
        //[HttpPost]
        //public ActionResult Create(Loan loan)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

    }
}
