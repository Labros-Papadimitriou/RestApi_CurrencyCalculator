using Microsoft.EntityFrameworkCore;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Calculator>()
                    .HasOne(m => m.BaseCurrency)
                    .WithMany(t => t.BaseCurrencies)
                    .HasForeignKey(m => m.BaseCurrencyId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Calculator>()
                        .HasOne(m => m.TargetCurrency)
                        .WithMany(t => t.TargetCurrencies)
                        .HasForeignKey(m => m.TargetCurrencyId)
                        .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Calculator>()
                    .Property("ExchangeRate")
                    .HasColumnType("decimal(18, 4)");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Calculator> Calculators { get; set; }
    }
}
