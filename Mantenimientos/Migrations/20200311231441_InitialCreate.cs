using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantenimientos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    AsignaturaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.AsignaturaID);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudiantesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Matricula = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudiantesID);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    ProfesoresID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.ProfesoresID);
                });

            migrationBuilder.CreateTable(
                name: "AsignaturaEstudiantes",
                columns: table => new
                {
                    AsignaturaEstudianteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsignaturaID = table.Column<int>(nullable: false),
                    EstudianteID = table.Column<int>(nullable: false),
                    EstudiantesID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaEstudiantes", x => x.AsignaturaEstudianteID);
                    table.ForeignKey(
                        name: "FK_AsignaturaEstudiantes_Asignatura_AsignaturaID",
                        column: x => x.AsignaturaID,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaEstudiantes_Estudiantes_EstudiantesID",
                        column: x => x.EstudiantesID,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudiantesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsignaturaProfesores",
                columns: table => new
                {
                    asignaturaProfesoresID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsignaturaID = table.Column<int>(nullable: false),
                    ProfesoresID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaProfesores", x => x.asignaturaProfesoresID);
                    table.ForeignKey(
                        name: "FK_AsignaturaProfesores_Asignatura_AsignaturaID",
                        column: x => x.AsignaturaID,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaProfesores_Profesores_ProfesoresID",
                        column: x => x.ProfesoresID,
                        principalTable: "Profesores",
                        principalColumn: "ProfesoresID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaEstudiantes_AsignaturaID",
                table: "AsignaturaEstudiantes",
                column: "AsignaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaEstudiantes_EstudiantesID",
                table: "AsignaturaEstudiantes",
                column: "EstudiantesID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaProfesores_AsignaturaID",
                table: "AsignaturaProfesores",
                column: "AsignaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaProfesores_ProfesoresID",
                table: "AsignaturaProfesores",
                column: "ProfesoresID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignaturaEstudiantes");

            migrationBuilder.DropTable(
                name: "AsignaturaProfesores");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
