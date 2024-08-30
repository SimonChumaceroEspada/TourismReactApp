using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class CreatePlacesDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "places_data",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    esp_name = table.Column<string>(maxLength: 100, nullable: false),
                    eng_name = table.Column<string>(maxLength: 100, nullable: false),
                    image = table.Column<string>(maxLength: 3000, nullable: true),
                    esp_description = table.Column<string>(maxLength: 3000, nullable: true),
                    eng_description = table.Column<string>(maxLength: 3000, nullable: true, defaultValue: ""),
                    place_id = table.Column<int>(nullable: true),
                    type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesData", x => x.id);
                    table.ForeignKey(
                        name: "FK_places_data_places_place_id",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_places_data_place_id",
                table: "places_data",
                column: "place_id");

            migrationBuilder.Sql(@"
                CREATE VIEW public.foods AS
                SELECT * FROM public.places_data WHERE type = 'food';

                CREATE VIEW public.parties AS
                SELECT * FROM public.places_data WHERE type = 'party';

                CREATE VIEW public.touristic_places AS
                SELECT * FROM public.places_data WHERE type = 'touristic_place';
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW public.foods;
                DROP VIEW public.parties;
                DROP VIEW public.touristic_places;
            ");

            migrationBuilder.DropTable(
                name: "places_data");
        }
    }
}