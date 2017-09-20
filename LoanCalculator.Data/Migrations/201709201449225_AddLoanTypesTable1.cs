namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoanTypesTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IntervalType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoanTypes");
        }
    }
}
