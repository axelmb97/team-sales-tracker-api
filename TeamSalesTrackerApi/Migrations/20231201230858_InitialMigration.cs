using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    address_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street_name = table.Column<string>(type: "text", nullable: false),
                    street_number = table.Column<long>(type: "bigint", nullable: false),
                    zip_code = table.Column<string>(type: "text", nullable: false),
                    apartment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "BRANCHES",
                columns: table => new
                {
                    branch_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    branch_number = table.Column<long>(type: "bigint", nullable: false),
                    address_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCHES", x => x.branch_id);
                    table.ForeignKey(
                        name: "FK_BRANCHES_ADDRESSES_address_id",
                        column: x => x.address_id,
                        principalTable: "ADDRESSES",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    address_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_USERS_ADDRESSES_address_id",
                        column: x => x.address_id,
                        principalTable: "ADDRESSES",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INTERVALS",
                columns: table => new
                {
                    interval_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    from = table.Column<DateOnly>(type: "date", nullable: false),
                    until = table.Column<DateOnly>(type: "date", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    target_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVALS", x => x.interval_id);
                    table.ForeignKey(
                        name: "FK_INTERVALS_USERS_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INTERVAl_TARGETS",
                columns: table => new
                {
                    interval_target_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: false),
                    interval_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVAl_TARGETS", x => x.interval_target_id);
                    table.ForeignKey(
                        name: "FK_INTERVAl_TARGETS_INTERVALS_interval_id",
                        column: x => x.interval_id,
                        principalTable: "INTERVALS",
                        principalColumn: "interval_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INTERVAl_TARGETS_PRODUCTS_product_id",
                        column: x => x.product_id,
                        principalTable: "PRODUCTS",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALES",
                columns: table => new
                {
                    sale_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    interval_id = table.Column<long>(type: "bigint", nullable: false),
                    branch_id = table.Column<long>(type: "bigint", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES", x => x.sale_id);
                    table.ForeignKey(
                        name: "FK_SALES_BRANCHES_branch_id",
                        column: x => x.branch_id,
                        principalTable: "BRANCHES",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SALES_INTERVALS_interval_id",
                        column: x => x.interval_id,
                        principalTable: "INTERVALS",
                        principalColumn: "interval_id",
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
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SALE_DETAILS_SALES_SaleId",
                        column: x => x.SaleId,
                        principalTable: "SALES",
                        principalColumn: "sale_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BRANCHES_address_id",
                table: "BRANCHES",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVAl_TARGETS_interval_id",
                table: "INTERVAl_TARGETS",
                column: "interval_id");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVAl_TARGETS_product_id",
                table: "INTERVAl_TARGETS",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVALS_user_id",
                table: "INTERVALS",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_SALE_DETAILS_ProductId",
                table: "SALE_DETAILS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SALE_DETAILS_SaleId",
                table: "SALE_DETAILS",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_branch_id",
                table: "SALES",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_interval_id",
                table: "SALES",
                column: "interval_id");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_address_id",
                table: "USERS",
                column: "address_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INTERVAl_TARGETS");

            migrationBuilder.DropTable(
                name: "SALE_DETAILS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "SALES");

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
