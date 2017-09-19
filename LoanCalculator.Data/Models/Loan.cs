using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Data.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int PaybackTimeInYears { get; set; }
        public LoanType LoanType { get; set; }
    }
}
