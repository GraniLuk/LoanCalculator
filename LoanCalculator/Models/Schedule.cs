using System.Collections.Generic;
using System.Linq;
using LoanCalculator.Data.Models;
using LoanCalculator.Models.Calculator;

namespace LoanCalculator.Models
{
    public class Schedule
    {
        public Schedule(Loan loan, ICalculator calculator)
        {
            Installments = new List<Installment>();
            for (var i = 1; i <= loan.NumberOfInstallments; i++)
            {
                Installments.Add(new Installment(){Capital = calculator.GetCapital(i), Interest = calculator.GetInterest(i),Number = i});
            }
            TotalInterest = Installments.Sum(x => x.Interest);
            TotalCapital = Installments.Sum(x => x.Capital);
            TotalAmount = Installments.Sum(x => x.Total);

        }
        public List<Installment> Installments { get; set; }

        public decimal TotalInterest { get; set; }
        public decimal TotalCapital { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
