using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dta.Migrations
{
    /// <inheritdoc />
    public partial class OfertaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferta_Empresa_EmpresaID",
                table: "Oferta");

            migrationBuilder.RenameColumn(
                name: "EmpresaID",
                table: "Oferta",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Oferta_EmpresaID",
                table: "Oferta",
                newName: "IX_Oferta_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Oferta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Oferta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEmpresa",
                table: "Oferta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumeroTelefono",
                table: "Oferta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaginaWebDeLaEmpresa",
                table: "Oferta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Oferta_Empresa_EmpresaId",
                table: "Oferta",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferta_Empresa_EmpresaId",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "NombreEmpresa",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "NumeroTelefono",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "PaginaWebDeLaEmpresa",
                table: "Oferta");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Oferta",
                newName: "EmpresaID");

            migrationBuilder.RenameIndex(
                name: "IX_Oferta_EmpresaId",
                table: "Oferta",
                newName: "IX_Oferta_EmpresaID");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaID",
                table: "Oferta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Oferta_Empresa_EmpresaID",
                table: "Oferta",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
