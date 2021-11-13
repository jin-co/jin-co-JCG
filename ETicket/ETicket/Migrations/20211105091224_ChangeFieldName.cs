using Microsoft.EntityFrameworkCore.Migrations;

namespace ETicket.Migrations
{
    public partial class ChangeFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Movies",
                newName: "ImageURL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Movies",
                newName: "Image");
        }
    }
}
