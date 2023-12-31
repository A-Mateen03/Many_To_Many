﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelationShip_Many_Many.Data;

#nullable disable

namespace RelationShip_Many_Many.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230912171508_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_CommerceSite.Models.Buyer", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuyerId"));

                    b.Property<int?>("BuyerProductId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerId");

                    b.HasIndex("BuyerProductId");

                    b.ToTable("buyers");
                });

            modelBuilder.Entity("E_CommerceSite.Models.BuyerProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int>("P_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BuyersProducts");
                });

            modelBuilder.Entity("E_CommerceSite.Models.Products", b =>
                {
                    b.Property<int>("P_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("P_ID"));

                    b.Property<int?>("BuyerProductId")
                        .HasColumnType("int");

                    b.Property<string>("P_Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P_ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("P_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("P_Price")
                        .HasColumnType("int");

                    b.HasKey("P_ID");

                    b.HasIndex("BuyerProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_CommerceSite.Models.Buyer", b =>
                {
                    b.HasOne("E_CommerceSite.Models.BuyerProduct", "BuyerProduct")
                        .WithMany("Buyer")
                        .HasForeignKey("BuyerProductId");

                    b.Navigation("BuyerProduct");
                });

            modelBuilder.Entity("E_CommerceSite.Models.Products", b =>
                {
                    b.HasOne("E_CommerceSite.Models.BuyerProduct", "BuyerProduct")
                        .WithMany("products")
                        .HasForeignKey("BuyerProductId");

                    b.Navigation("BuyerProduct");
                });

            modelBuilder.Entity("E_CommerceSite.Models.BuyerProduct", b =>
                {
                    b.Navigation("Buyer");

                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
