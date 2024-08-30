using Microsoft.EntityFrameworkCore.Migrations;

namespace PlacesApi.Migrations
{
    public partial class AddTypeConstraintToPlacesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE places_data ADD CONSTRAINT chk_type CHECK (type IN ('food', 'party', 'touristic_place'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE places_data DROP CONSTRAINT chk_type");
        }
    }
}