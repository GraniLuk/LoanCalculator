namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateValuesInLoanType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.LoanTypes SET InterestRate = 0.0315,RateIntervalPeriodInMonths = 1,PaymentIntervalPeriodInMonths = 12, DueTime = 0 WHERE ID=1");
        }
        
        public override void Down()
        {
        }
    }
}
