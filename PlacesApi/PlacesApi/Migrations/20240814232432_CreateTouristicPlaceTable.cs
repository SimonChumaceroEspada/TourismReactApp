using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTouristicPlaceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TouristicPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EspDescription = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    EngDescription = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    Image = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristicPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristicPlaces_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TouristicPlaces_PlaceId",
                table: "TouristicPlaces",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristicPlaces");
        }
    }
}
