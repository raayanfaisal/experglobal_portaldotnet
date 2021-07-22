using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace expertglobal.Migrations
{
    public partial class inqueries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inqueries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDard = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    AssignTo = table.Column<string>(nullable: true),
                    CustomertStatus = table.Column<string>(nullable: true),
                    InquStatus = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inqueries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inqueries");
        }
    }
}
