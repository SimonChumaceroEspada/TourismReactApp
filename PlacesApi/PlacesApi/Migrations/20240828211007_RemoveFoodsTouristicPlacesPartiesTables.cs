using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PlacesApi.Migrations
{
    public partial class RemoveFoodsTouristicPlacesPartiesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "foods");

            migrationBuilder.DropTable(
                name: "touristic_places");

            migrationBuilder.DropTable(
                name: "parties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "foods",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    esp_name = table.Column<string>(maxLength: 100, nullable: false),
                    eng_name = table.Column<string>(maxLength: 100, nullable: false),
                    esp_description = table.Column<string>(maxLength: 3000, nullable: false),
                    eng_description = table.Column<string>(maxLength: 3000, nullable: false),
                    image = table.Column<string>(maxLength: 3000, nullable: false),
                    place_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foods", x => x.id);
                    table.ForeignKey(
                        name: "FK_foods_places_place_id",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "touristic_places",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    esp_name = table.Column<string>(maxLength: 100, nullable: false),
                    eng_name = table.Column<string>(maxLength: 100, nullable: false),
                    esp_description = table.Column<string>(maxLength: 3000, nullable: false),
                    eng_description = table.Column<string>(maxLength: 3000, nullable: false),
                    image = table.Column<string>(maxLength: 3000, nullable: false),
                    place_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_touristic_places", x => x.id);
                    table.ForeignKey(
                        name: "FK_touristic_places_places_place_id",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parties",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    esp_name = table.Column<string>(maxLength: 100, nullable: false),
                    eng_name = table.Column<string>(maxLength: 100, nullable: false),
                    esp_description = table.Column<string>(maxLength: 3000, nullable: false),
                    eng_description = table.Column<string>(maxLength: 3000, nullable: false),
                    image = table.Column<string>(maxLength: 3000, nullable: false),
                    place_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parties", x => x.id);
                    table.ForeignKey(
                        name: "FK_parties_places_place_id",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}