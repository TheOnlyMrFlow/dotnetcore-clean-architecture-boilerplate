using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreBoilerplate.Persistence.EFCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Celsius = table.Column<decimal>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecast", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecast_Date",
                table: "WeatherForecast",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecast_Guid",
                table: "WeatherForecast",
                column: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecast");
        }
    }
}
