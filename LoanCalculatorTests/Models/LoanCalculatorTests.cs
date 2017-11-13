using System.Collections.Generic;
using System.Linq;
using LoanCalculator.Data.Models;
using LoanCalculator.Models;
using LoanCalculator.Models.Calculator;
using NUnit.Framework;

namespace LoanCalculator.Tests.Models
{
    [TestFixture()]
    public class LoanCalculatorTests
    {
        private List<Installment> _expectedSchedule;
        private Loan _loanToTest;

        [SetUp]
        public void SetUp()
        {
            _expectedSchedule = new List<Installment>()
            {
                new Installment() { Number = 1, Capital = 3233.81m, Interest = 210m},
                new Installment() { Number = 2, Capital = 3242.3m, Interest = 201.51m},
                new Installment() { Number = 3, Capital = 3250.81m, Interest = 193m},
                new Installment() { Number = 4, Capital = 3259.34m, Interest = 184.47m},
                new Installment() { Number = 5, Capital = 3267.9m, Interest = 175.91m},
                new Installment() { Number = 6, Capital = 3276.48m, Interest = 167.33m},
                new Installment() { Number = 7, Capital = 3285.08m, Interest = 158.73m},
                new Installment() { Number = 8, Capital = 3293.7m, Interest = 150.11m},
                new Installment() { Number = 9, Capital = 3302.35m, Interest = 141.46m},
                new Installment() { Number = 10, Capital = 3311.02m, Interest = 132.79m},
                new Installment() { Number = 11, Capital = 3319.71m, Interest = 124.1m},
                new Installment() { Number = 12, Capital = 3328.42m, Interest = 115.39m},
                new Installment() { Number = 13, Capital = 3337.16m, Interest = 106.65m},
                new Installment() { Number = 14, Capital = 3345.92m, Interest = 97.89m},
                new Installment() { Number = 15, Capital = 3354.7m, Interest = 89.11m},
                new Installment() { Number = 16, Capital = 3363.51m, Interest = 80.3m},
                new Installment() { Number = 17, Capital = 3372.34m, Interest = 71.47m},
                new Installment() { Number = 18, Capital = 3381.19m, Interest = 62.62m},
                new Installment() { Number = 19, Capital = 3390.06m, Interest = 53.75m},
                new Installment() { Number = 20, Capital = 3398.96m, Interest = 44.85m},
                new Installment() { Number = 21, Capital = 3407.89m, Interest = 35.92m},
                new Installment() { Number = 22, Capital = 3416.83m, Interest = 26.98m},
                new Installment() { Number = 23, Capital = 3425.8m, Interest = 18.01m},
                new Installment() { Number = 24, Capital = 3434.79m, Interest = 9.02m}
            };
            _loanToTest = new Loan()
            {
                Amount = 80000,
                NumberOfInstallments = 24,
                LoanType = new LoanType()
                {
                    Id = 1,
                    InterestRate = 0.0315m,
                    RateInterval = new IntervalType() { PeriodsInYear = 1 },
                    PaymentInterval = new IntervalType() { PeriodsInYear = 12 },
                    Name = "HousingLoan"
                }
            };
        }
        [Test()]
        public void CheckCapital()
        {
            //Arrange
            var fixedRateCalculator = new FixedRateCalculator(_loanToTest);
            //Assert
            for (int i = 1; i <= _expectedSchedule.Count(); i++)
            {
                Assert.AreEqual(_expectedSchedule[i-1].Capital, fixedRateCalculator.GetCapital(i));
            }
        }

        [Test()]
        public void CheckInterest()
        {
            //Arrange
            var fixedRateCalculator = new FixedRateCalculator(_loanToTest);
            //Assert
            for (int i = 1; i <= _expectedSchedule.Count(); i++)
            {
                Assert.AreEqual(_expectedSchedule[i-1].Interest, fixedRateCalculator.GetInterest(i));
            }
        }
    }
}