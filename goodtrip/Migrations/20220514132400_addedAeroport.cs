using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goodtrip.Migrations
{
    public partial class addedAeroport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AeroportName",
                table: "Transportations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AeroportName",
                table: "Transportations");
        }
    }
}
