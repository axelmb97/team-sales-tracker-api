using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class FixingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_USERS_branch_id",
                table: "ADDRESSES");

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
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_USERS_user_id",
                table: "ADDRESSES");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESSES_user_id",
                table: "ADDRESSES");

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_USERS_branch_id",
                table: "ADDRESSES",
                column: "branch_id",
                principalTable: "USERS",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
