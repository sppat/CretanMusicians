using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CretanMusicians.API.Migrations
{
    public partial class MadeRoleNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76773e62-97ec-4d05-96d7-91941175640d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b009e843-f87b-4b41-9d78-dcec1e55ee1d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34b281cc-738c-441a-8956-eb2de0a926e6", "aca23fd5-84b0-47cd-a964-9efc568d3629", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e9d0ea2-8df1-4a56-a2f3-0aa795866902", "23ff1464-8e44-4445-af86-f4a38a01e28c", "Administator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34b281cc-738c-441a-8956-eb2de0a926e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e9d0ea2-8df1-4a56-a2f3-0aa795866902");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76773e62-97ec-4d05-96d7-91941175640d", "553fde9c-60db-493c-865a-caaceb9cf23a", "Administator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b009e843-f87b-4b41-9d78-dcec1e55ee1d", "b8a9e871-6180-4a96-9437-f35da4ee1af4", "User", "USER" });
        }
    }
}
