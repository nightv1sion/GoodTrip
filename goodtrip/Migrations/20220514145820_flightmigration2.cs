using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goodtrip.Migrations
{
    public partial class flightmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Tours_TourId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Tours_TourID",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_TourId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_TourID",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TourID",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Flights",
                newName: "TourID");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourID",
                table: "Flights",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TourID",
                table: "Flights",
                column: "TourID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Tours_TourID",
                table: "Flights",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Tours_TourID",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_TourID",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "TourID",
                table: "Flights",
                newName: "TourId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                table: "Flights",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "TourID",
                table: "Flights",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TourId",
                table: "Flights",
                column: "TourId",
                unique: true,
                filter: "[TourId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TourID",
                table: "Flights",
                column: "TourID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Tours_TourId",
                table: "Flights",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id");

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
