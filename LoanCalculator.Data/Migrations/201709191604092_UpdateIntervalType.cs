namespace LoanCalculator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIntervalType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE LoanTypes SET INTERVALTYPE = 1 where id =1");

        }
        
        public override void Down()
        {
        }
    }
}
