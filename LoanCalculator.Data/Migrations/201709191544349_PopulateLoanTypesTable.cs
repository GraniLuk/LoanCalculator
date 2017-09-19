namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLoanTypesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanTypes", "InterestRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            Sql("Insert into LoanTypes(Name, InterestRate) VALUES ('HousingLoan',3.5)");
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoanTypes", "InterestRate");
        }
    }
}
