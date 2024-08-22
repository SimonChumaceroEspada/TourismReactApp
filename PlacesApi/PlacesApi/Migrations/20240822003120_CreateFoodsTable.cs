using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateFoodsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                           name: "foods",
                           columns: table => new
                           {
                               id = table.Column<int>(type: "integer", nullable: false)
                                   .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                               esp_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                               eng_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                               image = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: false),
                               place_id = table.Column<int>(type: "integer", nullable: false)
                           },
                           constraints: table =>
                           {
                               table.PrimaryKey("PK_foods", x => x.id);
                               table.ForeignKey(
                                   name: "FK_foods_place_place_id",
                                   column: x => x.place_id,
                                   principalTable: "places",
                                   principalColumn: "id",
                                   onDelete: ReferentialAction.Cascade);
                           });

            migrationBuilder.CreateIndex(
                name: "IX_foods_place_id",
                table: "foods",
                column: "place_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
     name: "foods");
        }
    }
}
