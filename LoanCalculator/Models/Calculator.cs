using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanCalculator.Data.Models;

namespace LoanCalculator.Models
{
    public class Calculator
    {
        private readonly Loan _loan;

        public Calculator(Loan loan)
        {
            _loan = loan;
        }

        public Schedule GetSchedule()
        {

            return new Schedule();
        }


       
    }
}