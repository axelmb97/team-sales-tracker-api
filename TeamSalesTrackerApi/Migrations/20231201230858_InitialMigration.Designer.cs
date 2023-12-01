﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TeamSalesTrackerApi.Data;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    [DbContext(typeof(SalesTrackerDB))]
    [Migration("20231201230858_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("address_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("AddressId"));

                    b.Property<string>("Apartment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("apartment");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_name");

                    b.Property<long>("StreetNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("street_number");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip_code");

                    b.HasKey("AddressId");

                    b.ToTable("ADDRESSES");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Branch", b =>
                {
                    b.Property<long>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("branch_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BranchId"));

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint")
                        .HasColumnName("address_id");

                    b.Property<long>("BranchNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("branch_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("BranchId");

                    b.HasIndex("AddressId");

                    b.ToTable("BRANCHES");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Interval", b =>
                {
                    b.Property<long>("IntervalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("interval_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IntervalId"));

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<DateOnly>("From")
                        .HasColumnType("date")
                        .HasColumnName("from");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<decimal>("TargetAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("target_amount");

                    b.Property<DateOnly>("Until")
                        .HasColumnType("date")
                        .HasColumnName("until");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("IntervalId");

                    b.HasIndex("UserId");

                    b.ToTable("INTERVALS");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.IntervalTarget", b =>
                {
                    b.Property<long>("IntervalTargetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("interval_target_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IntervalTargetId"));

                    b.Property<long>("IntervalId")
                        .HasColumnType("bigint")
                        .HasColumnName("interval_id");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.HasKey("IntervalTargetId");

                    b.HasIndex("IntervalId");

                    b.HasIndex("ProductId");

                    b.ToTable("INTERVAl_TARGETS");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.HasKey("ProductId");

                    b.ToTable("PRODUCTS");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Sale", b =>
                {
                    b.Property<long>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("sale_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SaleId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<long>("BranchId")
                        .HasColumnType("bigint")
                        .HasColumnName("branch_id");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("created_at");

                    b.Property<long>("IntervalId")
                        .HasColumnType("bigint")
                        .HasColumnName("interval_id");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.HasKey("SaleId");

                    b.HasIndex("BranchId");

                    b.HasIndex("IntervalId");

                    b.ToTable("SALES");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.SaleDetail", b =>
                {
                    b.Property<long>("SaleDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SaleDetailId"));

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SaleId")
                        .HasColumnType("bigint");

                    b.HasKey("SaleDetailId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SALE_DETAILS");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UserId"));

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint")
                        .HasColumnName("address_id");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Branch", b =>
                {
                    b.HasOne("TeamSalesTrackerApi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Interval", b =>
                {
                    b.HasOne("TeamSalesTrackerApi.Models.User", "User")
                        .WithMany("Intervals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.IntervalTarget", b =>
                {
                    b.HasOne("TeamSalesTrackerApi.Models.Interval", "Interval")
                        .WithMany("Targets")
                        .HasForeignKey("IntervalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamSalesTrackerApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interval");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Sale", b =>
                {
                    b.HasOne("TeamSalesTrackerApi.Models.Branch", "Branch")
                        .WithMany("Sales")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamSalesTrackerApi.Models.Interval", "Interval")
                        .WithMany()
                        .HasForeignKey("IntervalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Interval");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.SaleDetail", b =>
                {
                    b.HasOne("TeamSalesTrackerApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamSalesTrackerApi.Models.Sale", "Sale")
                        .WithMany("Details")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.User", b =>
                {
                    b.HasOne("TeamSalesTrackerApi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Branch", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Interval", b =>
                {
                    b.Navigation("Targets");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Sale", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.User", b =>
                {
                    b.Navigation("Intervals");
                });
#pragma warning restore 612, 618
        }
    }
}
