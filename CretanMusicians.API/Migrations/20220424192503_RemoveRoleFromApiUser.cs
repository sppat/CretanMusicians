using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CretanMusicians.API.Migrations
{
    public partial class RemoveRoleFromApiUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34b281cc-738c-441a-8956-eb2de0a926e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e9d0ea2-8df1-4a56-a2f3-0aa795866902");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4847a33b-6943-43fb-a84c-aa17afcdcb5c", "a78688bc-1198-43b9-9858-d19f1f2a482f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84e9cbf8-31aa-409b-95ab-30b4e30297f8", "7505d6e5-fb93-464d-8a3b-6daf41304161", "Administator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4847a33b-6943-43fb-a84c-aa17afcdcb5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84e9cbf8-31aa-409b-95ab-30b4e30297f8");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34b281cc-738c-441a-8956-eb2de0a926e6", "aca23fd5-84b0-47cd-a964-9efc568d3629", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e9d0ea2-8df1-4a56-a2f3-0aa795866902", "23ff1464-8e44-4445-af86-f4a38a01e28c", "Administator", "ADMINISTRATOR" });
        }
    }
}
