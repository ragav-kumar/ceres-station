using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeresStation.Core.Migrations
{
    /// <inheritdoc />
    public partial class Reorganizedproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Columns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Columns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Columns");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Columns");
        }
    }
}
