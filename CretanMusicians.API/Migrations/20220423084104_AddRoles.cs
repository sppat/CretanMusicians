using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CretanMusicians.API.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31f9d822-d301-42ca-9d1d-8e8f8dabf7a3", "24f47be5-2711-4b91-8ce1-d3e7efdc4f6e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fceb3298-17e4-433a-8d4b-54aa6b183a41", "4cc2cc6b-192e-4e24-b9f8-526ba8f3c312", "Administator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31f9d822-d301-42ca-9d1d-8e8f8dabf7a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fceb3298-17e4-433a-8d4b-54aa6b183a41");
        }
    }
}
