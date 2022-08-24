﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurfBoardManager.Data;

#nullable disable

namespace SurfBoardManager.Migrations
{
    [DbContext(typeof(SurfBoardManagerContext))]
    partial class SurfBoardManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SurfBoardManager.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BoardTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Thickness")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BoardTypeId");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("SurfBoardManager.Models.BoardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoardType");
                });

            modelBuilder.Entity("SurfBoardManager.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("SurfBoardManager.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BoardId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("SurfBoardManager.Models.Board", b =>
                {
                    b.HasOne("SurfBoardManager.Models.BoardType", "BoardType")
                        .WithMany()
                        .HasForeignKey("BoardTypeId");

                    b.Navigation("BoardType");
                });

            modelBuilder.Entity("SurfBoardManager.Models.Equipment", b =>
                {
                    b.HasOne("SurfBoardManager.Models.Post", null)
                        .WithMany("Equipment")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("SurfBoardManager.Models.Post", b =>
                {
                    b.HasOne("SurfBoardManager.Models.Board", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId");

                    b.Navigation("Board");
                });

            modelBuilder.Entity("SurfBoardManager.Models.Post", b =>
                {
                    b.Navigation("Equipment");
                });
#pragma warning restore 612, 618
        }
    }
}
