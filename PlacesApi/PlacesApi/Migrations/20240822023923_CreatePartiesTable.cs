using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class CreatePartiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_parties_place_id",
                table: "parties",
                column: "place_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parties");
        }
    }
}
