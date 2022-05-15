using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goodtrip.Migrations
{
    public partial class FixTry10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flights_TourId",
                table: "Flights");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TourId",
                table: "Flights",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flights_TourId",
                table: "Flights");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TourId",
                table: "Flights",
                column: "TourId",
                unique: true);
        }
    }
}
