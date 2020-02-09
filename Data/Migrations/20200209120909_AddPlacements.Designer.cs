﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using stronkgame;

namespace stronkgame.Migrations
{
    [DbContext(typeof(StronkGameContext))]
    [Migration("20200209120909_AddPlacements")]
    partial class AddPlacements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("stronkgame.Placement", b =>
                {
                    b.Property<int>("PlacementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColorCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("XPosition")
                        .HasColumnType("TEXT");

                    b.Property<string>("YPosition")
                        .HasColumnType("TEXT");

                    b.HasKey("PlacementId");

                    b.ToTable("Placements");
                });
#pragma warning restore 612, 618
        }
    }
}
