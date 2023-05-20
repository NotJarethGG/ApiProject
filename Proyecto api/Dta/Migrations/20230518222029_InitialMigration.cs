using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dta.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habilidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AniosEstudio = table.Column<int>(type: "int", nullable: false),
                    FechaConclusion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formacion_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oferta_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoHabilidad",
                columns: table => new
                {
                    CandidatoID = table.Column<int>(type: "int", nullable: false),
                    HabilidadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoHabilidad", x => new { x.CandidatoID, x.HabilidadID });
                    table.ForeignKey(
                        name: "FK_CandidatoHabilidad_Candidato_CandidatoID",
                        column: x => x.CandidatoID,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoHabilidad_Habilidad_HabilidadID",
                        column: x => x.HabilidadID,
                        principalTable: "Habilidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoOferta",
                columns: table => new
                {
                    CandidatoID = table.Column<int>(type: "int", nullable: false),
                    OfertaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoOferta", x => new { x.CandidatoID, x.OfertaID });
                    table.ForeignKey(
                        name: "FK_CandidatoOferta_Candidato_CandidatoID",
                        column: x => x.CandidatoID,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoOferta_Oferta_CandidatoID",
                        column: x => x.CandidatoID,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaHabilidad",
                columns: table => new
                {
                    OfertaId = table.Column<int>(type: "int", nullable: false),
                    HabilidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaHabilidad", x => new { x.OfertaId, x.HabilidadId });
                    table.ForeignKey(
                        name: "FK_OfertaHabilidad_Habilidad_HabilidadId",
                        column: x => x.HabilidadId,
                        principalTable: "Habilidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaHabilidad_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoHabilidad_HabilidadID",
                table: "CandidatoHabilidad",
                column: "HabilidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Formacion_CandidatoId",
                table: "Formacion",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_EmpresaID",
                table: "Oferta",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaHabilidad_HabilidadId",
                table: "OfertaHabilidad",
                column: "HabilidadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoHabilidad");

            migrationBuilder.DropTable(
                name: "CandidatoOferta");

            migrationBuilder.DropTable(
                name: "Formacion");

            migrationBuilder.DropTable(
                name: "OfertaHabilidad");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Habilidad");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
