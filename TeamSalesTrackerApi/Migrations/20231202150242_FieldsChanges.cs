using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamSalesTrackerApi.Migrations
{
    public partial class FieldsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "USERS",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<byte[]>(
                name: "password_salt",
                table: "USERS",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "USERS");

            migrationBuilder.AlterColumn<byte[]>(
                name: "password",
                table: "USERS",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
