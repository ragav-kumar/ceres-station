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
    [Migration("20250214022656_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("CeresStation.Models.Extractor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

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

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("Extractors");
                });

            modelBuilder.Entity("CeresStation.Models.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("CeresStation.Models.Extractor", b =>
                {
                    b.HasOne("CeresStation.Models.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");
                });
#pragma warning restore 612, 618
        }
    }
}
