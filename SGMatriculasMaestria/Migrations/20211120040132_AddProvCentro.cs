using Microsoft.EntityFrameworkCore.Migrations;

namespace SGMatriculasMaestria.Migrations
{
    public partial class AddProvCentro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentroTrabajos_Municipios_MunicipioId",
                table: "CentroTrabajos");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "CentroTrabajos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId1",
                table: "CentroTrabajos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CentroTrabajos_ProvinciaId1",
                table: "CentroTrabajos",
                column: "ProvinciaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CentroTrabajos_Municipios_MunicipioId",
                table: "CentroTrabajos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CentroTrabajos_Provincias_ProvinciaId1",
                table: "CentroTrabajos",
                column: "ProvinciaId1",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentroTrabajos_Municipios_MunicipioId",
                table: "CentroTrabajos");

            migrationBuilder.DropForeignKey(
                name: "FK_CentroTrabajos_Provincias_ProvinciaId1",
                table: "CentroTrabajos");

            migrationBuilder.DropIndex(
                name: "IX_CentroTrabajos_ProvinciaId1",
                table: "CentroTrabajos");

            migrationBuilder.DropColumn(
                name: "ProvinciaId1",
                table: "CentroTrabajos");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "CentroTrabajos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CentroTrabajos_Municipios_MunicipioId",
                table: "CentroTrabajos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
