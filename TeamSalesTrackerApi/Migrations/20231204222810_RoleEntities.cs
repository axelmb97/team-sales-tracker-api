using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class RoleEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.AlterColumn<long>(
                name: "branch_id",
                table: "ADDRESSES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "USERS_ROLES",
                columns: table => new
                {
                    user_role_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS_ROLES", x => x.user_role_id);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_ROLES_role_id",
                        column: x => x.role_id,
                        principalTable: "ROLES",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_USERS_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_role_id",
                table: "USERS_ROLES",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_user_id",
                table: "USERS_ROLES",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES",
                column: "branch_id",
                principalTable: "BRANCHES",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESSES_BRANCHES_branch_id",
                table: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "USERS_ROLES");

            migrationBuilder.DropTable(
                name: "ROLES");

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
        }
    }
}
