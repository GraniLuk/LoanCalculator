using System;
using LoanCalculator.Data.Models;

namespace LoanCalculator.Models.Calculator
{
    public class FixedRateCalculator : ICalculator
    {
        private readonly decimal _interestRatePerPeriod;
        private readonly decimal _amountToRepay;
        private readonly int _totalNumberOfInstallments;
        private readonly DueTime _dueTime;
        private readonly decimal _totalRateAmount;
        public FixedRateCalculator(Loan loan)
        {
            var partOfRateIntervalInOnePaymentInterval =
                (decimal)loan.LoanType.RateInterval.PeriodsInYear / loan.LoanType.PaymentInterval.PeriodsInYear;
            _interestRatePerPeriod = loan.LoanType.InterestRate * partOfRateIntervalInOnePaymentInterval;
            _amountToRepay = -(loan.Amount);
            _totalNumberOfInstallments = loan.NumberOfInstallments;
            _dueTime = loan.LoanType.DueTime;
            _totalRateAmount = CalculateTotalRateAmount();
        }

        public decimal GetInterest(int numberOfInstallment, decimal futureValue = 0)
        {
            var presentValue = _amountToRepay;
            var numberOfFirstMonthWithRepayment = _dueTime != DueTime.EndOfPeriod ? 2 : 1;
            if ((numberOfInstallment <= 0) || (numberOfInstallment >= (_totalNumberOfInstallments + 1)))
            {
                throw new ArgumentException("Number of installment is not a valid value.");
            }
            if ((_dueTime != DueTime.EndOfPeriod) && (numberOfInstallment == 1))
            {
                return 0;
            }
            if (_dueTime != DueTime.EndOfPeriod)
            {
                presentValue += _totalRateAmount;
            }
            return decimal.Round((InternalValue(numberOfInstallment - numberOfFirstMonthWithRepayment, presentValue) *
                                  _interestRatePerPeriod),2,MidpointRounding.AwayFromZero);
        }

        public decimal GetCapital(int numberOfInstallment, decimal futureValue = 0)
        {
            if ((numberOfInstallment <= 0) || (numberOfInstallment >= (_totalNumberOfInstallments + 1)))
            {
                throw new ArgumentException("Number of installment is not valid.");
            }
            return decimal.Round(_totalRateAmount - GetInterest(numberOfInstallment), 2,MidpointRounding.AwayFromZero);
        }

        private decimal InternalValue(decimal numberOfInstallment, decimal presentValue)
        {

            if (_interestRatePerPeriod == 0)
            {
                return (-presentValue - (_totalRateAmount * numberOfInstallment));
            }
            return -presentValue * GetCumulatedInterestRate(numberOfInstallment) - _totalRateAmount / _interestRatePerPeriod * GetFixedInterestRate() * (GetCumulatedInterestRate(numberOfInstallment) - 1);
        }

        private decimal GetFixedInterestRate()
        {
            return _dueTime == DueTime.EndOfPeriod ? 1 : 1 + _interestRatePerPeriod;
        }

        private decimal GetCumulatedInterestRate(decimal numberOfInstallment)
        {
            return (decimal)Math.Pow((double)(1 + _interestRatePerPeriod), (double)numberOfInstallment);
        }

        private decimal CalculateTotalRateAmount(decimal futureValue = 0)
        {
            if (_totalNumberOfInstallments == 0)
            {
                throw new ArgumentException("Argument numberOfInstallment is not a valid value.");
            }
            if (_interestRatePerPeriod == 0)
            {
                return ((-futureValue - _amountToRepay) / _totalNumberOfInstallments);
            }
            var interestRateCumulated = (decimal)Math.Pow((double)_interestRatePerPeriod + 1, _totalNumberOfInstallments);
            return (-futureValue - _amountToRepay * interestRateCumulated) / (GetFixedInterestRate() * (interestRateCumulated - 1)) * _interestRatePerPeriod;
        }

    }
}