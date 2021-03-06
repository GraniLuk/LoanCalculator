﻿using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Data.Models
{
    public class LoanType
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        public decimal InterestRate { get; set; }
        public int? PaymentIntervalId { get; set; }
        public IntervalType PaymentInterval { get; set; }
        public int? RateIntervalId { get; set; }
        public IntervalType RateInterval { get; set; }
        public DueTime DueTime { get; set; } 
    }
}
