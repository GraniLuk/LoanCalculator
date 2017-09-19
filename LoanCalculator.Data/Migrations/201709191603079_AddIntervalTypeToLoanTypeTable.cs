namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIntervalTypeToLoanTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanTypes", "IntervalType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoanTypes", "IntervalType");
        }
    }
}
