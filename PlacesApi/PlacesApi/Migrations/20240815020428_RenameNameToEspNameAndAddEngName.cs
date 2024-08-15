using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameNameToEspNameAndAddEngName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TouristicPlace",
                newName: "EspName");

            migrationBuilder.AddColumn<string>(
                name: "EngName",
                table: "TouristicPlace",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngName",
                table: "TouristicPlace");

            migrationBuilder.RenameColumn(
                name: "EspName",
                table: "TouristicPlace",
                newName: "Name");
        }
    }
}
