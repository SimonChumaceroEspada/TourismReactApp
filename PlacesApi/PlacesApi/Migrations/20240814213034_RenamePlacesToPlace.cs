using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacesApi.Migrations
{
    /// <inheritdoc />
    public partial class RenamePlacesToPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");
        }
    }
}
