using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantenimientos.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignaturaEstudiantes_Estudiantes_EstudiantesID",
                table: "AsignaturaEstudiantes");

            migrationBuilder.DropColumn(
                name: "EstudianteID",
                table: "AsignaturaEstudiantes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Estudiantes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Estudiantes",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Estudiantes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EstudiantesID",
                table: "AsignaturaEstudiantes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AsignaturaEstudiantes_Estudiantes_EstudiantesID",
                table: "AsignaturaEstudiantes",
                column: "EstudiantesID",
                principalTable: "Estudiantes",
                principalColumn: "EstudiantesID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignaturaEstudiantes_Estudiantes_EstudiantesID",
                table: "AsignaturaEstudiantes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "EstudiantesID",
                table: "AsignaturaEstudiantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EstudianteID",
                table: "AsignaturaEstudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AsignaturaEstudiantes_Estudiantes_EstudiantesID",
                table: "AsignaturaEstudiantes",
                column: "EstudiantesID",
                principalTable: "Estudiantes",
                principalColumn: "EstudiantesID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
