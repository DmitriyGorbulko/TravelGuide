using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelGuide.Db.Migrations
{
    public partial class new_diagram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Places_PlaceId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Ways_WayId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_PlaceId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_WayId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "WayId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Places");

            migrationBuilder.AddColumn<int>(
                name: "PointId",
                table: "Places",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PointOfWays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PointId = table.Column<int>(type: "integer", nullable: false),
                    WayId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfWays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointOfWays_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointOfWays_Ways_WayId",
                        column: x => x.WayId,
                        principalTable: "Ways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_PointId",
                table: "Places",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfWays_PointId",
                table: "PointOfWays",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfWays_WayId",
                table: "PointOfWays",
                column: "WayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Points_PointId",
                table: "Places",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Points_PointId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "PointOfWays");

            migrationBuilder.DropIndex(
                name: "IX_Places_PointId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PointId",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Points",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Points",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WayId",
                table: "Points",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "X",
                table: "Places",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Y",
                table: "Places",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Points_PlaceId",
                table: "Points",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_WayId",
                table: "Points",
                column: "WayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Places_PlaceId",
                table: "Points",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Ways_WayId",
                table: "Points",
                column: "WayId",
                principalTable: "Ways",
                principalColumn: "Id");
        }
    }
}
