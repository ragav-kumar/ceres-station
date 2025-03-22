using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeresStation.Core.Migrations
{
    /// <inheritdoc />
    public partial class ImplementedPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Position_X",
                table: "Entities",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Position_Y",
                table: "Entities",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Position_Z",
                table: "Entities",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position_X",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Position_Y",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Position_Z",
                table: "Entities");
        }
    }
}
