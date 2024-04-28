﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaSalesAndOrder.EntityFrameworkCore;

#nullable disable

namespace PizzaSalesAndOrder.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240428094314_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaSalesAndOrder.Domains.Entities.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaSalesAndOrder.Domains.Entities.OrderDetail", b =>
                {
                    b.Property<string>("OrderDetailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<string>("PizzaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("PizzaSalesAndOrder.Domains.Entities.Pizza", b =>
                {
                    b.Property<string>("PizzaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PizzaTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaSalesAndOrder.Domains.Entities.PizzaType", b =>
                {
                    b.Property<string>("PizzaTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PizzaTypeId");

                    b.ToTable("PizzaTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
