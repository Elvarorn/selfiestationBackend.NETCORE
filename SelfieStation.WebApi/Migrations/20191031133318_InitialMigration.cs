using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfieStation.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imageInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageGUID = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    timeStamp = table.Column<DateTime>(nullable: false),
                    hasEmailBeenSent = table.Column<bool>(nullable: false),
                    success = table.Column<bool>(nullable: false),
                    hasImageBeenBought = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imageInfo");
        }
    }
}
