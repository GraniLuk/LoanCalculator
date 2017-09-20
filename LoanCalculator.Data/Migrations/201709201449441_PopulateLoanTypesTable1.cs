namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLoanTypesTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into LoanTypes(Name, InterestRate,IntervalType) VALUES ('HousingLoan',3.5,1)");
        }
        
        public override void Down()
        {
        }
    }
}
