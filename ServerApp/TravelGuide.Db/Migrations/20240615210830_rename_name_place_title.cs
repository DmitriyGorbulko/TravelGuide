using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Db.Migrations
{
    public partial class rename_name_place_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Places",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Places",
                newName: "Name");
        }
    }
}
