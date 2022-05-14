using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goodtrip.Migrations
{
    public partial class EntitiesUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TourId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TourID",
                table: "Flights",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TourId",
                table: "Flights",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TourID",
                table: "Excurtions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mark = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    FreeRooms = table.Column<int>(type: "int", nullable: false),
                    IsWifi = table.Column<bool>(type: "bit", nullable: false),
                    Food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TourId",
                table: "Reviews",
                column: "TourId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Excurtions_TourID",
                table: "Excurtions",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_TourId",
                table: "Hotel",
                column: "TourId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Excurtions_Tours_TourID",
                table: "Excurtions",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Tours_TourId",
                table: "Reviews",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excurtions_Tours_TourID",
                table: "Excurtions");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Tours_TourId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Tours_TourID",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Tours_TourId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TourId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Flights_TourId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_TourID",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Excurtions_TourID",
                table: "Excurtions");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "TourID",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TourID",
                table: "Excurtions");
        }
    }
}
