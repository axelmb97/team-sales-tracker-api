using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class AddingNullValues2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_USERS_user_id",
                table: "ADDRESSES");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES",
                column: "branch_id",
                principalTable: "BRANCHES",
                principalColumn: "branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_USERS_user_id",
                table: "ADDRESSES",
                column: "user_id",
                principalTable: "USERS",
                principalColumn: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_USERS_user_id",
                table: "ADDRESSES");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES",
                column: "branch_id",
                principalTable: "BRANCHES",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_USERS_user_id",
                table: "ADDRESSES",
                column: "user_id",
                principalTable: "USERS",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
