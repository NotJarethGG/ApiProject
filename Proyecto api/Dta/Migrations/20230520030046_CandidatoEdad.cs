using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dta.Migrations
{
    /// <inheritdoc />
    public partial class CandidatoEdad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferta_Empresa_EmpresaId",
                table: "Oferta");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Oferta_EmpresaId",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Candidato");

            migrationBuilder.AddColumn<int>(
                name: "edad",
                table: "Candidato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "edad",
                table: "Candidato");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Oferta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaNacimiento",
                table: "Candidato",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_EmpresaId",
                table: "Oferta",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oferta_Empresa_EmpresaId",
                table: "Oferta",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }
    }
}
