namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoanTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        PaybackTimeInYears = c.Int(nullable: false),
                        LoanType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoanTypes", t => t.LoanType_Id)
                .Index(t => t.LoanType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanType_Id" });
            DropTable("dbo.Loans");
        }
    }
}
