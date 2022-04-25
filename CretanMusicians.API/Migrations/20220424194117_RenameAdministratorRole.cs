using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CretanMusicians.API.Migrations
{
    public partial class RenameAdministratorRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4847a33b-6943-43fb-a84c-aa17afcdcb5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84e9cbf8-31aa-409b-95ab-30b4e30297f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65fe4fab-7172-4fe5-8b74-85525d3e84f7", "c420b98d-0225-4104-91d9-f4b5e1dfed0f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c51d8848-1d0e-46a9-99f2-d4a5caf58d57", "64c8ef67-9ff3-42df-bbe3-923151e0b834", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65fe4fab-7172-4fe5-8b74-85525d3e84f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c51d8848-1d0e-46a9-99f2-d4a5caf58d57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4847a33b-6943-43fb-a84c-aa17afcdcb5c", "a78688bc-1198-43b9-9858-d19f1f2a482f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84e9cbf8-31aa-409b-95ab-30b4e30297f8", "7505d6e5-fb93-464d-8a3b-6daf41304161", "Administator", "ADMINISTRATOR" });
        }
    }
}
