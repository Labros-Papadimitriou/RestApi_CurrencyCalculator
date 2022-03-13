using Microsoft.EntityFrameworkCore;
using RestApi_CurrencyCalculator.Core;
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
            modelBuilder.RelateModels();
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Calculator> Calculators { get; set; }
    }
}
