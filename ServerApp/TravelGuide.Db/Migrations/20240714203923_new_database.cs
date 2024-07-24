using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelGuide.Db.Migrations
{
    public partial class new_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Points_PointId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_PointOfWays_Points_PointId",
                table: "PointOfWays");

            migrationBuilder.DropForeignKey(
                name: "FK_PointOfWays_Ways_WayId",
                table: "PointOfWays");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ways",
                table: "Ways");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointOfWays",
                table: "PointOfWays");

            migrationBuilder.DropIndex(
                name: "IX_PointOfWays_PointId",
                table: "PointOfWays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PointId",
                table: "PointOfWays");

            migrationBuilder.RenameTable(
                name: "Ways",
                newName: "way");

            migrationBuilder.RenameTable(
                name: "PointOfWays",
                newName: "point_of_way");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "place");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "way",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "way",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "way",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "point_of_way",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WayId",
                table: "point_of_way",
                newName: "way_id");

            migrationBuilder.RenameIndex(
                name: "IX_PointOfWays_WayId",
                table: "point_of_way",
                newName: "IX_point_of_way_way_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "place",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PointId",
                table: "place",
                newName: "type_place_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "place",
                newName: "title");

            migrationBuilder.RenameIndex(
                name: "IX_Places_PointId",
                table: "place",
                newName: "IX_place_type_place_id");

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "point_of_way",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "point_of_way",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "place",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "place",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_way",
                table: "way",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_point_of_way",
                table: "point_of_way",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_place",
                table: "place",
                column: "id");

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    place_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.id);
                    table.ForeignKey(
                        name: "FK_review_place_place_id",
                        column: x => x.place_id,
                        principalTable: "place",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_review_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_private = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "type_place",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_place", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "favorite_tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tag_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorite_tag", x => x.id);
                    table.ForeignKey(
                        name: "FK_favorite_tag_tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorite_tag_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_of_place",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    place_id = table.Column<int>(type: "integer", nullable: false),
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag_of_place", x => x.id);
                    table.ForeignKey(
                        name: "FK_tag_of_place_place_place_id",
                        column: x => x.place_id,
                        principalTable: "place",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tag_of_place_tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_favorite_tag_tag_id",
                table: "favorite_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_favorite_tag_user_id",
                table: "favorite_tag",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_place_id",
                table: "review",
                column: "place_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_user_id",
                table: "review",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_user_id",
                table: "tag",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_of_place_place_id",
                table: "tag_of_place",
                column: "place_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_of_place_tag_id",
                table: "tag_of_place",
                column: "tag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_place_type_place_type_place_id",
                table: "place",
                column: "type_place_id",
                principalTable: "type_place",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_point_of_way_way_way_id",
                table: "point_of_way",
                column: "way_id",
                principalTable: "way",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_place_type_place_type_place_id",
                table: "place");

            migrationBuilder.DropForeignKey(
                name: "FK_point_of_way_way_way_id",
                table: "point_of_way");

            migrationBuilder.DropTable(
                name: "favorite_tag");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "tag_of_place");

            migrationBuilder.DropTable(
                name: "type_place");

            migrationBuilder.DropTable(
                name: "tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_way",
                table: "way");

            migrationBuilder.DropPrimaryKey(
                name: "PK_point_of_way",
                table: "point_of_way");

            migrationBuilder.DropPrimaryKey(
                name: "PK_place",
                table: "place");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "point_of_way");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "point_of_way");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "place");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "place");

            migrationBuilder.RenameTable(
                name: "way",
                newName: "Ways");

            migrationBuilder.RenameTable(
                name: "point_of_way",
                newName: "PointOfWays");

            migrationBuilder.RenameTable(
                name: "place",
                newName: "Places");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "user",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Ways",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Ways",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Ways",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PointOfWays",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "way_id",
                table: "PointOfWays",
                newName: "WayId");

            migrationBuilder.RenameIndex(
                name: "IX_point_of_way_way_id",
                table: "PointOfWays",
                newName: "IX_PointOfWays_WayId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Places",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type_place_id",
                table: "Places",
                newName: "PointId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Places",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_place_type_place_id",
                table: "Places",
                newName: "IX_Places_PointId");

            migrationBuilder.AddColumn<int>(
                name: "PointId",
                table: "PointOfWays",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ways",
                table: "Ways",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointOfWays",
                table: "PointOfWays",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<string>(type: "text", nullable: false),
                    Y = table.Column<string>(type: "text", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfWays_Ways_WayId",
                table: "PointOfWays",
                column: "WayId",
                principalTable: "Ways",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
