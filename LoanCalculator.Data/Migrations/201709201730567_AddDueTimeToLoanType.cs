namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDueTimeToLoanType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanTypes", "PaymentIntervalPeriodInMonths", c => c.Int(nullable: false));
            AddColumn("dbo.LoanTypes", "RateIntervalPeriodInMonths", c => c.Int(nullable: false));
            AddColumn("dbo.LoanTypes", "DueTime", c => c.Int(nullable: false));
            DropColumn("dbo.LoanTypes", "PaymentIntervalType");
            DropColumn("dbo.LoanTypes", "RateIntervalType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanTypes", "RateIntervalType", c => c.Int(nullable: false));
            AddColumn("dbo.LoanTypes", "PaymentIntervalType", c => c.Int(nullable: false));
            DropColumn("dbo.LoanTypes", "DueTime");
            DropColumn("dbo.LoanTypes", "RateIntervalPeriodInMonths");
            DropColumn("dbo.LoanTypes", "PaymentIntervalPeriodInMonths");
        }
    }
}
