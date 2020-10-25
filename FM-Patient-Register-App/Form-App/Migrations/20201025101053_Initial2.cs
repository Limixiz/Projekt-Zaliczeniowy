using Microsoft.EntityFrameworkCore.Migrations;

namespace Form_App.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VasScale",
                table: "Therapies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tests",
                table: "Therapies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "Therapies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_ApplicationUserID",
                table: "Therapies",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_AspNetUsers_ApplicationUserID",
                table: "Therapies",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_AspNetUsers_ApplicationUserID",
                table: "Therapies");

            migrationBuilder.DropIndex(
                name: "IX_Therapies_ApplicationUserID",
                table: "Therapies");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Therapies");

            migrationBuilder.AlterColumn<string>(
                name: "VasScale",
                table: "Therapies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Tests",
                table: "Therapies",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
