namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetPropertiesInLoanAsRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanType_Id" });
            AlterColumn("dbo.Loans", "LoanType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Loans", "LoanType_Id");
            AddForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanType_Id" });
            AlterColumn("dbo.Loans", "LoanType_Id", c => c.Int());
            CreateIndex("dbo.Loans", "LoanType_Id");
            AddForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes", "Id");
        }
    }
}
