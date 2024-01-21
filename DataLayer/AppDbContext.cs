using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DataLayer
{
    // AppDbContext.cs
    public class AppDbContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyPair> CurrencyPairs { get; set; }

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the connection string here
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StockExchangeDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
        }*/

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }

}
