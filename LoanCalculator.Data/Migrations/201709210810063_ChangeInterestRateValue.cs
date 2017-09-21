namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInterestRateValue : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.LoanTypes SET InterestRate = 0.0315 WHERE ID=1");
          
        }
        
        public override void Down()
        {
        }
    }
}
