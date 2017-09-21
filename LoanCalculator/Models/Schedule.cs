using System.Collections.Generic;
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
        }
        public List<Installment> Installments { get; set; }
       
    }
}
