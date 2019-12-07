using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfieStation.Migrations
{
    public partial class thridMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "imageInfo");

            migrationBuilder.AddColumn<string>(
                name: "freeUrl",
                table: "imageInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "premiumUrl",
                table: "imageInfo",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "freeUrl",
                table: "imageInfo");

            migrationBuilder.DropColumn(
                name: "premiumUrl",
                table: "imageInfo");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "imageInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
