namespace LoanCalculator.Models
{
    public class Installment
    {
        public int Number { get; set; }
        public decimal Capital { get; set; }
        public decimal Interest { get; set; }
        public decimal Total => Capital + Interest;
    }
}