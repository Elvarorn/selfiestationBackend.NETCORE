using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfieStation.Migrations
{
    public partial class fourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasEmailBeenSent",
                table: "imageInfo");

            migrationBuilder.AddColumn<bool>(
                name: "hasFreeEmailBeenSent",
                table: "imageInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasPremiumEmailBeenSent",
                table: "imageInfo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasFreeEmailBeenSent",
                table: "imageInfo");

            migrationBuilder.DropColumn(
                name: "hasPremiumEmailBeenSent",
                table: "imageInfo");

            migrationBuilder.AddColumn<bool>(
                name: "hasEmailBeenSent",
                table: "imageInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
