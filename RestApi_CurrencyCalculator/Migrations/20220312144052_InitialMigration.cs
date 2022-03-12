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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
