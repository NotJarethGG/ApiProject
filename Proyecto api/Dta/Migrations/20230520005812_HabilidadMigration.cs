using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dta.Migrations
{
    /// <inheritdoc />
    public partial class HabilidadMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Habilidad",
                newName: "NombreHabilidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreHabilidad",
                table: "Habilidad",
                newName: "Nombre");
        }
    }
}
