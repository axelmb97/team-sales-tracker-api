using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class AddresConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESSES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "BRANCHES",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_BRANCHES_ADDRESSES_branch_id",
                table: "BRANCHES",
                column: "branch_id",
                principalTable: "ADDRESSES",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BRANCHES_ADDRESSES_branch_id",
                table: "BRANCHES");

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "BRANCHES",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
        }
    }
}
