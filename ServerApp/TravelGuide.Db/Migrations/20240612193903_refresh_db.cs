using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelGuide.Db.Migrations
{
    public partial class refresh_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Points_PointId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_PointOfWays_Points_PointId",
                table: "PointOfWays");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropIndex(
                name: "IX_PointOfWays_PointId",
                table: "PointOfWays");

            migrationBuilder.DropColumn(
                name: "PointId",
                table: "PointOfWays");

            migrationBuilder.RenameColumn(
                name: "PointId",
                table: "Places",
                newName: "TypePlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_PointId",
                table: "Places",
                newName: "IX_Places_TypePlaceId");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Ways",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "PointOfWays",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "PointOfWays",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Places",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Places",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "FavoritePlaceUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePlaceUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritePlaceUsers_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritePlaceUsers_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypePlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagOfPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagOfPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagOfPlaces_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagOfPlaces_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlaceUsers_PlaceId",
                table: "FavoritePlaceUsers",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlaceUsers_UserId",
                table: "FavoritePlaceUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PlaceId",
                table: "Reviews",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagOfPlaces_PlaceId",
                table: "TagOfPlaces",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TagOfPlaces_TagId",
                table: "TagOfPlaces",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PlaceId",
                table: "Tags",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_TypePlaces_TypePlaceId",
                table: "Places",
                column: "TypePlaceId",
                principalTable: "TypePlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_TypePlaces_TypePlaceId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "FavoritePlaceUsers");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TagOfPlaces");

            migrationBuilder.DropTable(
                name: "TypePlaces");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Ways");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "PointOfWays");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "PointOfWays");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "TypePlaceId",
                table: "Places",
                newName: "PointId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_TypePlaceId",
                table: "Places",
                newName: "IX_Places_PointId");

            migrationBuilder.AddColumn<int>(
                name: "PointId",
                table: "PointOfWays",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointOfWays_PointId",
                table: "PointOfWays",
                column: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Points_PointId",
                table: "Places",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfWays_Points_PointId",
                table: "PointOfWays",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
