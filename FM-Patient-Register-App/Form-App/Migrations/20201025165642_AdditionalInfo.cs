using Microsoft.EntityFrameworkCore.Migrations;

namespace Form_App.Migrations
{
    public partial class AdditionalInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdisionalInfo",
                table: "Therapies");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Therapies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Therapies");

            migrationBuilder.AddColumn<string>(
                name: "AdisionalInfo",
                table: "Therapies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
