using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeresStation.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddMainEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extractors_Resources_ResourceId",
                table: "Extractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Extractors",
                table: "Extractors");

            migrationBuilder.RenameTable(
                name: "Extractors",
                newName: "EntityBase");

            migrationBuilder.RenameIndex(
                name: "IX_Extractors_ResourceId",
                table: "EntityBase",
                newName: "IX_EntityBase_ResourceId");

            migrationBuilder.AlterColumn<float>(
                name: "Stockpile",
                table: "EntityBase",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<float>(
                name: "StandardDeviation",
                table: "EntityBase",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResourceId",
                table: "EntityBase",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "ExtractionRate",
                table: "EntityBase",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<float>(
                name: "Capacity",
                table: "EntityBase",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "EntityBase",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "TimeStep",
                table: "EntityBase",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityBase",
                table: "EntityBase",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AttributeDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EntityType = table.Column<int>(type: "INTEGER", nullable: false),
                    DataType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EntityType = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldType = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    AttributeDefinitionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    FieldName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reagents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Count = table.Column<float>(type: "REAL", nullable: false),
                    StockpileCapacity = table.Column<float>(type: "REAL", nullable: false),
                    ResourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProcessorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProcessorId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reagents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reagents_EntityBase_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "EntityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reagents_EntityBase_ProcessorId1",
                        column: x => x.ProcessorId1,
                        principalTable: "EntityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reagents_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    DefinitionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => new { x.EntityId, x.DefinitionId });
                    table.ForeignKey(
                        name: "FK_Attributes_AttributeDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "AttributeDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attributes_EntityBase_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_DefinitionId",
                table: "Attributes",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reagents_ProcessorId",
                table: "Reagents",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reagents_ProcessorId1",
                table: "Reagents",
                column: "ProcessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reagents_ResourceId",
                table: "Reagents",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityBase_Resources_ResourceId",
                table: "EntityBase",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityBase_Resources_ResourceId",
                table: "EntityBase");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "Reagents");

            migrationBuilder.DropTable(
                name: "AttributeDefinitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityBase",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "EntityBase");

            migrationBuilder.DropColumn(
                name: "TimeStep",
                table: "EntityBase");

            migrationBuilder.RenameTable(
                name: "EntityBase",
                newName: "Extractors");

            migrationBuilder.RenameIndex(
                name: "IX_EntityBase_ResourceId",
                table: "Extractors",
                newName: "IX_Extractors_ResourceId");

            migrationBuilder.AlterColumn<float>(
                name: "Stockpile",
                table: "Extractors",
                type: "REAL",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "StandardDeviation",
                table: "Extractors",
                type: "REAL",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ResourceId",
                table: "Extractors",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "ExtractionRate",
                table: "Extractors",
                type: "REAL",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Capacity",
                table: "Extractors",
                type: "REAL",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Extractors",
                table: "Extractors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Extractors_Resources_ResourceId",
                table: "Extractors",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
