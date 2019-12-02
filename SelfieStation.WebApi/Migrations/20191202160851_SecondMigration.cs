using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfieStation.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "imageInfo",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "adInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    GUID = table.Column<string>(nullable: false),
                    ImgURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adInfo");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "imageInfo");
        }
    }
}
