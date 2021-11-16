using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class Delete_onCascade_all_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aspirantes_Ces_CesId",
                table: "Aspirantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Aspirantes_EspecGraduados_EspecGraduadoId",
                table: "Aspirantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Aspirantes_Paises_PaisId",
                table: "Aspirantes");

            migrationBuilder.DropForeignKey(
                name: "FK_CentroTrabajos_Municipios_MunicipioId",
                table: "CentroTrabajos");

            migrationBuilder.DropForeignKey(
                name: "FK_Maestrias_Facultades_FacultadId",
                table: "Maestrias");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aspirantes_AspiranteCI",
                table: "Matricula");

            migrationBuilder.AlterColumn<string>(
                name: "AspiranteCI",
                table: "Matricula",
                type: "nvarchar(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AspiranteId",
                table: "Matricula",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FacultadId",
                table: "Maestrias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "CentroTrabajos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "Aspirantes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EspecGraduadoId",
                table: "Aspirantes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CesId",
                table: "Aspirantes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SexoId",
                table: "Aspirantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Aspirantes_Ces_CesId",
                table: "Aspirantes",
                column: "CesId",
                principalTable: "Ces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aspirantes_EspecGraduados_EspecGraduadoId",
                table: "Aspirantes",
                column: "EspecGraduadoId",
                principalTable: "EspecGraduados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aspirantes_Paises_PaisId",
                table: "Aspirantes",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CentroTrabajos_Municipios_MunicipioId",
                table: "CentroTrabajos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maestrias_Facultades_FacultadId",
                table: "Maestrias",
                column: "FacultadId",
                principalTable: "Facultades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aspirantes_AspiranteCI",
                table: "Matricula",
                column: "AspiranteCI",
                principalTable: "Aspirantes",
                principalColumn: "CI",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aspirantes_Ces_CesId",
                table: "Aspirantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Aspirantes_EspecGraduados_EspecGraduadoId",
                table: "Aspirantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Aspirantes_Paises_PaisId",
                table: "Aspirantes");

            migrationBuilder.DropForeignKey(
                name: "FK_CentroTrabajos_Municipios_MunicipioId",
                table: "CentroTrabajos");

            migrationBuilder.DropForeignKey(
                name: "FK_Maestrias_Facultades_FacultadId",
                table: "Maestrias");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aspirantes_AspiranteCI",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "AspiranteId",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "SexoId",
                table: "Aspirantes");

            migrationBuilder.AlterColumn<string>(
                name: "AspiranteCI",
                table: "Matricula",
                type: "nvarchar(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)");

            migrationBuilder.AlterColumn<int>(
                name: "FacultadId",
                table: "Maestrias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "CentroTrabajos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "Aspirantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EspecGraduadoId",
                table: "Aspirantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CesId",
                table: "Aspirantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Aspirantes_Ces_CesId",
                table: "Aspirantes",
                column: "CesId",
                principalTable: "Ces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aspirantes_EspecGraduados_EspecGraduadoId",
                table: "Aspirantes",
                column: "EspecGraduadoId",
                principalTable: "EspecGraduados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aspirantes_Paises_PaisId",
                table: "Aspirantes",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CentroTrabajos_Municipios_MunicipioId",
                table: "CentroTrabajos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maestrias_Facultades_FacultadId",
                table: "Maestrias",
                column: "FacultadId",
                principalTable: "Facultades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aspirantes_AspiranteCI",
                table: "Matricula",
                column: "AspiranteCI",
                principalTable: "Aspirantes",
                principalColumn: "CI",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
