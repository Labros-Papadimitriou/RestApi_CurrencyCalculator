using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi_CurrencyCalculator.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Calculators",
                columns: table => new
                {
                    CalculatorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    BaseCurrencyId = table.Column<int>(nullable: false),
                    TargetCurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculators", x => x.CalculatorId);
                    table.ForeignKey(
                        name: "FK_Calculators_Currencies_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                    table.ForeignKey(
                        name: "FK_Calculators_Currencies_TargetCurrencyId",
                        column: x => x.TargetCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "EUR", "Euro" },
                    { 2, "USD", "U.S. Dollar" },
                    { 3, "GBP", "British Pound Sterling" },
                    { 4, "CHF", "Swiss Franc" },
                    { 5, "CAD", "Canadian Dollar" },
                    { 6, "JPY", "Japanese Yen" }
                });

            migrationBuilder.InsertData(
                table: "Calculators",
                columns: new[] { "CalculatorId", "ExchangeRate", "TimeStamp", "BaseCurrencyId", "TargetCurrencyId" },
                values: new object[,]
                {
                    { 1, 1.3764, "2022-02-05", 1, 2 },
                    { 2, 1.2079, "2022-02-05", 1, 4 },
                    { 3, 0.8731, "2022-02-05", 1, 3 },
                    { 4, 76.7200, "2022-02-05", 2, 6 },
                    { 5, 1.1379, "2022-02-05", 4, 2 },
                    { 6, 1.5648, "2022-02-05", 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_BaseCurrencyId",
                table: "Calculators",
                column: "BaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculators_TargetCurrencyId",
                table: "Calculators",
                column: "TargetCurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculators");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
