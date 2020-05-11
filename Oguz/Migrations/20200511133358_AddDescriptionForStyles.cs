using Microsoft.EntityFrameworkCore.Migrations;

namespace Oguz.Migrations
{
    public partial class AddDescriptionForStyles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Styles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Styles");
        }
    }
}
