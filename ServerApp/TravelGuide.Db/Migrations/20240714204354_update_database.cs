using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Db.Migrations
{
    public partial class update_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "way",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_way_user_id",
                table: "way",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_way_user_user_id",
                table: "way",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_way_user_user_id",
                table: "way");

            migrationBuilder.DropIndex(
                name: "IX_way_user_id",
                table: "way");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "way");
        }
    }
}
