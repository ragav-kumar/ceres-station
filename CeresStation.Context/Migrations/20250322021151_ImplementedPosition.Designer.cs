﻿// <auto-generated />
using System;
using CeresStation.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CeresStation.Core.Migrations
{
    [DbContext(typeof(StationContext))]
    [Migration("20250322021151_ImplementedPosition")]
    partial class ImplementedPosition
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("CeresStation.Model.Column", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AttributeDefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("EntityType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FieldName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("FieldType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("CeresStation.Model.EntityAttribute", b =>
                {
                    b.Property<Guid>("EntityId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(900)
                        .HasColumnType("TEXT");

                    b.HasKey("EntityId", "DefinitionId");

                    b.HasIndex("DefinitionId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("CeresStation.Model.EntityAttributeDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("DataType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntityType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AttributeDefinitions");
                });

            modelBuilder.Entity("CeresStation.Model.EntityBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Entities");

                    b.HasDiscriminator().HasValue("EntityBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CeresStation.Model.Reagent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("Count")
                        .HasColumnType("REAL");

                    b.Property<Guid?>("ProcessorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProcessorId1")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("TEXT");

                    b.Property<float>("StockpileCapacity")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ProcessorId");

                    b.HasIndex("ProcessorId1");

                    b.HasIndex("ResourceId");

                    b.ToTable("Reagents");
                });

            modelBuilder.Entity("CeresStation.Model.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("CeresStation.Model.Consumer", b =>
                {
                    b.HasBaseType("CeresStation.Model.EntityBase");

                    b.Property<float>("Capacity")
                        .HasColumnType("REAL");

                    b.Property<float>("ConsumptionRate")
                        .HasColumnType("REAL");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("TEXT");

                    b.Property<float>("StandardDeviation")
                        .HasColumnType("REAL");

                    b.Property<float>("Stockpile")
                        .HasColumnType("REAL");

                    b.HasIndex("ResourceId");

                    b.HasDiscriminator().HasValue("Consumer");
                });

            modelBuilder.Entity("CeresStation.Model.Extractor", b =>
                {
                    b.HasBaseType("CeresStation.Model.EntityBase");

                    b.Property<float>("Capacity")
                        .HasColumnType("REAL");

                    b.Property<float>("ExtractionRate")
                        .HasColumnType("REAL");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("TEXT");

                    b.Property<float>("StandardDeviation")
                        .HasColumnType("REAL");

                    b.Property<float>("Stockpile")
                        .HasColumnType("REAL");

                    b.HasIndex("ResourceId");

                    b.ToTable("Entities", t =>
                        {
                            t.Property("Capacity")
                                .HasColumnName("Extractor_Capacity");

                            t.Property("ResourceId")
                                .HasColumnName("Extractor_ResourceId");

                            t.Property("StandardDeviation")
                                .HasColumnName("Extractor_StandardDeviation");

                            t.Property("Stockpile")
                                .HasColumnName("Extractor_Stockpile");
                        });

                    b.HasDiscriminator().HasValue("Extractor");
                });

            modelBuilder.Entity("CeresStation.Model.Processor", b =>
                {
                    b.HasBaseType("CeresStation.Model.EntityBase");

                    b.Property<float>("TimeStep")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("Processor");
                });

            modelBuilder.Entity("CeresStation.Model.Transport", b =>
                {
                    b.HasBaseType("CeresStation.Model.EntityBase");

                    b.Property<float>("Capacity")
                        .HasColumnType("REAL");

                    b.Property<float>("CurrentCargo")
                        .HasColumnType("REAL");

                    b.Property<Guid>("DestinationId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("TEXT");

                    b.Property<float>("TripTimeStandardDeviation")
                        .HasColumnType("REAL");

                    b.HasIndex("DestinationId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("SourceId");

                    b.ToTable("Entities", t =>
                        {
                            t.Property("Capacity")
                                .HasColumnName("Transport_Capacity");

                            t.Property("ResourceId")
                                .HasColumnName("Transport_ResourceId");
                        });

                    b.HasDiscriminator().HasValue("Transport");
                });

            modelBuilder.Entity("CeresStation.Model.EntityAttribute", b =>
                {
                    b.HasOne("CeresStation.Model.EntityAttributeDefinition", "Definition")
                        .WithMany()
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CeresStation.Model.EntityBase", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Definition");

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("CeresStation.Model.EntityBase", b =>
                {
                    b.OwnsOne("CeresStation.Model.Position", "Position", b1 =>
                        {
                            b1.Property<Guid>("EntityBaseId")
                                .HasColumnType("TEXT");

                            b1.Property<double>("X")
                                .HasColumnType("REAL");

                            b1.Property<double>("Y")
                                .HasColumnType("REAL");

                            b1.Property<double>("Z")
                                .HasColumnType("REAL");

                            b1.HasKey("EntityBaseId");

                            b1.ToTable("Entities");

                            b1.WithOwner()
                                .HasForeignKey("EntityBaseId");
                        });

                    b.Navigation("Position")
                        .IsRequired();
                });

            modelBuilder.Entity("CeresStation.Model.Reagent", b =>
                {
                    b.HasOne("CeresStation.Model.Processor", null)
                        .WithMany("Inputs")
                        .HasForeignKey("ProcessorId");

                    b.HasOne("CeresStation.Model.Processor", null)
                        .WithMany("Outputs")
                        .HasForeignKey("ProcessorId1");

                    b.HasOne("CeresStation.Model.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("CeresStation.Model.Consumer", b =>
                {
                    b.HasOne("CeresStation.Model.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("CeresStation.Model.Extractor", b =>
                {
                    b.HasOne("CeresStation.Model.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("CeresStation.Model.Transport", b =>
                {
                    b.HasOne("CeresStation.Model.EntityBase", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CeresStation.Model.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CeresStation.Model.EntityBase", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Resource");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("CeresStation.Model.Processor", b =>
                {
                    b.Navigation("Inputs");

                    b.Navigation("Outputs");
                });
#pragma warning restore 612, 618
        }
    }
}
