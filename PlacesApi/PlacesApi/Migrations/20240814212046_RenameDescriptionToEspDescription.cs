using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameDescriptionToEspDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Places",
                newName: "EspDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EspDescription",
                table: "Places",
                newName: "Description");
        }
    }
}
