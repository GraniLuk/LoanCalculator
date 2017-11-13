using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Data.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int NumberOfInstallments { get; set; }
        [Required]
        public LoanType LoanType { get; set; }
        [Display(Name = "LoanType")]
        [Required]
        public int LoanTypeId { get; set; }
    }
}
