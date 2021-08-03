using Microsoft.EntityFrameworkCore.Migrations;

namespace expertglobal.Migrations
{
    public partial class updatedInqueryMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Inqueries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Inqueries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Inqueries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Inqueries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Inqueries");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Inqueries");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Inqueries");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Inqueries");
        }
    }
}
