using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsInTouristicPlaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "touristic_places",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "EspName",
                table: "touristic_places",
                newName: "esp_name");

            migrationBuilder.RenameColumn(
                name: "EngName",
                table: "touristic_places",
                newName: "eng_name");

            migrationBuilder.RenameColumn(
                name: "EspDescription",
                table: "touristic_places",
                newName: "esp_description");
            
            migrationBuilder.RenameColumn(
                name: "EngDescription",
                table: "touristic_places",
                newName: "eng_description");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "touristic_places",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "touristic_places",
                newName: "place_id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "touristic_places",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "esp_name",
                table: "touristic_places",
                newName: "EspName");

            migrationBuilder.RenameColumn(
                name: "eng_name",
                table: "touristic_places",
                newName: "EngName");

            migrationBuilder.RenameColumn(
                name: "esp_description",
                table: "touristic_places",
                newName: "EspDescription");

            migrationBuilder.RenameColumn(
                name: "eng_description",
                table: "touristic_places",
                newName: "EngDescription");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "touristic_places",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "place_id",
                table: "touristic_places",
                newName: "PlaceId");

        }
    }
}
