using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanCalculator.Data;
using LoanCalculator.Data.Models;

namespace LoanCalculator.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanDb _db;

        public LoanController()
        {
            _db = new LoanDb();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Loan/Create
        [HttpPost]
        public ActionResult Create(Loan loan)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

    }
}
