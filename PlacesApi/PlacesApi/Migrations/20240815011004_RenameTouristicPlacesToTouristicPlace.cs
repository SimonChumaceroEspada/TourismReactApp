using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameTouristicPlacesToTouristicPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TouristicPlaces",
                newName: "TouristicPlace");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TouristicPlace",
                newName: "TouristicPlaces");
        }
    }
}
