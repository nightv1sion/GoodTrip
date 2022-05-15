using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goodtrip.Migrations
{
    public partial class AddingImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageExcurtion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExcurtionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageExcurtion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageExcurtion_Excurtions_ExcurtionId",
                        column: x => x.ExcurtionId,
                        principalTable: "Excurtions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageExcurtion_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageHotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageHotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageHotel_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageExcurtion_ExcurtionId",
                table: "ImageExcurtion",
                column: "ExcurtionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageExcurtion_HotelId",
                table: "ImageExcurtion",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageHotel_HotelId",
                table: "ImageHotel",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageExcurtion");

            migrationBuilder.DropTable(
                name: "ImageHotel");
        }
    }
}
