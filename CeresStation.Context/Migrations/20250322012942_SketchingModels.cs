using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeresStation.Core.Migrations
{
    /// <inheritdoc />
    public partial class SketchingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_EntityBase_EntityId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityBase_Resources_ResourceId",
                table: "EntityBase");

            migrationBuilder.DropForeignKey(
                name: "FK_Reagents_EntityBase_ProcessorId",
                table: "Reagents");

            migrationBuilder.DropForeignKey(
                name: "FK_Reagents_EntityBase_ProcessorId1",
                table: "Reagents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityBase",
                table: "EntityBase");

            migrationBuilder.RenameTable(
                name: "EntityBase",
                newName: "Entities");

            migrationBuilder.RenameIndex(
                name: "IX_EntityBase_ResourceId",
                table: "Entities",
                newName: "IX_Entities_ResourceId");

            migrationBuilder.AddColumn<float>(
                name: "ConsumptionRate",
                table: "Entities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CurrentCargo",
                table: "Entities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId",
                table: "Entities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Extractor_Capacity",
                table: "Entities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Extractor_ResourceId",
                table: "Entities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Extractor_StandardDeviation",
                table: "Entities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Extractor_Stockpile",
                table: "Entities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SourceId",
                table: "Entities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Transport_Capacity",
                table: "Entities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Transport_ResourceId",
                table: "Entities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TripTimeStandardDeviation",
                table: "Entities",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_DestinationId",
                table: "Entities",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_Extractor_ResourceId",
                table: "Entities",
                column: "Extractor_ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_SourceId",
                table: "Entities",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_Transport_ResourceId",
                table: "Entities",
                column: "Transport_ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Entities_EntityId",
                table: "Attributes",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Entities_DestinationId",
                table: "Entities",
                column: "DestinationId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Entities_SourceId",
                table: "Entities",
                column: "SourceId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Resources_Extractor_ResourceId",
                table: "Entities",
                column: "Extractor_ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Resources_ResourceId",
                table: "Entities",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Resources_Transport_ResourceId",
                table: "Entities",
                column: "Transport_ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reagents_Entities_ProcessorId",
                table: "Reagents",
                column: "ProcessorId",
                principalTable: "Entities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reagents_Entities_ProcessorId1",
                table: "Reagents",
                column: "ProcessorId1",
                principalTable: "Entities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Entities_EntityId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Entities_DestinationId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Entities_SourceId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Resources_Extractor_ResourceId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Resources_ResourceId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Resources_Transport_ResourceId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Reagents_Entities_ProcessorId",
                table: "Reagents");

            migrationBuilder.DropForeignKey(
                name: "FK_Reagents_Entities_ProcessorId1",
                table: "Reagents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_DestinationId",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_Extractor_ResourceId",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_SourceId",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_Transport_ResourceId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "ConsumptionRate",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "CurrentCargo",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Extractor_Capacity",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Extractor_ResourceId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Extractor_StandardDeviation",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Extractor_Stockpile",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Transport_Capacity",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "Transport_ResourceId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "TripTimeStandardDeviation",
                table: "Entities");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "EntityBase");

            migrationBuilder.RenameIndex(
                name: "IX_Entities_ResourceId",
                table: "EntityBase",
                newName: "IX_EntityBase_ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityBase",
                table: "EntityBase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_EntityBase_EntityId",
                table: "Attributes",
                column: "EntityId",
                principalTable: "EntityBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityBase_Resources_ResourceId",
                table: "EntityBase",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reagents_EntityBase_ProcessorId",
                table: "Reagents",
                column: "ProcessorId",
                principalTable: "EntityBase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reagents_EntityBase_ProcessorId1",
                table: "Reagents",
                column: "ProcessorId1",
                principalTable: "EntityBase",
                principalColumn: "Id");
        }
    }
}
