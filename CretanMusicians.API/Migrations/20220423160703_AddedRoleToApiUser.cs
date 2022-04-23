using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CretanMusicians.API.Migrations
{
    public partial class AddedRoleToApiUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31f9d822-d301-42ca-9d1d-8e8f8dabf7a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fceb3298-17e4-433a-8d4b-54aa6b183a41");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76773e62-97ec-4d05-96d7-91941175640d", "553fde9c-60db-493c-865a-caaceb9cf23a", "Administator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b009e843-f87b-4b41-9d78-dcec1e55ee1d", "b8a9e871-6180-4a96-9437-f35da4ee1af4", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76773e62-97ec-4d05-96d7-91941175640d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b009e843-f87b-4b41-9d78-dcec1e55ee1d");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31f9d822-d301-42ca-9d1d-8e8f8dabf7a3", "24f47be5-2711-4b91-8ce1-d3e7efdc4f6e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fceb3298-17e4-433a-8d4b-54aa6b183a41", "4cc2cc6b-192e-4e24-b9f8-526ba8f3c312", "Administator", "ADMINISTRATOR" });
        }
    }
}
