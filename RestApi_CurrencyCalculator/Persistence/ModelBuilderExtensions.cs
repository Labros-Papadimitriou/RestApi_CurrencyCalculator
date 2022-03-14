using Microsoft.EntityFrameworkCore;
using RestApi_CurrencyCalculator.Core.Models;

namespace RestApi_CurrencyCalculator.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void RelateModels(this ModelBuilder modelBuilder)
        {
            #region Fluent Api
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
            #endregion
        }
    }
}
