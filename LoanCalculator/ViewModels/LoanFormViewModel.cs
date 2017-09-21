using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LoanCalculator.Data.Models;

namespace LoanCalculator.ViewModels
{
    public class LoanFormViewModel
    {
        public IEnumerable<LoanType> LoanTypes { get; set; }
        [Display(Name = "Total amount:")]
        [Required]
        public int Amount { get; set; }
        [Display(Name = "Number of installments:")]
        [Required]
        public int NumberOfInstallments { get; set; }
        [Display(Name = "Loan type:")]
        [Required]
        public int LoanTypeId { get; set; }
    }
}