namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReduceNameLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoanTypes", "Name", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoanTypes", "Name", c => c.String());
        }
    }
}
