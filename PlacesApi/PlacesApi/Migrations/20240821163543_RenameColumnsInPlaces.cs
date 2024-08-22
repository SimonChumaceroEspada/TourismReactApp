using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsInPlaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "places",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "places",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Capital",
                table: "places",
                newName: "capital");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "places",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "EspDescription",
                table: "places",
                newName: "esp_description");

            migrationBuilder.RenameColumn(
                name: "EngDescription",
                table: "places",
                newName: "eng_description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "places",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "places",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "capital",
                table: "places",
                newName: "Capital");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "places",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "esp_description",
                table: "places",
                newName: "EspDescription");

            migrationBuilder.RenameColumn(
                name: "eng_description",
                table: "places",
                newName: "EngDescription");
        }
    }
}
