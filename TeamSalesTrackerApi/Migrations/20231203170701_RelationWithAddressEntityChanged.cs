using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class RelationWithAddressEntityChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BRANCHES_ADDRESSES_address_id",
                table: "BRANCHES");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ADDRESSES_address_id",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_USERS_address_id",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_BRANCHES_address_id",
                table: "BRANCHES");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "BRANCHES");

            migrationBuilder.AddColumn<long>(
                name: "branch_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_branch_id",
                table: "ADDRESSES",
                column: "branch_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES",
                column: "branch_id",
                principalTable: "BRANCHES",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_USERS_branch_id",
                table: "ADDRESSES",
                column: "branch_id",
                principalTable: "USERS",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_USERS_branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESSES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropColumn(
                name: "branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "ADDRESSES");

            migrationBuilder.AddColumn<long>(
                name: "address_id",
                table: "USERS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "address_id",
                table: "BRANCHES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_address_id",
                table: "USERS",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_BRANCHES_address_id",
                table: "BRANCHES",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BRANCHES_ADDRESSES_address_id",
                table: "BRANCHES",
                column: "address_id",
                principalTable: "ADDRESSES",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ADDRESSES_address_id",
                table: "USERS",
                column: "address_id",
                principalTable: "ADDRESSES",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
