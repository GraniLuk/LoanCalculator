using LoanCalculator.Data.Models;

namespace LoanCalculator.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LoanDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LoanDb context)
        {
            context.IntervalTypes.AddOrUpdate(x => x.Id,
                new IntervalType() { Id = 1, PeriodsInYear = 1, Name = "Yearly" },
                new IntervalType() { Id = 2, PeriodsInYear = 12, Name = "Monthly" }
            );

            context.LoanTypes.AddOrUpdate(x => x.Id,
                new LoanType() { DueTime = DueTime.EndOfPeriod, Id = 1, InterestRate = 0.035m, Name = "Housing loan", PaymentIntervalId = 2, RateIntervalId = 1 });
        }
    }
}
