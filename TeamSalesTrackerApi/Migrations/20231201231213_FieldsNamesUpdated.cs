using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class FieldsNamesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SALE_DETAILS_PRODUCTS_ProductId",
                table: "SALE_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_SALE_DETAILS_SALES_SaleId",
                table: "SALE_DETAILS");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "SALE_DETAILS",
                newName: "remarks");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "SALE_DETAILS",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "SALE_DETAILS",
                newName: "sale_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "SALE_DETAILS",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "SaleDetailId",
                table: "SALE_DETAILS",
                newName: "sale_detail_id");

            migrationBuilder.RenameIndex(
                name: "IX_SALE_DETAILS_SaleId",
                table: "SALE_DETAILS",
                newName: "IX_SALE_DETAILS_sale_id");

            migrationBuilder.RenameIndex(
                name: "IX_SALE_DETAILS_ProductId",
                table: "SALE_DETAILS",
                newName: "IX_SALE_DETAILS_product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SALE_DETAILS_PRODUCTS_product_id",
                table: "SALE_DETAILS",
                column: "product_id",
                principalTable: "PRODUCTS",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SALE_DETAILS_SALES_sale_id",
                table: "SALE_DETAILS",
                column: "sale_id",
                principalTable: "SALES",
                principalColumn: "sale_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SALE_DETAILS_PRODUCTS_product_id",
                table: "SALE_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_SALE_DETAILS_SALES_sale_id",
                table: "SALE_DETAILS");

            migrationBuilder.RenameColumn(
                name: "remarks",
                table: "SALE_DETAILS",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "SALE_DETAILS",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "sale_id",
                table: "SALE_DETAILS",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "SALE_DETAILS",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "sale_detail_id",
                table: "SALE_DETAILS",
                newName: "SaleDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_SALE_DETAILS_sale_id",
                table: "SALE_DETAILS",
                newName: "IX_SALE_DETAILS_SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_SALE_DETAILS_product_id",
                table: "SALE_DETAILS",
                newName: "IX_SALE_DETAILS_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SALE_DETAILS_PRODUCTS_ProductId",
                table: "SALE_DETAILS",
                column: "ProductId",
                principalTable: "PRODUCTS",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SALE_DETAILS_SALES_SaleId",
                table: "SALE_DETAILS",
                column: "SaleId",
                principalTable: "SALES",
                principalColumn: "sale_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
