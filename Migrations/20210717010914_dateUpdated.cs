using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace expertglobal.Migrations
{
    public partial class dateUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "AuditLogs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Date",
                table: "AuditLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
