using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LoanCalculator.Data.Models;

namespace LoanCalculator.ViewModels
{
    public class LoanFormViewModel
    {
        public IEnumerable<LoanType> LoanTypes { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int NumberOfInstallments { get; set; }
        [Display(Name = "LoanType")]
        [Required]
        public int LoanTypeId { get; set; }

        //public LoanFormViewModel()
        //{
        //    LoanTypeId = 1;
        //}
    }
}