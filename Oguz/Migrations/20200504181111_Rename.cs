using Microsoft.EntityFrameworkCore.Migrations;

namespace Oguz.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Colors");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Styles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Colors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Colors");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
