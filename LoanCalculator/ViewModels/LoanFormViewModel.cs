using System.Collections.Generic;
using LoanCalculator.Data.Models;

namespace LoanCalculator.ViewModels
{
    public class LoanFormViewModel
    {
        public Loan Loan { get; set; }
        public IEnumerable<LoanType> LoanType { get; set; }
    }
}