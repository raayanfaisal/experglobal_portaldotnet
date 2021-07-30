using Microsoft.EntityFrameworkCore.Migrations;

namespace expertglobal.Migrations
{
    public partial class inqueryFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Inqueries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Inqueries");
        }
    }
}
