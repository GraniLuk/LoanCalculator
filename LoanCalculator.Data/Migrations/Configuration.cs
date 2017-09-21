using LoanCalculator.Data.Models;

namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LoanCalculator.Data.LoanDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LoanDb context)
        {
            context.IntervalTypes.AddOrUpdate(x => x.Id,
                new IntervalType() { Id = 1, Months = 12, Name = "Yearly" },
                new IntervalType() { Id = 1, Months = 1, Name = "Monthly" }
                );

            context.LoanTypes.AddOrUpdate(x => x.Id,
                new LoanType() { DueTime = DueTime.EndOfPeriod, Id = 1, InterestRate = 0.035m, Name = "Housing loan", PaymentIntervalId = 2, RateIntervalId = 1 });
        }
    }
}
