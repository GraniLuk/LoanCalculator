namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoanTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        NumberOfInstallments = c.Int(nullable: false),
                        LoanTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
                .Index(t => t.LoanTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanTypeId", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanTypeId" });
            DropTable("dbo.Loans");
        }
    }
}
