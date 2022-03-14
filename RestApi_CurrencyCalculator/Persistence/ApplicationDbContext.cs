using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.Models;

namespace RestApi_CurrencyCalculator.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RelateModels();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Calculator> Calculators { get; set; }
    }
}
