using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CretanMusicians.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "musicians",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_musicians", x => new { x.id, x.first_name, x.last_name });
                });

            migrationBuilder.CreateTable(
                name: "instruments",
                columns: table => new
                {
                    musician_id = table.Column<Guid>(type: "uuid", nullable: false),
                    musician_first_name = table.Column<string>(type: "text", nullable: false),
                    musician_last_name = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_instruments", x => new { x.musician_id, x.musician_first_name, x.musician_last_name, x.id });
                    table.ForeignKey(
                        name: "fk_instruments_musicians_musician_id_musician_first_name_music",
                        columns: x => new { x.musician_id, x.musician_first_name, x.musician_last_name },
                        principalTable: "musicians",
                        principalColumns: new[] { "id", "first_name", "last_name" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "instruments");

            migrationBuilder.DropTable(
                name: "musicians");
        }
    }
}
