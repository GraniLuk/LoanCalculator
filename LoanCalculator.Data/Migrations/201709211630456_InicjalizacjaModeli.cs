namespace LoanCalculator.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InicjalizacjaModeli : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IntervalTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PeriodsInYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        InterestRate = c.Decimal(nullable: false, precision: 10, scale: 4),
                        PaymentIntervalId = c.Int(),
                        RateIntervalId = c.Int(),
                        DueTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IntervalTypes", t => t.PaymentIntervalId)
                .ForeignKey("dbo.IntervalTypes", t => t.RateIntervalId)
                .Index(t => t.PaymentIntervalId)
                .Index(t => t.RateIntervalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypes", "RateIntervalId", "dbo.IntervalTypes");
            DropForeignKey("dbo.LoanTypes", "PaymentIntervalId", "dbo.IntervalTypes");
            DropIndex("dbo.LoanTypes", new[] { "RateIntervalId" });
            DropIndex("dbo.LoanTypes", new[] { "PaymentIntervalId" });
            DropIndex("dbo.Loans", new[] { "LoanTypeId" });
            DropTable("dbo.LoanTypes");
            DropTable("dbo.Loans");
            DropTable("dbo.IntervalTypes");
        }
    }
}
