using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeresStation.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extractors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExtractionRate = table.Column<float>(type: "REAL", nullable: false),
                    StandardDeviation = table.Column<float>(type: "REAL", nullable: false),
                    Stockpile = table.Column<float>(type: "REAL", nullable: false),
                    Capacity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extractors_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extractors_ResourceId",
                table: "Extractors",
                column: "ResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extractors");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
