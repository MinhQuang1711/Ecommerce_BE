﻿// <auto-generated />
using Ecommerce_BE.Data.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce_BE.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    partial class EcommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.BillOfSale", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<double>("FinalPrice")
                        .HasColumnType("double");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("SaleDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("BillOfSale");
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.DetailBillOfSale", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BillId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Quantity")
                        .HasColumnType("double");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("DetailBillOfSale");
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.DetailImportBill", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImportBillId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IngerdientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Quantity")
                        .HasColumnType("double");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("ImportBillId");

                    b.HasIndex("IngerdientId");

                    b.ToTable("DetailImportBill");
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.DetailProduct", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IngredientID")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("SumCost")
                        .HasColumnType("double");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("IngredientID");

                    b.HasIndex("ProductID");

                    b.ToTable("detailProducts");
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.ImportBill", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImportDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("ImportBill");
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.Ingerdient", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("ImportPrice")
                        .HasColumnType("double");

                    b.Property<double>("Loss")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("NetWeight")
                        .HasColumnType("double");

                    b.Property<double>("PricePerGram")
                        .HasColumnType("double");

                    b.Property<double>("RealWeight")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("ingredients");
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.Product", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("PercentProfit")
                        .HasColumnType("double");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<double>("SalePrice")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.DetailBillOfSale", b =>
                {
                    b.HasOne("Ecommerce_BE.Data.Domains.BillOfSale", null)
                        .WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce_BE.Data.Domains.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.DetailImportBill", b =>
                {
                    b.HasOne("Ecommerce_BE.Data.Domains.ImportBill", null)
                        .WithMany()
                        .HasForeignKey("ImportBillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce_BE.Data.Domains.Ingerdient", null)
                        .WithMany()
                        .HasForeignKey("IngerdientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce_BE.Data.Domains.DetailProduct", b =>
                {
                    b.HasOne("Ecommerce_BE.Data.Domains.Ingerdient", null)
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce_BE.Data.Domains.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
