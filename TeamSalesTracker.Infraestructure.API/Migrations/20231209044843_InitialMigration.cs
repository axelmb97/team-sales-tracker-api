using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TeamSalesTracker.Infraestructure.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetName = table.Column<string>(type: "text", nullable: false),
                    StreetNumber = table.Column<long>(type: "bigint", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Apartment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "BRANCHES",
                columns: table => new
                {
                    BranchId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BranchNumber = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCHES", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_BRANCHES_ADDRESSES_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ADDRESSES",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_USERS_ADDRESSES_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ADDRESSES",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INTERVALS",
                columns: table => new
                {
                    IntervalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<DateOnly>(type: "date", nullable: false),
                    Until = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TargetAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVALS", x => x.IntervalId);
                    table.ForeignKey(
                        name: "FK_INTERVALS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLES",
                columns: table => new
                {
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLES", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_USER_ROLES_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ROLES",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_ROLES_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INTERVAL_TARGETS",
                columns: table => new
                {
                    IntervalTargetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    IntervalId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVAL_TARGETS", x => x.IntervalTargetId);
                    table.ForeignKey(
                        name: "FK_INTERVAL_TARGETS_INTERVALS_IntervalId",
                        column: x => x.IntervalId,
                        principalTable: "INTERVALS",
                        principalColumn: "IntervalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INTERVAL_TARGETS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALES",
                columns: table => new
                {
                    SaleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IntervalId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_SALES_BRANCHES_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BRANCHES",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SALES_INTERVALS_IntervalId",
                        column: x => x.IntervalId,
                        principalTable: "INTERVALS",
                        principalColumn: "IntervalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALE_DETAILS",
                columns: table => new
                {
                    SaleDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    SaleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALE_DETAILS", x => x.SaleDetailId);
                    table.ForeignKey(
                        name: "FK_SALE_DETAILS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SALE_DETAILS_SALES_SaleId",
                        column: x => x.SaleId,
                        principalTable: "SALES",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BRANCHES_AddressId",
                table: "BRANCHES",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVAL_TARGETS_IntervalId",
                table: "INTERVAL_TARGETS",
                column: "IntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVAL_TARGETS_ProductId",
                table: "INTERVAL_TARGETS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVALS_UserId",
                table: "INTERVALS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SALE_DETAILS_ProductId",
                table: "SALE_DETAILS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SALE_DETAILS_SaleId",
                table: "SALE_DETAILS",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_BranchId",
                table: "SALES",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_IntervalId",
                table: "SALES",
                column: "IntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLES_RoleId",
                table: "USER_ROLES",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLES_UserId",
                table: "USER_ROLES",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_AddressId",
                table: "USERS",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INTERVAL_TARGETS");

            migrationBuilder.DropTable(
                name: "SALE_DETAILS");

            migrationBuilder.DropTable(
                name: "USER_ROLES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "SALES");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "BRANCHES");

            migrationBuilder.DropTable(
                name: "INTERVALS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "ADDRESSES");
        }
    }
}
