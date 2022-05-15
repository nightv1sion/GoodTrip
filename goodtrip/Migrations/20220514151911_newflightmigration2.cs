using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goodtrip.Migrations
{
    public partial class newflightmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excurtions_Tours_TourID",
                table: "Excurtions");

            migrationBuilder.RenameColumn(
                name: "TourID",
                table: "Excurtions",
                newName: "TourId");

            migrationBuilder.RenameIndex(
                name: "IX_Excurtions_TourID",
                table: "Excurtions",
                newName: "IX_Excurtions_TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Excurtions_Tours_TourId",
                table: "Excurtions",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excurtions_Tours_TourId",
                table: "Excurtions");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Excurtions",
                newName: "TourID");

            migrationBuilder.RenameIndex(
                name: "IX_Excurtions_TourId",
                table: "Excurtions",
                newName: "IX_Excurtions_TourID");

            migrationBuilder.AddForeignKey(
                name: "FK_Excurtions_Tours_TourID",
                table: "Excurtions",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
