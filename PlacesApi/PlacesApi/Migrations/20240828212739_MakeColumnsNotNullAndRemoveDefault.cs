using Microsoft.EntityFrameworkCore.Migrations;

namespace PlacesApi.Migrations
{
    public partial class MakeColumnsNotNullAndRemoveDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Quitar el valor por defecto de la columna eng_description
            migrationBuilder.AlterColumn<string>(
                name: "eng_description",
                table: "places_data",
                type: "character varying(3000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(3000)",
                oldDefaultValue: "''::character varying");

            // Asegurarse de que todas las columnas sean NOT NULL
            migrationBuilder.Sql(
                "ALTER TABLE places_data ALTER COLUMN image SET NOT NULL");
            migrationBuilder.Sql(
                "ALTER TABLE places_data ALTER COLUMN esp_description SET NOT NULL");
            migrationBuilder.Sql(
                "ALTER TABLE places_data ALTER COLUMN eng_description SET NOT NULL");
            migrationBuilder.Sql(
                "ALTER TABLE places_data ALTER COLUMN place_id SET NOT NULL");
            // Repite la línea anterior para cada columna en la tabla places_data
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Restaurar el valor por defecto de la columna eng_description
            migrationBuilder.AlterColumn<string>(
                name: "eng_description",
                table: "places_data",
                type: "character varying(3000)",
                nullable: false,
                defaultValue: "''::character varying",
                oldClrType: typeof(string),
                oldType: "character varying(3000)");

            // Restaurar las columnas a su estado anterior si es necesario
            migrationBuilder.Sql(
                "ALTER TABLE places_data ALTER COLUMN image DROP NOT NULL");
            migrationBuilder.Sql(
                "ALTER TABLE places_data ALTER COLUMN esp_description DROP NOT NULL");
            migrationBuilder.Sql(
                "ALTER TABLE places_data ALTER COLUMN eng_description DROP NOT NULL");
            migrationBuilder.Sql(
                "ALTER TABLE places_data ALTER COLUMN place_id DROP NOT NULL");
            // Repite la línea anterior para cada columna en la tabla places_data
        }
    }
}