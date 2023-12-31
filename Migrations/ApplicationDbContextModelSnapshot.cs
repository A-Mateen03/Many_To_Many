﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelationShip_Many_Many.Data;

#nullable disable

namespace RelationShip_Many_Many.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuyerProducts", b =>
                {
                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductP_ID")
                        .HasColumnType("int");

                    b.HasKey("BuyerId", "ProductP_ID");

                    b.HasIndex("ProductP_ID");

                    b.ToTable("BuyerProducts");
                });

            modelBuilder.Entity("E_CommerceSite.Models.Buyer", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuyerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerId");

                    b.ToTable("buyers");
                });

            modelBuilder.Entity("E_CommerceSite.Models.Products", b =>
                {
                    b.Property<int>("P_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("P_ID"));

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

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RelationShip_Many_Many.Models.BuyerProducts", b =>
                {
                    b.Property<int>("BuyerProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuyerProductId"));

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductP_ID")
                        .HasColumnType("int");

                    b.HasKey("BuyerProductId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductP_ID");

                    b.ToTable("BuyerProduct");
                });

            modelBuilder.Entity("BuyerProducts", b =>
                {
                    b.HasOne("E_CommerceSite.Models.Buyer", null)
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_CommerceSite.Models.Products", null)
                        .WithMany()
                        .HasForeignKey("ProductP_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RelationShip_Many_Many.Models.BuyerProducts", b =>
                {
                    b.HasOne("E_CommerceSite.Models.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_CommerceSite.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductP_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
