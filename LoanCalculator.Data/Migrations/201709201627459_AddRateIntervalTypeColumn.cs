namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRateIntervalTypeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanTypes", "PaymentIntervalType", c => c.Int(nullable: false));
            AddColumn("dbo.LoanTypes", "RateIntervalType", c => c.Int(nullable: false));
            DropColumn("dbo.LoanTypes", "IntervalType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanTypes", "IntervalType", c => c.Int(nullable: false));
            DropColumn("dbo.LoanTypes", "RateIntervalType");
            DropColumn("dbo.LoanTypes", "PaymentIntervalType");
        }
    }
}
