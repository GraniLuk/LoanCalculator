using LoanCalculator.Data.Models;

namespace LoanCalculator.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LoanDb : DbContext
    {
        // Your context has been configured to use a 'LoanDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LoanCalculator.Data.LoanDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LoanDb' 
        // connection string in the application configuration file.
        public LoanDb()
            : base("name=LoanDb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}