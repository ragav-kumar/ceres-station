using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeresStation.Core.Migrations
{
    /// <inheritdoc />
    public partial class V0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Extractors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Extractors");
        }
    }
}
