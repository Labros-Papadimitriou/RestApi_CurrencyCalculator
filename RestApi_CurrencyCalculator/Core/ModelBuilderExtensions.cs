using Microsoft.EntityFrameworkCore;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Core
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

        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Seed Currencies
            //Currency eur = new Currency() { CurrencyId = 1, Code = "EUR", Name = "Euro" };
            //Currency usd = new Currency() { CurrencyId = 2, Code = "USD", Name = "U.S. Dollar" };
            //Currency gbp = new Currency() { CurrencyId = 3, Code = "GBP", Name = "British Pound Sterling" };
            //Currency chf = new Currency() { CurrencyId = 4, Code = "CHF", Name = "Swiss Franc" };
            //Currency cad = new Currency() { CurrencyId = 5, Code = "CAD", Name = "Canadian Dollar" };
            //Currency jpy = new Currency() { CurrencyId = 6, Code = "JPY", Name = "Japanese Yen" };

            //modelBuilder.Entity<Currency>().HasData(eur, usd, gbp, chf, cad, jpy);
            //#endregion

            //#region Seed Calculators
            //Calculator eurUSD = new Calculator() { CalculatorId = 1, ExchangeRate = 1.3764M };
            //Calculator eurCHF = new Calculator() { CalculatorId = 2, BaseCurrencyId = 1, TargetCurrencyId = 4, ExchangeRate = 1.2079M };
            //Calculator eurGBP = new Calculator() { CalculatorId = 3, BaseCurrencyId = 1, TargetCurrencyId = 3, ExchangeRate = 0.8731M };
            //Calculator usdJPY = new Calculator() { CalculatorId = 4, BaseCurrencyId = 2, TargetCurrencyId = 6, ExchangeRate = 76.7200M };
            //Calculator chfUSD = new Calculator() { CalculatorId = 5, BaseCurrencyId = 4, TargetCurrencyId = 2, ExchangeRate = 1.1379M };
            //Calculator gbpCAD = new Calculator() { CalculatorId = 6, BaseCurrencyId = 3, TargetCurrencyId = 5, ExchangeRate = 1.5648M };

            //modelBuilder.Entity<Currency>().HasData(eurUSD/*, eurCHF, eurGBP, usdJPY, chfUSD, gbpCAD*/);
            #endregion
        }
    }
}
