using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CretanMusicians.API.Migrations
{
    public partial class Addsurnametomusiciantable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Musicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Musicians");
        }
    }
}
