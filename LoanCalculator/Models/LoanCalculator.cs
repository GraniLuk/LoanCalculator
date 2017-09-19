using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanCalculator.Data.Models;

namespace LoanCalculator.Models
{
    public class LoanCalculator
    {
        private readonly Loan _loan;

        public LoanCalculator(Loan loan)
        {
            _loan = loan;
        }

        public Schedule GetSchedule()
        {
            return new Schedule();
        }
    }
}