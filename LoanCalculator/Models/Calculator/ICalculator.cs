namespace LoanCalculator.Models.Calculator
{
    public interface ICalculator
    {
        decimal GetInterest(int numberOfInstallment, decimal futureValue = 0);
        decimal GetCapital(int numberOfInstallment, decimal futureValue = 0);
    }
}