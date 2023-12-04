﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TeamSalesTrackerApi.Data;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    [DbContext(typeof(SalesTrackerDB))]
    partial class SalesTrackerDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<long?>("BranchId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("branch_id");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_name");

                    b.Property<long>("StreetNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("street_number");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip_code");

                    b.HasKey("AddressId");

                    b.HasIndex("BranchId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ADDRESSES");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Branch", b =>
                {
                    b.Property<long>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("branch_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BranchId"));

                    b.Property<long>("BranchNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("branch_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("BranchId");

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

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("RoleId");

                    b.ToTable("ROLES");
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
                        .HasColumnType("bigint")
                        .HasColumnName("sale_detail_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SaleDetailId"));

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

                    b.Property<long>("SaleId")
                        .HasColumnType("bigint")
                        .HasColumnName("sale_id");

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

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
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

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password_salt");

                    b.HasKey("UserId");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.UserRole", b =>
                {
                    b.Property<long>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_role_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UserRoleId"));

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("USERS_ROLES");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Address", b =>
                {
                    b.HasOne("TeamSalesTrackerApi.Models.Branch", "Branch")
                        .WithOne("Address")
                        .HasForeignKey("TeamSalesTrackerApi.Models.Address", "BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamSalesTrackerApi.Models.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("TeamSalesTrackerApi.Models.Address", "UserId");

                    b.Navigation("Branch");

                    b.Navigation("User");
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

            modelBuilder.Entity("TeamSalesTrackerApi.Models.UserRole", b =>
                {
                    b.HasOne("TeamSalesTrackerApi.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamSalesTrackerApi.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Branch", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Interval", b =>
                {
                    b.Navigation("Targets");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.Sale", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("TeamSalesTrackerApi.Models.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Intervals");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
