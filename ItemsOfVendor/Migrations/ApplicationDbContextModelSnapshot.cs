﻿// <auto-generated />
using System;
using ItemsOfVendor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ItemsOfVendor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemsOfVendor.Models.Item", b =>
                {
                    b.Property<Guid>("IId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ICode")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("IName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("IPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ItemsOfVendor.Models.Vendor", b =>
                {
                    b.Property<Guid>("VId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VCode")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VContact_No")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VId");

                    b.ToTable("Vendors");
                });
#pragma warning restore 612, 618
        }
    }
}
