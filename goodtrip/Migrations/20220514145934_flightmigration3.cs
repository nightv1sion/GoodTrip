using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goodtrip.Migrations
{
    public partial class flightmigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Tours_TourID",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "TourID",
                table: "Flights",
                newName: "TourId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_TourID",
                table: "Flights",
                newName: "IX_Flights_TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Tours_TourId",
                table: "Flights",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Tours_TourId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Flights",
                newName: "TourID");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_TourId",
                table: "Flights",
                newName: "IX_Flights_TourID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Tours_TourID",
                table: "Flights",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
