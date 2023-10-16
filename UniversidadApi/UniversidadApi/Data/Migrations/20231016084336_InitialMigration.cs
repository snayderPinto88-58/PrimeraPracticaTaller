using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniversidadApi.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "universidad",
                columns: table => new
                {
                    Id_universidad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universidad", x => x.Id_universidad);
                });

            migrationBuilder.CreateTable(
                name: "docentes",
                columns: table => new
                {
                    Id_docente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    ubicacion = table.Column<string>(type: "text", nullable: false),
                    sexo = table.Column<string>(type: "text", nullable: false),
                    ci = table.Column<string>(type: "text", nullable: false),
                    Id_universidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.Id_docente);
                    table.ForeignKey(
                        name: "FK_docentes_universidad_Id_universidad",
                        column: x => x.Id_universidad,
                        principalTable: "universidad",
                        principalColumn: "Id_universidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    Id_estudiante = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    edad = table.Column<int>(type: "integer", nullable: false),
                    sexo = table.Column<string>(type: "text", nullable: false),
                    Id_universidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.Id_estudiante);
                    table.ForeignKey(
                        name: "FK_estudiantes_universidad_Id_universidad",
                        column: x => x.Id_universidad,
                        principalTable: "universidad",
                        principalColumn: "Id_universidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    Id_materia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombreMateria = table.Column<string>(type: "text", nullable: false),
                    Id_docente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.Id_materia);
                    table.ForeignKey(
                        name: "FK_materias_docentes_Id_docente",
                        column: x => x.Id_docente,
                        principalTable: "docentes",
                        principalColumn: "Id_docente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_docentes_Id_universidad",
                table: "docentes",
                column: "Id_universidad");

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_Id_universidad",
                table: "estudiantes",
                column: "Id_universidad");

            migrationBuilder.CreateIndex(
                name: "IX_materias_Id_docente",
                table: "materias",
                column: "Id_docente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "docentes");

            migrationBuilder.DropTable(
                name: "universidad");
        }
    }
}
