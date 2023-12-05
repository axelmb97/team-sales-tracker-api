using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class NullValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_USERS_user_id",
                table: "ADDRESSES");

            migrationBuilder.DropForeignKey(
                name: "FK_BRANCHES_ADDRESSES_branch_id",
                table: "BRANCHES");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESSES_user_id",
                table: "ADDRESSES");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "USERS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "BRANCHES",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: true,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
                name: "FK_USERS_ADDRESSES_user_id",
                table: "USERS",
                column: "user_id",
                principalTable: "ADDRESSES",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ADDRESSES_user_id",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESSES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "USERS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "BRANCHES",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_user_id",
                table: "ADDRESSES",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_USERS_user_id",
                table: "ADDRESSES",
                column: "user_id",
                principalTable: "USERS",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BRANCHES_ADDRESSES_branch_id",
                table: "BRANCHES",
                column: "branch_id",
                principalTable: "ADDRESSES",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
